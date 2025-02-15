using MvcMovie.Models;
using MvcMovie.Repositories;

namespace MvcMovie.Controllers;

public interface ICustomerRepository : IRepository<Customer>
{
    void Update(Customer customer);

}