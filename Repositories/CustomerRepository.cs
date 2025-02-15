using MvcMovie.Controllers;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Repositories;

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    private MvcMovieContext _db;
    public CustomerRepository(MvcMovieContext mvcMovieContext) : base(mvcMovieContext)
    {
        _db = mvcMovieContext;
    }

    public void Update(Customer customer)
    {
        _db.Update(customer);
    }
}