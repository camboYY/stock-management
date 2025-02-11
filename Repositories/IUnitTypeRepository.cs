using MvcMovie.Models;

namespace MvcMovie.Repositories;

public interface IUnitTypeRepository : IRepository<UnitType>
{
    public void Update(UnitType unitType);
}