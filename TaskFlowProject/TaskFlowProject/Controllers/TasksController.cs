using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskFlowProject.Data;
using TaskFlowProject.Models;

namespace TaskFlowProject.Controllers
{
    public class TasksController : Controller
    {
        private readonly TaskFlowContext context;

        public TasksController(TaskFlowContext context)
        {
            this.context = context;
        }


        public async Task<IActionResult> Index()
        {
            var tasks = await context.Tasks.ToListAsync();
            return View(tasks);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskItemModel task)
        {
            if (ModelState.IsValid)
            {
                context.Add(task);
                await context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var task = await context.Tasks.FindAsync(id);
            if (task == null) return NotFound();
            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TaskItemModel task)
        {
            if (ModelState.IsValid)
            {
                context.Update(task);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await context.Tasks.FindAsync(id);
            if (task != null)
            {
                context.Tasks.Remove(task);
                await context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
