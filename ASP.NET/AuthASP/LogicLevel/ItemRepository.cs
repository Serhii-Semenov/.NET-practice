
using DataLevel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LogicLevel
{
    public class ItemRepository
    {
        public async Task<List<Item>> GetAllItem()
        {
            using (ShopEntities1 entities = new ShopEntities1())
            {
                return await entities.Items.ToListAsync();
            }
        } 
    }
}
