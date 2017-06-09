using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// Создадим еще один класс результатов. Добавим в папку Util новый класс ImageResult:
namespace MVC5_1.Util
{
    public class ImageResult : ActionResult
    {
        private string path;
        public ImageResult(string path)
        {
            this.path = path;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.Write("<div style='width:100%;text-align:center;'>" +
                "<img style='max-width:600px;' src='" + path + "' /></div>");
        }
    }
}

// Данный класс не сложнее предыдущего и просто отдает изображение к html-коде.
// Тогда метод, использующий данный результат действий, мог бы выглядеть так:
    //public ActionResult GetImage()
    //{
    //    string path = "../Images/visualstudio.png";
    //    return new ImageResult(path);
    //}
// Здесь предполагается, что в проекте есть папка Images, 
// в которой имеется изображение visualstudio.png.И тогда, 
// если мы в браузере обратимся к этому действию, например, Home/GetImage, 
// то сможем увидеть изображение.