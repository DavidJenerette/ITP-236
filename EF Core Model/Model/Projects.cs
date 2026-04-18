using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserModelApp.Model
{
    [Table("Projects")]
    public class Projects
    {
        public int ProjectId { get; set; }

        [Required]
        [MaxLength(75)]
        public string ProjectName { get; set; } = string.Empty;

        [Range(200, 80000)]
        public decimal Budget { get; set; }

        public List<UserProjects> UserProjects { get; set; } = new();
        public List<WorkItems> WorkItems { get; set; } = new();
    }
}