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

    render() {
        return (
            <div className="data-table">
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
                        (br, ix) => (
                            <div className="brawler" key={ix}>
                                <span className="data">{br.id}</span>
                                <span className="data">{br.name}</span>
                                <span className="data">{br.type}</span>
                                <span className="data">{br.speed}</span>
                                <span className="data">{br.weapon}</span>
                                <span className="data">{br.health}</span>
                                <span className="data">{br.popularity}</span>
                            </div>
                        )
                    )
                }
            </div>
        )
    }
}