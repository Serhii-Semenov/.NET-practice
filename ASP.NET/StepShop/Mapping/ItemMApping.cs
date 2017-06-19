using StepShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping
{
    public static class ItemMapping
    {
        public static ItemModelView ItemModelViewToItemModelView(Item it)
        {
            return new ItemModelView() { 
                 CategoryType = it.CategoryTypeId,
                  Id = it.Id, 
                   Name = it.Name,
                    Price = it.Price
            };
        }
    }
}
