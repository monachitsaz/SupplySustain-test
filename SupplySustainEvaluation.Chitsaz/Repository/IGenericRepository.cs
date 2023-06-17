using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
   public interface IGenericRepository<T> where T:class
    {
        public Task<List<T>> GetAllAsync(string qry);

        public Task InsertAsync(string qry, Dictionary<string, object> dictionary);

        public Task DeleteAsync(string qry, int id, string IdParameter);

    }
}
