
using InternetteTescil.Data.Concrete;
using InternetteTescil.Entities.Entities;
using InternetteTescil.Service.Abstract;

namespace InternetteTescil.Service.Concrete
{
    public class Service<T> : Repository<T>, IService<T> where T : class, new()
    {
        public Service(InternetTescilContext _context) : base(_context)
        {
        }
    }
}
