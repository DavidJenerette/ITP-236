using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserModelApp.Model
{
    [Table("UserProjects")]
    public class UserProjects
    {
        public int UserId { get; set; }
        public Users User { get; set; } = null!;

        public int ProjectId { get; set; }
        public Projects Project { get; set; } = null!;

        public DateTime AssignedOn { get; set; }

        [Range(1, 40)]
        public int HoursPerWeek { get; set; }
    }
}