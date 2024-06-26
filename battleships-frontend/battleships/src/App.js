import { HubConnectionBuilder } from '@microsoft/signalr';
import './App.css';
import Lobby from './Lobby';

function App() {
  let connection = new HubConnectionBuilder()
  .withUrl("https://localhost:7001/data")
  .build();

  connection.start().then(function () {
    console.log('Connected!');
  });

  return (
    <div className="App">
      <Lobby />
    </div>
  );
}

export default App;
