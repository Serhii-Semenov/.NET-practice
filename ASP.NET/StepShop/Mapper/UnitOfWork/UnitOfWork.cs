using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapper.Model;
using Mapper.Repositories;

namespace Mapper.UnitOfWork
{
    class UnitOfWork : IUnitOfWork
    {
        private ShopEntities db = new ShopEntities();
        private ItemRepository itemRepo;
        private PhoneRepository phoneRepo;

        private bool disposed = false;

        public IRepository<Item> Items
        {
            get
            {
                if (itemRepo == null) itemRepo = new ItemRepository(db);
                return itemRepo; 
            }
        }

        public IRepository<Phone> Phones
        {
            get
            {
                if (phoneRepo == null) phoneRepo = new PhoneRepository(db);
                return phoneRepo;  
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
