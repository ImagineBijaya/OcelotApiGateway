using ProductService.Controllers;
using ProductService.Context;
using Microsoft.EntityFrameworkCore;

namespace ProductTest
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public async Task  ProductPricelessthanZeroAsync()
        {
            Product newProduct= new Product();
            newProduct.ProductName = "Nescafe Coffee";
            newProduct.ProductUnit = "kg";
            newProduct.ProductPrice = "1300";
         
            ProductController productController = new ProductController();
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