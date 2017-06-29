using Mapper.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.Repositories
{
    class PhoneRepository : IRepository<Phone>
    {
        private ShopEntities db;

        public PhoneRepository(ShopEntities db)
        {
            this.db = db;
        }

        public void Create(Phone item)
        {
            db.Phones.Add(item);
        }

        public void Delete(int id)
        {
            Item item = db.Items.Find(id);
            if (item != null)
                db.Items.Remove(item);
        }

        public Phone Get(int id)
        {
            return db.Phones.Include(a => a.Item).Include(a => a.Producer).FirstOrDefault(a=>a.Id == id);
        }

        public IEnumerable<Phone> GetAll()
        {
            return db.Phones.Include(a => a.Item).Include(a => a.Producer).ToList();
        }

        public void Update(Phone item)
        {
            db.Entry(item).State = EntityState.Modified;
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
