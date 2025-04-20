using FinanceApp.Data.Services;
using FinanceApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinanceApp.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpenseService context;

        public ExpensesController(IExpenseService context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var expenses = await context.GetAll();
            return View(expenses);
        }

        public async Task<IActionResult> Create(int? id)
        {
            if(id == null)
            {
                ViewBag.flag = "Add";
                ViewBag.submit = "Submit";
                return View();
            }
            var expense = await context.Edit(id);
            ViewBag.flag = "Edit";
            ViewBag.submit = "Update";
            return View(expense);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                if(expense.Id == 0)
                {
                    await context.Add(expense);
                }
                else
                {
                    await context.Update(expense);
                }
                return RedirectToAction("Index");
            }

            return View(expense);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            await context.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult getChart()
        {
            var data = context.GetChartData();
            return Json(data);
        }

    }
}
