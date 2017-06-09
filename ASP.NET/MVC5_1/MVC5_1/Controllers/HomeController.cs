using MVC5_1.Models;
using MVC5_1.Util;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVC5_1.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        BookContext db = new BookContext();

        public ActionResult Index()
        {
            // получаем из бд все объекты Book
            IEnumerable<Book> books = db.Books;
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.Books = books;
            // возвращаем представление
            return View();
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Purchase purchase)
        {
            // *** // purchase.Date = DateTime.Now;
            purchase.Date = getToday(); // применение private методов
            // добавляем информацию о покупке в базу данных
            db.Purchases.Add(purchase);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return "Спасибо," + purchase.Person + ", за покупку!";
        }

        // Для примера  ***
        // Однако не все методы контроллера являются методами действий.
        // Методы действий всегда имеют модификатор public. 
        // Закрытых приватных методов действий не бывает.
        // Но контроллер может также включать и обычные методы, 
        // которые могут использоваться в вспомогательных целях.
        private DateTime getToday()
        {
            return DateTime.Now;
        }
        // Соответственно мы не можем отправить из браузера запрос Home/getToday/, 
        // потому что метод getToday не является методом действия.

        // ------
        // Кроме того, система маршрутизации позволяет создавать маршруты.
        // Например, по умолчанию в проекте MVC определяется следующий маршрут: 
        //      Контроллер/Метод/id.
        // Последний параметр является опциональным. 
        // И благодаря этому мы можем передать параметр id и так: Home/Buy/2
        // Для примера определим действие, которое будет подсчитывать площадь треугольника:
            //public string Square(int a = 10, int h = 3)
            //{
            //    double s = a * h / 2;
            //    return "<h2>Площадь треугольника с основанием " + a +
            //            " и высотой " + h + " равна " + s + "</h2>";
            //}
        // В этом случае мы можем обратиться к действию, 
        // набрав в адресной строке Home/Square?a=10&h=3, 
        // и приложение выдало бы нам нужный результат.
        // Мы также можем задать для параметров значения по умолчанию: Square(int a=10, int h=3)
        // В этом случае при запросе страницы мы можем указать только один параметр 
        //  или вообще не указывать(Home/Square?h=5).

        // Получение данных из контекста запроса
        // Кроме того, мы можем получить параметры, да и не только параметры, 
        // но и другие данные, связанные с запросом, из объектов контекста запроса.
        // Нам доступны следующие объекты контекста: Request, Response, RoutedData, HttpContext и Server.
        // Объект Request содержит коллекцию Params, которая хранит все параметры, 
        //      переданные в запросы.И мы их можем получить:
        public string Square()
        {
            int a = Int32.Parse(Request.Params["a"]);
            int h = Int32.Parse(Request.Params["h"]);
            double s = a * h / 2;
            return "<h2>Площадь треугольника с основанием " + a + " и высотой " + h + " равна " + s + "</h2>";
        }

        // -----
        // Чтобы использовать - public class HtmlResult : ActionResult
        // подключим в контроллер пространство имен нового класса: using BookStore.Util; 
        // и добавим новый метод:
        public ActionResult GetHtml()
        {
            return new HtmlResult("<h2>Привет мир!</h2>");
        }
        // И обратившись к этому методу из браузера, например, Home/GetHtml, 
        // мы получим html-страничку. Хотя данный пример довольно примитивен, 
        // но в целом он демонстрирует, как работают классы результатов действий.

        // Метод для вывода изображения используя класс ImageResult
        // .../Home/GetImage?img=1
        public ActionResult GetImage(int img)
        {
            string path = "../Images/" + img.ToString() + ".png";
            return new ImageResult(path);
        }
        // Здесь предполагается, что в проекте есть папка Images, 
        // в которой имеется изображение visualstudio.png. 
        // И тогда, если мы в браузере обратимся к этому действию, 
        // например, Home/GetImage, то сможем увидеть изображение.

    }
}