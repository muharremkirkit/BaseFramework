using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Entity.ProjectBaseEntity
{
    public class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
            Pages = new HashSet<Page>();
            PageEvents = new HashSet<PageEvent>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsActive { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Page> Pages { get; set; }
        public virtual ICollection<PageEvent> PageEvents { get; set; }
    }
}
