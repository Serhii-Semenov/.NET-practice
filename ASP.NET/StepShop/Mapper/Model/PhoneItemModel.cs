using StepShop.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StepShop.Models
{
    public class PhoneItemModel
    {
        // ***** From Item 
        [HiddenInput(DisplayValue = false)]
        public int ItemId { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(150, MinimumLength = 10, ErrorMessage = "Длина строки должна быть от 10 до 150 символов")]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Range(1, int.MaxValue, ErrorMessage = "Недопустимый значение")]
        [MyPriceValid(new int[]{666, 999}, ErrorMessage="Diablo FOREVER")]
        [Display(Name = "Цена")] 
        public int Price { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Категория")]
        public int CategoryTypeId { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Название")]
        public int MyProperty { get; set; }
        
        // ***** From Phone
        [HiddenInput(DisplayValue = false)]
        public int PhoneId { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Производитель")]
        public int ProducerId { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Range(4, 1024, ErrorMessage = "Недопустимый значение")]
        [RegularExpression(@"(4|8|16|32|64|128|256|512|1024)", ErrorMessage = "Некорректный значение объёма памяти")]
        [Display(Name = "Объём пямяти")]
        public int Capacity { get; set; }

        [Required]
        [Range(80, 500, ErrorMessage = "Недопустимый значение")]
        [Display(Name = "Вес")]
        public int Weight { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Range(typeof(float), "4", "6.5", ErrorMessage = "Недопустимый значение")]
        [Display(Name = "Диагональ экрана")]
        public float Display { get; set; }
    }
}