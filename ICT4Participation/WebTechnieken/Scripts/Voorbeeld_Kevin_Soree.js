function Voorbeeld1_Click() {
    x = 1;
    setInterval(change, 1000);
}

function change() {
    if (x === 1) {
        document.getElementById("voorbeeld_navbar").style.backgroundColor = "red";
        x = 2;
    } else {
        document.getElementById("voorbeeld_navbar").style.backgroundColor = "green";
        x = 1;
    }
}