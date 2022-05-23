let Coach = [];
let connection = null;
getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:5555/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("BusinessManagerCreated", (user, message) => {
        getdata();
    });

    connection.on("BusinessManagerDeleted", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();


}

async function getdata() {
    await fetch('http://localhost:5555/businessManager')
        .then(x => x.json())
        .then(y => {
            Coach = y;
            console.log(Coach);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    Coach.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.businessManagerId + "</td><td>" + t.name + "</td><td>" + t.age + "</td><td>" + t.salary + "</td><td>" + `<button type="button" onclick="remove(${t.businessManagerId})">Delete</button>` + `<button type="button" onclick="showupdate(${t.businessManagerId})">Edit</button>` + "</td></tr>";
        console.log(t.name)
    });
}

function remove(id) {
    fetch('http://localhost:5555/businessManager/' + id, {
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
    let ame = document.getElementById('name').value;
    let ag = document.getElementById('age').value;
    let salar = document.getElementById('salary').value;
    fetch('http://localhost:5555/businessManager', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: ame, age: ag, salary: salar})
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}