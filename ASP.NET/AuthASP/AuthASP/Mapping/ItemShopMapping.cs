using AuthASP.Models;
using DataLevel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthASP.Mapping
{
    public static class ItemShopMapping
    {
        public static ShopItem ToShopItem(this Item item)
        {
            return new ShopItem
            {
                Name = item.Name
            };
        }

        public static List<ShopItem> ToShopItems(this IEnumerable<Item> items)
        {
            return items.Select(ToShopItem).ToList();
        }

    }
}