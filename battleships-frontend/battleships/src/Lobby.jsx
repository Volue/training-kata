import { useEffect, useState } from "react";

function Lobby () {
    const [games, setGames] = useState([]);

    useEffect(() => {
        const getGames = async () => {
            const response = await fetch("https://localhost:7001/api/game/list");
            const result = await response.json();
    
            return result;
        };

        getGames().then(result => {
            setGames(result);
        });
    }, []);


    return (
        <div>
            <h1>Lobby</h1>
            <ul>
                {games.map((game, index) => (
                    <li key={index}>
                        {game}
                    </li>
                ))}
            </ul>
        </div>
    )
}

export default Lobby;