using InternetteTescil.Data.Concrete;
using InternetteTescil.Entities.Entities;
using InternetteTescil.Service.Abstract;

namespace InternetteTescil.Service.Concrete
{
    public class CostumerService : CostumerRepository, ICostumerService
    {
        public CostumerService(InternetTescilContext _context) : base(_context)
        {
        }
    }
}
