using BaseFramework.Busines.ProjectBaseBusinesInterface;
using BaseFramework.Entity.ProjectBaseEntity;
using BaseFramework.Model.ProjectBaseDTO;
using BaseFrameWork.Core.Data.UnitOfWork;
using BaseFrameWork.Core.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.ProjectBaseBusinesService
{ //referanslara automapper yüklendi,eklendi
    public class UserService : IUserService
    {
        private readonly IUnıtofWork uow;
        public UserService(IUnıtofWork uow)
        {
            this.uow = uow;
        }

        public bool deleteUser(int userId)
        {
            try
            {
                var getUser = uow.GetRepository<User>().Get(z=>z.Id==userId); //unıt of workrtan userı al
                uow.GetRepository<User>().Delete(getUser); //sil
                uow.SaveChanges(); 
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<UserDTO> getAll() //Unıtofwork a gidip getrepository getiriyoruz //Irepositoryden get veya getall metodunu alıyoruz
        {
            var getUserList = uow.GetRepository<User>().Get(null, null, null).ToList();
            //return new List<UserDTO>();
            return MapperFactory.CurrentMapper.Map<List<UserDTO>>(getUserList);
            //uı dan gelen useru  base e entity olarak göndermek için userdto dönüştürüyoruz

        }

        public UserDTO getUser(int Id)
        {
            var getUser = uow.GetRepository<User>().Get(z => z.Id == Id);//unıt of workten user getir
            return MapperFactory.CurrentMapper.Map<UserDTO>(getUser);
        }

        public UserDTO newUser(UserDTO user)
        {
            if (user.Validate())
            {
                if (!uow.GetRepository<User>().GetAll().Any(z=>z.Mail == user.Mail || z.UserName == user.UserName )) //unıt of worktan user i getir. eğer kullanıcı adı ve şifresi yoksa getirme !
                {
                    var adedUser = MapperFactory.CurrentMapper.Map<User>(user); //bize gelen DtoUser'ı user'a çevirdik 
                    adedUser = uow.GetRepository<User>().Add(adedUser); //unt of work taki useri instance edip ekliyor
                    List<Role> roleList = MapperFactory.CurrentMapper.Map<List<Role>>(user.RoleList); //user ın rollerini oluşturuyor
                    adedUser.Roles = roleList; //rolleri ekliyor
                    uow.SaveChanges();
                    return MapperFactory.CurrentMapper.Map<UserDTO>(adedUser); //geriyo dto döndürüyor
                }
            }
            return null; 
        }

        public UserDTO UpdateUser(UserDTO user)
        {
            if (user.Validate())
            {
                var selectedUser = uow.GetRepository<User>().Get(z => z.Id == user.Id); //unit of worktan seçilen user al
                selectedUser = MapperFactory.CurrentMapper.Map(user, selectedUser);
                uow.GetRepository<User>().Update(selectedUser);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<UserDTO>(selectedUser);
            }
            return null;
        }

        
    }
}
