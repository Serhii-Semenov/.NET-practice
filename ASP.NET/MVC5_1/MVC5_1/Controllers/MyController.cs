using System.Web.Mvc;
using System.Web.Routing;

/*
    Теперь создадим какой-нибудь простенький контроллер, реализующий данный интерфейс.
    В качестве проекта мы можем взять проект из предыдущий главы.
    Итак, добавим в папку Controllers проекта новый класс 
        (именно класс, а не контроллер) со следующим содержанием:
*/

namespace MVC5_1.Controllers
{
    // Обращение к конртоллеру происходит по имени Контроллера без суфикса /Controller/ т.е. - /My/ 
    public class MyController : IController
    {
        public void Execute(RequestContext requestContext)
        {
            string ip = requestContext.HttpContext.Request.UserHostAddress;
            var response = requestContext.HttpContext.Response;
            response.Write("<h2>Ваш IP-адрес: " + ip + "</h2>");
        }
    }
}

/*
 * При обращении к любому контроллеру система передает в него контекст запроса. 
 * В этот контекст запроса включается все: куки, отправленные данные форм, строки запроса, 
 * идентификационные данные пользователя и т.д. 
 * Реализация интерфейса IController позволяет получить этот контекст запроса в методе 
 * Execute через параметр RequestContext. 
 * В нашем случае мы получаем IP-адрес пользователя 
 * через свойство requestContext.HttpContext.Request.UserHostAddress.

Кроме того, мы можем отправить пользователю ответ с помощью объекта Response и его метода Write.
Таким образом, перейдя по пути адрес_сайта/My/, пользователь увидит свой ip-адрес.
*/