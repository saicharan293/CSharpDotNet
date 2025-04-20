using System.ComponentModel.DataAnnotations;

namespace TaskFlowProject.Models
{
    public class TaskItemModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        [Required]
        public string AssignedTo { get; set; }
        public string Status { get; set; } = "Submitted";
        public string Priority { get; set; } = "Medium";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? DueDate { get; set; }
        public DateTime? CompletedAt { get; set; }


    }
}
