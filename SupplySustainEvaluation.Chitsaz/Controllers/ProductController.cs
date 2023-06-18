using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SupplySustainEvaluation.Chitsaz.Models;
using SupplySustainEvaluation.Chitsaz.Services;
using System.Threading.Tasks;

namespace SupplySustainEvaluation.Chitsaz.Controllers
{
    public class ProductController : BaseController
    {

        IProductService _service;
        public ProductController(IProductService service)
        {
            this._service = service;
        }


        /// <summary>
        /// Show all the products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }


        /// <summary>
        /// Add a new product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(Product model)
        {
          
            await _service.InsertAsync(model);
            return Ok("The product has been successfully created");
        }

       
        /// <summary>
        /// Delete a product 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")] 
        public async Task<IActionResult> Delete(int id)
        {          
            await _service.DeleteAsync(id);
            return Ok("The product has been successfully removed");
        }

    }
}
