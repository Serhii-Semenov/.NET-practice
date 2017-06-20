using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StepShop.Models
{
    public class CreatePhoneModel
    {
        public Phone Phone { get; set; } 
        public Item Item { get; set; }
    }
}