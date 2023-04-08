String.prototype.turkishtoEnglish = function () {
    return this.replace('Ğ', 'g')
        .replace('Ü', 'u')
        .replace('Ş', 's')
        .replace('I', 'i')
        .replace('İ', 'i')
        .replace('Ö', 'o')
        .replace('Ç', 'c')
        .replace('ğ', 'g')
        .replace('ü', 'u')
        .replace('ş', 's')
        .replace('ı', 'i')
        .replace('ö', 'o')
        .replace('ç', 'c');
};

let btnEmail = document.getElementById("btnEmail");

btnEmail.onclick = function () {
    let ad = document.getElementById("Name").value.turkishtoEnglish().toLowerCase();
    let Ikinciad = document.getElementById("MiddleName").value.turkishtoEnglish().toLowerCase();
    let Soyad = document.getElementById("SurName").value.turkishtoEnglish().toLowerCase();
    let IkinciSoyad = document.getElementById("LastSurName").value.turkishtoEnglish().toLowerCase();
    if (ad === "" || Soyad === "") {
        alert("Lütfen önce adınızı ve soyadınızı girin");
        document.getElementById("Email").value = "";
        return;
    }
    document.getElementById("Email").value = ad + Ikinciad + "." + Soyad + IkinciSoyad + "@bilgeadamboost.com";
}