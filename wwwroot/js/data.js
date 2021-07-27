const uri = 'api/Data';
let dataObjects = [];
const onPage = 2;
const tBody = document.getElementById('data_objects');

function getItems() {
    const codeTextbox = document.getElementById('data_code');
    const valueTextbox = document.getElementById('data_value');

    let code = codeTextbox.value.trim();
    let value = valueTextbox.value.trim();

    fetch(`${uri}/?code=${code}&value=${value}`)
        .then(response => response.json())
        .then(data => {  dataObjects = data; displayGridAndButtons(); })
        .catch(error => console.error('Unable to get items.', error));
}

function postThreeData() {
    const arr = [
        {"code":"1", "value":"1"},
        {"code":"5", "value":"5"},
        {"code":"10", "value":"32"}
    ]

    fetch(uri, {
        method: "POST",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(arr)
    })//.then(response => response.json())
    .then(() =>  getItems())
    .catch(error => console.error('Unable to post 3 items.', error));
}

function displayGridAndButtons() {
    const buttons = document.querySelector('#buttons')
    buttons.innerHTML = "";
    tBody.innerHTML = "";
    
    for (let i = 0; i < Math.ceil(dataObjects.length/onPage ); i++) {
        buttons.innerHTML += `<button class="btn-pag" data-from=${i * onPage} data-to=${i * onPage + onPage}>${i + 1}</button>`
    }
        
    for (let i = 0; i < onPage ; i++) {
        if(dataObjects[i] != null)
            renderTr(dataObjects, i);
    }
}

function displayTbody(data) {
    tBody.innerHTML = ""

    for (let i = 0; i < data.length; i++) {
        renderTr(data, i);
    }
}

function renderTr(data, i) {
    let tr = tBody.insertRow();

    let td1 = tr.insertCell(0);
    td1.appendChild(document.createTextNode(data[i].id));

    let td2 = tr.insertCell(1);
    td2.appendChild(document.createTextNode(data[i].code));

    let td3 = tr.insertCell(2);
    let textNode = document.createTextNode(data[i].value);
    td3.appendChild(textNode);
}

document.body.addEventListener('click', e => {
    if (!e.target.matches('.btn-pag')) return;

    const from = e.target.dataset.from;
    const to = e.target.dataset.to;
    const sliced = dataObjects.slice(from, to);

    displayTbody(sliced);
})
