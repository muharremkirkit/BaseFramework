using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Entity.ProjectBaseEntity
{
    public class User
    {
        public User()
        {
            Roles = new HashSet<Role>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string  Mail { get; set; }
        public Nullable<bool> Sex { get; set; }
        public string Location { get; set; }
        public string Browser { get; set; }
        public string IP { get; set; }
        public Nullable<bool> IsActive { get; set; }

        public virtual ICollection<Role> Roles { get; set; } //VİRTUAL yazınca constructurda override ediyoruz
    }
}
