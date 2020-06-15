using BaseFramework.Entity.ProjectBaseEntity;
using BaseFramework.Model.ProjectBaseDTO;
using BaseFrameWork.Core.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.MapConfig.MapperProfile
{ //automapper eklendi
    public class UserProfile : ProfileBase 
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();  //USER gelirse Userdto çevir ve userdto gelirse usera çevir

            //user ve userdto daki kolonlar(propertyler) farklı olursa manuel olarak tek tek böyle yapmamız lazım
            //CreateMap<User, UserDTO>().ForMember(dtomem => dtomem.Id, entmem => entmem.MapFrom(z => z.Id);
        }
    }
}
