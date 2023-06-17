using Dapper;
using SupplySustainEvaluation.Chitsaz.Common;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        ISqlUtility _sqlUtility;
        public GenericRepository(ISqlUtility sqlUtility)
        {
            this._sqlUtility = sqlUtility;
        }


        public async Task<List<T>> GetAllAsync(string qry)
        {
            using (IDbConnection dapper = _sqlUtility.GetNewConnection())
            {
                var result = await dapper.QueryAsync<T>(qry, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }


        public async Task InsertAsync(string qry, Dictionary<string, object> dictionary)
        {
            using (IDbConnection dapper = _sqlUtility.GetNewConnection())
            {
                await dapper.ExecuteAsync(qry, new DynamicParameters(dictionary), commandType: CommandType.StoredProcedure);
            }
        }


        public async Task DeleteAsync(string qry, int id, string IdParameter)
        {
            using (IDbConnection dapper = _sqlUtility.GetNewConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add(IdParameter, id);
                await dapper.ExecuteAsync(qry, parameters, commandType: CommandType.StoredProcedure);
            }
        }

    }
}
