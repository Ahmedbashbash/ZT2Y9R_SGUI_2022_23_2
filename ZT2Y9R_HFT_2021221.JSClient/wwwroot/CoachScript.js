let Coach = [];
let connection = null;
getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:5555/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("CoachCreated", (user, message) => {
        getdata();
    });

    connection.on("CoachDeleted", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();


}

async function getdata() {
    await fetch('http://localhost:5555/Coach')
        .then(x => x.json())
        .then(y => {
            BusinessManager = y;
            console.log(BusinessManager);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    BusinessManager.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.CoachId + "</td><td>"
            + t.name + "</td><td>" +
            `<button type="button" onclick="remove(${t.BusinessManagerId})">Delete</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:5555/Coach' + id, {
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
    let name = document.getElementById('name').value;
    fetch('http://localhost:5555/BusinessManager', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}