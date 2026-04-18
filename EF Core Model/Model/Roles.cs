using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserModelApp.Model
{
    [Table("Roles")]
    public class Roles
    {
        public int RoleId { get; set; }

        [Required]
        [MaxLength(35)]
        public string RoleName { get; set; } = string.Empty;

        public List<Users> Users { get; set; } = new();
    }
}