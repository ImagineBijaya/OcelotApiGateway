using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Context
{
    public class ProductRepository : IProductRepository
    {
        ProductDbContext _productDbContext;
        public ProductRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }


        public async Task<Product> AddProductAsync(Product product)
        {
            var result =   await _productDbContext.Products.AddAsync(product);
            await _productDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Product> DeleteProductAsync(int Id)
        {
            var result = await _productDbContext.Products
                    .FirstOrDefaultAsync(e => e.ProductId == Id);
            if (result != null)
            {
               _productDbContext.Products.Remove(result);
                await _productDbContext.SaveChangesAsync();
            }
            return result;
        }

        public async Task<Product> GetProductByIdAsync(int Id)

        {
            var result = await _productDbContext.Products
                .FirstOrDefaultAsync(e => e.ProductId == Id);
            return result;
        }

        public async Task<IEnumerable<Product>> GetProductListAsync()
        {
            return await _productDbContext.Products.ToListAsync();
        }

        public async Task<Product> UpdateProductAsync(Product Product)
        {
            var result = await _productDbContext.Products
                .FirstOrDefaultAsync(e => e.ProductId == Product.ProductId);

            if (result != null)
            {
                result.ProductName = Product.ProductName;
                result.ProductUnit = Product.ProductUnit;
                result.ProductPrice = Product.ProductPrice;


                await _productDbContext.SaveChangesAsync();

                return result;
            }

            return null; ;
        }
    }
}

