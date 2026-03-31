using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_1
{
    public class Roles
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;

        public ICollection<Users> Users { get; set; } = new List<Users>();
    }
}
