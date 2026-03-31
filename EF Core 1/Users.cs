using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_1
{
    public class Users
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Roles> Roles { get; set; } = new List<Roles>();
    }
}
