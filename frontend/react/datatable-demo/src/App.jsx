//import LogoImage from './assets/images/logo.png'
import './main.css'
//import CallApi from './lib/call-api.js'
//import Settings from './settings.json'
import DataTableFn from './data-table-fn.jsx'
import DataTableCls from './data-table-cls.jsx'


function App() {
    return (
        <div className="app">
            <h1>Brawlstars</h1>
            <DataTableCls url="http://localhost:5000/" />
            <hr/>
            <DataTableFn url="http://localhost:5000/" />
        </div>
    )
}

export default App
