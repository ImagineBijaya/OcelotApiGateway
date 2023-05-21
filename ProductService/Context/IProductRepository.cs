namespace ProductService.Context
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetProductListAsync();
        public Task<Product> GetProductByIdAsync(int Id);
        public Task<Product> AddProductAsync(Product product);
        public Task<Product> UpdateProductAsync(Product product);
        public Task<Product> DeleteProductAsync(int Id);
    }
}
