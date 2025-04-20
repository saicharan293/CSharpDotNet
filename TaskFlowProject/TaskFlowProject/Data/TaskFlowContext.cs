using Microsoft.EntityFrameworkCore;
using TaskFlowProject.Models;

namespace TaskFlowProject.Data
{
    public class TaskFlowContext : DbContext
    {
        public TaskFlowContext(DbContextOptions<TaskFlowContext> options):base(options)
        {
            
        }

        public DbSet<TaskItemModel> Tasks { get; set; }
    }
}
