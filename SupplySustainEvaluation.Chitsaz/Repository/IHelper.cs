using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public interface IHelper<T>
    {
        Task<List<T>> GetAllAsync();

        Task InsertAsync(T t);

        Task DeleteAsync(int id);
   
    }
}
