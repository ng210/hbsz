import { useState, useEffect } from 'react'

export default function DataTableFn({url}) {
    const [userData, setUserData] = useState([])

    useEffect(
        () => {
            fetch(url+'brawler')
            .then(resp => resp.json())
            .then(content => setUserData(content))
            .catch(err => alert('Hiba: '+err.message))
        },
        [])

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
                userData.map(
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
