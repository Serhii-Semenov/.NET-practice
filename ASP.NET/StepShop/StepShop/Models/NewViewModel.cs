using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StepShop.Models
{
    public class NewViewModel
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int CategoryType { get; set; }
        public string Description { get; set; }
        public List<ItemImage> Images { get; set; }
    }
}