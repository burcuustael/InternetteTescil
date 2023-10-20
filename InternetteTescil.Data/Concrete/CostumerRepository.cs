using InternetteTescil.Data.Abstract;
using InternetteTescil.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetteTescil.Data.Concrete
{
    public class CostumerRepository : Repository<Costumer>, ICostumerRepository
    {
        public CostumerRepository(InternetTescilContext _context) : base(_context)
        {
        }

        public async Task<IEnumerable<Costumer>> GetAllCostumerByOrdersAsync()
        {
            return await context.Costumers.Include(c=>c.Orders).ToListAsync();
        }
    }
}
