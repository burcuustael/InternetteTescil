using InternetteTescil.Data.Abstract;
using InternetteTescil.Data.Concrete;
using InternetteTescil.Entities.Entities;

namespace InternetteTescil.Service.Concrete
{
    public class CostumerService : CostumerRepository, ICostumerRepository
    {
        public CostumerService(InternetTescilContext _context) : base(_context)
        {
        }
    }
}
