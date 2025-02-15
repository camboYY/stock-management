using MvcMovie.Models;

namespace MvcMovie.Repositories
{
    public interface IOtherExpenseTypeRepository : IRepository<OtherExpenseType>
    {
        void Update(OtherExpenseType otherExpenseType);
    }
}