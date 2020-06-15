using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.ProjectBaseDTO
{  //DATA TRANSFER OBJECT(DTO)
    public class UserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public bool Sex { get; set; }
        public string Location { get; set; }
        public string Browser { get; set; }
        public string IP { get; set; }
        public bool IsActive { get; set; }
        public List<RoleDTO> RoleList { get; set; }

        public bool Validate()
        {
            if (!string.IsNullOrEmpty(UserName) &&
                !string.IsNullOrEmpty(Mail) &&
                !string.IsNullOrEmpty(Password)) return true;
            return false;
        }
    }
}
