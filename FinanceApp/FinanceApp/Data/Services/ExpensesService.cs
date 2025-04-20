using FinanceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Data.Services
{
    public class ExpensesService : IExpenseService
    {
        private readonly FinanceAppContext context;

        public ExpensesService(FinanceAppContext context)
        {
            this.context = context;
        }
        public async Task Add(Expense expense)
        {
            context.Add(expense);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            var exp = await context.Expenses.FindAsync(id);
            if (exp != null)
            {
                context.Expenses.Remove(exp);
                await context.SaveChangesAsync();
            }
        }

        public Task<Expense> Edit(int? id)
        {
            return context.Expenses.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Expense>> GetAll()
        {
            var expenses = await context.Expenses.ToListAsync();
            return expenses;
        }

        public IQueryable GetChartData()
        {
            var data = context.Expenses.GroupBy(e => e.Category).Select(g => new
            {
                Category = g.Key,
                total = g.Sum(e => e.Amount),
            });
            return data;
        }

        public async Task Update(Expense expense)
        {
            context.Update(expense);
            await context.SaveChangesAsync();
        }

        
    }
}
