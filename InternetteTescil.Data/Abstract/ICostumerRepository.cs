using InternetteTescil.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetteTescil.Data.Abstract
{
    public interface ICostumerRepository : IRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetAllCostumerByOrdersAsync();
    }
}
