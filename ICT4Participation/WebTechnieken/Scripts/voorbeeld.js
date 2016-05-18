function validateLoginForm() {
    var x = document.forms["form1"]["inputEmail"].value;
    if (x == null || x == "") {
        altert("Email moet ingevuld zijn");
        return false;
    }
}