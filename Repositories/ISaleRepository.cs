using MvcMovie.Models;

namespace MvcMovie.Repositories;

public interface ISaleRepository : IRepository<Sale>
{
    void Update(Sale sale);


}