namespace CustomerService.Context
{
    public interface ICustomerRepository
    {
        public Task<IEnumerable<Customer>> GetCustomerListAsync();
        public Task<Customer> GetCustomerByIdAsync(int Id);
        public Task<Customer> AddCustomerAsync(Customer customer);
        public Task<Customer> UpdateCustomerAsync(Customer customer);
        public Task<Customer> DeleteCustomerAsync(int Id);
    }
}
