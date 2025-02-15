using MvcMovie.Models;

namespace MvcMovie.Repositories
{
    public interface IOtherIncomeTypeRepository : IRepository<OtherIncomeType>
    {
        void Update(OtherIncomeType otherIncomeType);
    }
}