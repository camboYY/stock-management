using MvcMovie.Models;

namespace MvcMovie.Repositories;

public interface IWarehouseRepository : IRepository<Warehouse>
{

    public void Update(Warehouse warehouse);
}