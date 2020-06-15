using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.ProjectBaseDTO
{
    class RoleEventDTO
    {
        public int Id { get; set; }
        public int RolId { get; set; }
        public int PageEventId { get; set; }
        public PageEventDTO PageEvent { get; set; }
        public RoleDTO Role { get; set; }     
    }
}
