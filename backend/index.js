var mysql = require('mysql');
const api = require('./base-api.js');

class MyTestApi extends api.BaseApi {
    constructor() {
        super();
        this.con = mysql.createConnection({
            host: this.config.db.server,
            user: this.config.db.uid,
            password: this.config.db.pwd,
            database:this.config.db.database,
          });
          
    }

    async query(sql, req, resp) {
        var isComplete = false;
        var result = null;
        this.con.query(sql,
            function (err, data, fields) {
                isComplete = true;
                result = err || data;
        });

        function poll(resolve) {
            if (isComplete) resolve();
            else setTimeout(poll, 100, resolve);
        }

        await new Promise(resolve => poll(resolve));
        return result;
    }

    async get_muvesz(req, resp) {
        return await this.query(`SELECT * FROM muvesz WHERE id=${req.query.id};`, req, resp);
    }

    async get_tables(req, resp) {
        return await this.query('SHOW TABLES;', req, resp);
    }
}

var myApi = new MyTestApi();

myApi.run();

// app.get('/*', function(req, resp) {

// });

// app.post('/ping/*', function(req, resp) {

// });
