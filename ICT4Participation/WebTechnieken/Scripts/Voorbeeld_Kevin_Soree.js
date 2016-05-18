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

function Voorbeeld2_Click() {
    $("#Voorbeeld2_div").animate({ left: '250px' });
}

$(document).ready(function () {
    $("#btnMoveDiv").click(function () {
        $("#Voorbeeld2_div").animate({ left: '250px' });
    });
});