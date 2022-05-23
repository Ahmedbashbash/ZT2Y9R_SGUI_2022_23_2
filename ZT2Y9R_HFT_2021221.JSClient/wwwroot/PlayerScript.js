let Player = [];
let connection = null;
getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:5555/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("PlayerCreated", (user, message) => {
        getdata();
    });

    connection.on("PlayerDeleted", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();


}

async function getdata() {
    await fetch('http://localhost:5555/player')
        .then(x => x.json())
        .then(y => {
            Player = y;
            console.log(Player);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    Player.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.playerId + "</td><td>" + t.name + "</td><td>" + t.age + "</td><td>" + t.position + "</td><td>" + t.playerSalary + "</td><td>" + `<button type="button" onclick="remove(${t.playerId})">Delete</button>` + `<button type="button" onclick="showupdate(${t.playerId})">Edit</button>` + "</td></tr>";
        console.log(t.name)
    });
}

function remove(id) {
    fetch('http://localhost:5555/player/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function create() {
    let nam = document.getElementById('name').value;
    let ag = document.getElementById('age').value;
    let postio = document.getElementById('position').value;
    let salar = document.getElementById('salary').value;
    fetch('http://localhost:5555/player', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: name, age:ag, postion:postio, salary:salar })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}