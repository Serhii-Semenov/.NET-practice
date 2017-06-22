using Mapper.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.Repositories
{
    public class ItemRepository : IRepository<Item>
    {
        private ShopEntities db;
        public ItemRepository()
        {
            db = new ShopEntities();
        }
        public IEnumerable<Item> GetAll()
        {
            return db.Items.ToList();
        }

        public Item Get(int id)
        {
            return db.Items.Find(id);
        }

        public void Create(Item item)
        {
            db.Items.Add(item);
        }

        public void Update(Item item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Item item = db.Items.Find(id);
            if (item != null)
                db.Items.Remove(item);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
