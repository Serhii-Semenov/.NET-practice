using System.Web.Mvc;


// Создадим свои результаты действий. Они будут очень простыми. 
// Возьмем какой-нибудь проект, например, из прошлой главы, 
// и добавим в него новую папку Util, которая будет содержать новые классы. 
// После добавления папки добавим в нее первый класс. Назовем его HtmlResult. 
// Он у нас будет содержать следующий код: 

namespace MVC5_1.Util
{
    public class HtmlResult : ActionResult
    {
        private string htmlCode;
        public HtmlResult(string html)
        {
            htmlCode = html;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            string fullHtmlCode = "<!DOCTYPE html><html><head>";
            fullHtmlCode += "<title>Главная страница</title>";
            fullHtmlCode += "<meta charset=utf-8 />";
            fullHtmlCode += "</head> <body>";
            fullHtmlCode += htmlCode;
            fullHtmlCode += "</body></html>";
            context.HttpContext.Response.Write(fullHtmlCode);
        }
    }
    // В конструкторе класса HtmlResult получаем переданный html-код, 
    // а в методе Execute вставляем его в общее окружение, 
    // чтобы получилась полноценная html-страница, 
    // и пишем ее в выходной поток: context.HttpContext.Response.Write(fullHtmlCode);
}