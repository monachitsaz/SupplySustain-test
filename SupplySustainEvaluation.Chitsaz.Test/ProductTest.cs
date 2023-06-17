using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductService;
using SupplySustainEvaluation.Chitsaz.Controllers;
using SupplySustainEvaluation.Chitsaz.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SupplySustainEvaluation.Chitsaz.Test
{
    public class ProductTest
    {
        Mock<IProductService> _mockService = new Mock<IProductService>();


        private List<Product> GetTestAllProducts()
        {
            return new List<Product>
            {
                new Product{
                  Name="iphone 14",
                  Description="with best quality"
                },
                new Product{
                    Name="iphone 13",
                    Description="it is used"
                },
                  new Product{
                    Name="Nokia",
                    Description="64 gigabite memory"
                },
            };
        }

        private Product GetTestProduct()
        {
            return new Product()
            {
                Name="samsung",
                Description="best quality"
            };
        }


        [Fact]
        public void Create_ProductValid_Returns_OkResult()
        {
            // Arrange
            var newProduct = GetTestProduct();

            // Act
            var controller = new ProductController(_mockService.Object);
            var okResult = controller.Create(newProduct);

            // Assert
            Assert.IsType<OkResult>(okResult);
        }

        [Fact]
        public void Create_ProductInValid_Returns_BadReuest()
        {
            // Arrange
            var newProduct = GetTestProduct();

            // Act
            var controller = new ProductController(_mockService.Object);
            var badRequest = controller.Create(newProduct);

            // Assert
            Assert.IsType<BadRequestResult>(badRequest);

        }


        [Fact]
        public async Task GetAll_WhenCalled_Returns_OkResult()
        {
            // Arrange
            var newProductList = GetTestAllProducts();

            // Act
            var controller = new ProductController(_mockService.Object);
            var okResult =await controller.Index() as OkObjectResult;

            // Assert
            Assert.IsType<OkObjectResult>(okResult);

        }


    }
}
