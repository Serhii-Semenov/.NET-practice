
$(document).ready(function () {
    $("#button").click(getDate);
});

function getDate() {
    var url = "/api/date"

    // Создание запроса по адресу "/api/date" и вывод ответа в элемент c id="date"
    $.getJSON(url, function (data) {
        $("#date").text(data);
        console.log(data);
    });
}

//function GetItems() {
//    $.get('WebApiItem', '', function (items) {
//        alert(items);
//        console.log(items);
//        var it = JSON.parse(items);
        
//        console.log(it); 
//    })
//}
//* ДЗ Востанновить JSON объекты на клиенте и востановит х на VIEW