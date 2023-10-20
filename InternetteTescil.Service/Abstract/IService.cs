

using InternetteTescil.Data.Abstract;

namespace InternetteTescil.Service.Abstract
{
    public interface IService<T> : IRepository<T> where T : class, new()
    {

    }
}
