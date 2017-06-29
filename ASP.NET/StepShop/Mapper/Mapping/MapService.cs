using Mapper.UnitOfWork;

namespace Mapper.Mapping
{
    public class MapService
    {
        IUnitOfWork repo;

        public MapService(IUnitOfWork uow)
        {
            repo = uow;
        }



    }
}
