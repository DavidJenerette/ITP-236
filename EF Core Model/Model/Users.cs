using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserModelApp.Model
{
    [Table("Users")]
    public class Users
    {
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(30)]
        public string? Department { get; set; }

        public List<Roles> Roles { get; set; } = new();
        public List<UserProjects> UserProjects { get; set; } = new();
    }
}