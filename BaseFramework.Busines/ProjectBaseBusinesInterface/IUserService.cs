using BaseFramework.Model.ProjectBaseDTO;
using BaseFrameWork.Core.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.ProjectBaseBusinesInterface
{
   public interface IUserService : IServiceBase
    {
        List<UserDTO> getAll();
        UserDTO newUser(UserDTO user);

        UserDTO UpdateUser(UserDTO user);
        bool deleteUser(int userId);
        UserDTO getUser(int Id);

    }
}
