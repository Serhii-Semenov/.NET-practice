using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StepShop.Validation
{
    public class MyPriceValid : ValidationAttribute
    {
        // проверка на не валидные значения
        private static int[] noValidPrice;

        public MyPriceValid(int[] price)
        {
            noValidPrice = price;
        }

        public override bool IsValid(object value)
        {
            if (value != null)
            {
                int val = (int)value;
                foreach(int i in noValidPrice)
                {
                    if (val == i) return false;
                }
            }
            return true;
        }
    }
}