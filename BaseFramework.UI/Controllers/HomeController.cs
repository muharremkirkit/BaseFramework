using BaseFramework.Busines.ProjectBaseBusinesInterface;
using BaseFramework.Model.ProjectBaseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaseFramework.UI.Controllers
{
    public class HomeController : Controller
    {
        private IUserService service;
        public HomeController(IUserService _userService)
        {
            service = _userService;
        }
        // GET: Home
        public ActionResult Index() //sağ tık addview hiçbir şeyi değiştirmedik bootstrap eklendi.
        {
            List<UserDTO> userList = service.getAll();
            return View();
        }
    }
}