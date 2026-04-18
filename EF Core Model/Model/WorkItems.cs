using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserModelApp.Model
{
    [Table("WorkItems")]
    public class WorkItems
    {
        public int WorkItemId { get; set; }

        [Required]
        [MaxLength(75)]
        public string Title { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }

        public int ProjectId { get; set; }
        public Projects Project { get; set; } = null!;
    }
}