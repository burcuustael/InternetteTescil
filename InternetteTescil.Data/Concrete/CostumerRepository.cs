using InternetteTescil.Data.Abstract;
using InternetteTescil.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace InternetteTescil.Data.Concrete
{
    public class CostumerRepository : Repository<Customer>, ICostumerRepository
    {
        public CostumerRepository(InternetTescilContext _context) : base(_context)
        {
        }

        public async Task<IEnumerable<Customer>> GetAllCostumerByOrdersAsync()
        {
            return await context.Customers.Include(c=>c.Orders).ToListAsync();
        }
    }
}
