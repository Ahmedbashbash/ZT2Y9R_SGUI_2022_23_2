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
            Coach = y;
            console.log(Coach);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    Coach.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.coachId + "</td><td>" + t.name + "</td><td>" + t.age + "</td><td>" + t.coachHireDate + "</td><td>" + `<button type="button" onclick="remove(${t.coachId})">Delete</button>` + `<button type="button" onclick="showupdate(${t.coachId})">Edit</button>` + "</td></tr>";
        console.log(t.name)
    });
}

function remove(id) {
    fetch('http://localhost:5555/coach/' + id, {
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
    let coachHireDat = document.getElementById('coachHireDate').value;
    fetch('http://localhost:5555/coach', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: nam, age: ag, coachHireDate: coachHireDat })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}