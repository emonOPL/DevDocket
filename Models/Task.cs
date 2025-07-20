using System.ComponentModel.DataAnnotations;

namespace DevDocket.Models
{
    public class Task
    {
        public int Id { get; set; } 

        [Required]
        [StringLength(50)] 
        public string Title { get; set; }

        [Required]
        public string Details { get; set; } 

        [StringLength(50)] 
        public string TechTag { get; set; }

        [Required]
        [Range(1, 4)] // 1=Low, 2=Medium, 3=High, 4=Urgent
        public int Priority { get; set; }

        [Required]
        public DateTime Deadline { get; set; }

        [Required]
        [Range(1, 3)] // 1=Assigned, 2=Ongoing, 3=Completed
        public int Status { get; set; }
    }
}
