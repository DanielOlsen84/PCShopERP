var selChassi = document.getElementById("ChassiSelect");
var selCPU = document.getElementById("CPUSelect");
var selGPU = document.getElementById("GPUSelect");
var selHDD = document.getElementById("HDDSelect");
var selMotherboard = document.getElementById("MotherboardSelect");
var selPSU = document.getElementById("PSUSelect");
var selRAM = document.getElementById("RAMSelect");

var totalPrice = 0;
var totalPriceText = document.getElementById("TotalPrice");

UpdateTotalPrice();

selChassi.addEventListener("change", function (e) {
    UpdateTotalPrice()
})

selCPU.addEventListener("change", function (e) {
    UpdateTotalPrice()
})

selGPU.addEventListener("change", function (e) {
    UpdateTotalPrice()
})

selHDD.addEventListener("change", function (e) {
    UpdateTotalPrice()
})

selMotherboard.addEventListener("change", function (e) {
    UpdateTotalPrice()
})

selPSU.addEventListener("change", function (e) {
    UpdateTotalPrice()
})

selRAM.addEventListener("change", function (e) {
    UpdateTotalPrice()
})

function UpdateTotalPrice() {

    totalPrice = 0;

    let text = selChassi.options[selChassi.selectedIndex].text;

    totalPrice = totalPrice + parseInt(text.substring(text.indexOf("[") + 1, text.length - 3));

    text = selCPU.options[selCPU.selectedIndex].text;

    totalPrice = totalPrice + parseInt(text.substring(text.indexOf("[") + 1, text.length - 3));

    text = selGPU.options[selGPU.selectedIndex].text;

    totalPrice = totalPrice + parseInt(text.substring(text.indexOf("[") + 1, text.length - 3));

    text = selHDD.options[selHDD.selectedIndex].text;

    totalPrice = totalPrice + parseInt(text.substring(text.indexOf("[") + 1, text.length - 3));

    text = selMotherboard.options[selMotherboard.selectedIndex].text;

    totalPrice = totalPrice + parseInt(text.substring(text.indexOf("[") + 1, text.length - 3));

    text = selPSU.options[selPSU.selectedIndex].text;

    totalPrice = totalPrice + parseInt(text.substring(text.indexOf("[") + 1, text.length - 3));

    text = selRAM.options[selRAM.selectedIndex].text;

    totalPrice = totalPrice + parseInt(text.substring(text.indexOf("[") + 1, text.length - 3));


    totalPriceText.innerHTML = "Total price: " + totalPrice + ":-";
}
