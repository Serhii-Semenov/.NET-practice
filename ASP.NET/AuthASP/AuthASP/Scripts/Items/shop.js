function GetItems() {
    $.get('ApiItem', '', function (items) {
        alert(items);
        console.log(items);
        var it = JSON.parse(items);
        
        console.log(it); 
    })
}
//* ДЗ Востанновить JSON объекты на клиенте и востановит х на VIEW
