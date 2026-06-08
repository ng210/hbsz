import { Component } from 'react';

export default class DataTableCls extends Component {
    state = {
        data: []
    }

    componentDidMount() {
        fetch(this.props.url + 'brawler')
            .then(resp => resp.json())
            .then(content => this.setState({data: content}))
            .catch(err => alert('Hiba: ' + err.message))
    }

    componentDidUpdate(prevProps, prevState) {
        if (this.state.data !== prevState.data) {
            console.log('data')
        }
    }

    componentWillUnmount() {
        // semmi tennivaló
    }

    onChangeSpeed(event, id) {
        let speed = parseInt(event.target.value) || 0
        if (speed > 1000) speed = 1000
        this.setState({
            data:
                this.state.data.map(
                    obj => obj.id == id ?
                        {...obj, 'speed': speed} :
                        obj)
                })
    }

    render() {
        return (
            <div className="data-table">
                <h2>Class component</h2>
                <div className="head">
                    <span className="head">id</span>
                    <span className="head">name</span>
                    <span className="head">type</span>
                    <span className="head">speed</span>
                    <span className="head">weapon</span>
                    <span className="head">health</span>
                    <span className="head">popularity</span>
                </div>
                {
                    this.state.data.map(
                        br => (
                            <div className="brawler" key={br.id}>
                                <span className="data">{br.id}</span>
                                <span className="data">{br.name}</span>
                                <span className="data">{br.type}</span>
                                <input className="data" placeholder="speed" value={br.speed} onChange={event => this.onChangeSpeed(event, br.id)}/>
                                <span className="data">{br.weapon}</span>
                                <span className="data">{br.health}</span>
                                <progress className="data" max="100" value={br.popularity} title={br.popularity}/>
                            </div>
                        )
                    )
                }
            </div>
        )
    }
}