const express = require('express');
const fs = require('fs');

exports.BaseApi = class BaseApi
{
    constructor() {
        this.app = express();
        this.app.use(express.json());
        this.readConfig();
        this.config.port = this.config.port || 3000;
        this.setupRouting();
    }

    readConfig() {
        try {
            this.config = JSON.parse(fs.readFileSync('settings.json'));
            // Server=myServerAddress;Port=1234;Database=myDataBase;Uid=myUsername;Pwd=myPassword;
            var tokens = this.config?.connectionstring?.split(';');
            if (tokens) this.config.db = {};
            for (var token of tokens) {
                if (token.length > 0) {
                    var [key, value] = token.split('=');
                    this.config.db[key.toLowerCase()] = value;
                }
            }
        } catch (err) {
            console.error(err);
        }
    }

    sendError(req, resp, err) {
        var data = { 'error':err.message, 'stack':err.stack, 'url':req.originalUrl };
        resp.status(404).send(JSON.stringify(data));
    }

    setupRouting() {
        this.app.all('/*', async (req, resp, next) => {
            var route = `${req.method}_${req.path.substring(1)}`.toLowerCase();
            console.debug('Access to ' + route);
            // enable all origins
            resp.append('Access-Control-Allow-Origin', '*');
            if (typeof this[route] === 'function') {
                var res = await this[route](req, resp);
                if (!(res instanceof Error)) {
                    resp.send(JSON.stringify(res));
                } else {
                    this.sendError(req, resp, err);
                }
            } else {
                this.sendError(req, resp, new Error('404 requested resource not found!'));
            }
        });
    }

    run() {
        console.log(`server is listening on ${this.config.port}`);
        this.app.listen(this.config.port);
    }
};
