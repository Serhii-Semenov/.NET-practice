using Mapper.Model;
using Mapper.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.UnitOfWork
{
    interface IUnitOfWork : IDisposable
    {
        IRepository<Item> Items { get; }
        IRepository<Phone> Phones { get; }

        void Save();
    }
}
