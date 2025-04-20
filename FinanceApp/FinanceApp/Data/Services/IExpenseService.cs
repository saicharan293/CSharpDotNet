using FinanceApp.Models;

namespace FinanceApp.Data.Services
{
    public interface IExpenseService
    {
        Task<IEnumerable<Expense>> GetAll();

        Task Add(Expense expense);

        IQueryable GetChartData();

        Task<Expense> Edit(int? id);

        Task Update(Expense expense);

        Task Delete(int? id);

    }
}
