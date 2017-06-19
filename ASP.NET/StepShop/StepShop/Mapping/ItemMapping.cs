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
        public static ItemModelView ItemModelToItemModelView(Item it)
        {
            return new ItemModelView() { 
                 CategoryType = it.CategoryTypeId,
                  Id = it.Id, 
                   Name = it.Name,
                    Price = it.Price
            };
        }

        public static IEnumerable<ItemModelView> ItemModelToItemModelViews(IEnumerable<Item> it)
        {
            return it.Select(ItemModelToItemModelView);
        }

        public static Item ToItem(NewViewModel nvm)
        {
            return new Item()
            {
                CategoryTypeId = nvm.CategoryType,
                Description = nvm.Description,
                ItemImages = nvm.Images,
                Name = nvm.Name,
                Price = nvm.Price
            };
        }

    }
}
