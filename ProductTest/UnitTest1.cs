using ProductService.Controllers;
using ProductService.Context;
using Microsoft.EntityFrameworkCore;

namespace ProductTest
{
    [TestClass]
    public class ProductTest
    {

        private readonly ProductController productController;
        private readonly IProductRepository productRepository;
        private readonly ProductDbContext productDbContext = new ProductDbContext();
        public ProductTest()
        {
            productRepository = new ProductRepository(productDbContext);
            productController = new ProductController(productRepository);
        }
        [TestMethod]
        public async Task  ProductPricelessthanZeroAsync()
        {
            
            Product newProduct= new Product();
            newProduct.ProductName = "Nescafe Coffee";
            newProduct.ProductUnit = "kg";
            newProduct.ProductPrice = "-1300";

            try
            {
               var result = await productController.AddProductAsync(newProduct);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, "product price is less than zero");
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }
    }
}