using Repository;
using SupplySustainEvaluation.Chitsaz.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ProductService
{
        public interface IProductService : IHelper<Product>
        {     
        }

        public class ProductService : IProductService
        {
            IGenericRepository<Product> repository;
            public ProductService(IGenericRepository<Product> repo)
            {
                this.repository = repo;
            }

            /// <summary>
            /// Get list of products
            /// </summary>
            /// <returns>products</returns>
            public async Task<List<Product>> GetAllAsync()
            {
                var query = "sp_Products_GetAll";
                var result = await repository.GetAllAsync(query);
                return result;
            }

            /// <summary>
            /// Create new product
            /// </summary>
            /// <param name="model"></param>
            /// <returns></returns>
            public async Task InsertAsync(Product model)
            {
                try
                {
                    var query = "[sp_Products_Insert]";
                    var dictionary = new Dictionary<string, object>();
                    dictionary.Add("Id", model.Id);
                    dictionary.Add("Name", model.Name);
                    dictionary.Add("Description", model.Description);
   

                await repository.InsertAsync(query, dictionary);
                }
                catch (SqlException)
                {
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }

            }

            /// <summary>
            /// delete product
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public async Task DeleteAsync(int id)
            {
                try
                {
                    var query = "sp_Products_Delete";
                    await repository.DeleteAsync(query, id, "Id");
                }
                catch (SqlException)
                {
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }
            }

    }
}
