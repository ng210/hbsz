function print(text) {
    cons.innerText += text;
}

function println(text) {
    print(text); print('\n');
}

async function button_click() {
    // var resp = await fetch('http://localhost:4000/muvesz?id=2', { 'method': 'get' });
    var resp = await fetch('http://localhost:4000/tables', { 'method': 'get' });
    var body = await resp.json();
    if (resp.status == 200) {
        println(JSON.stringify(body));
    } else {
        if (body.error) println(body.error);
    }
    
    
}

window.onload = function() {
    const cons = document.getElementById('cons');
}
