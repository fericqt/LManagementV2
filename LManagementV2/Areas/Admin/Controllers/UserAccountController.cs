using LManagement.Data.DBContext;
using LManagement.Data.Repository.IRepository;
using LManagement.Model;
using Microsoft.AspNetCore.Mvc;

namespace LManagementV2.Areas.Admin.Controllers {
    public class UserAccountController : Controller {

        private readonly IUnitOfWork _unitOfWork;

        public UserAccountController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index() {
            return View();
        }
        public IActionResult Login() {
            return View();
        }
        public IActionResult Register() {
            return View();
        }
        [HttpPost]
        [ActionName("Register")]
        public IActionResult RegisterPOST(User user) {
            if (user == null) {
                return View();
            }
            user.Roles = "Admin";
            user.Created = DateTime.Now;
            _unitOfWork.UserRepo.AddToDatabase(user);
            _unitOfWork.Save();

            TempData["success"] = "Account Created Successfully!";
            return RedirectToAction(nameof(Login));
        }
        [HttpPost]
        [ActionName(nameof(Login))]
        public IActionResult LoginPOST(User user) {
            if (user == null) { 
                return View(); 
            }

            var tempData = _unitOfWork.UserRepo.GetBy(c=>c.Username == user.Username && c.Password == user.Password);
            if (tempData == null) {
                TempData["error"] = "Username or Password is incorrect!";
                return RedirectToAction(nameof(Login));
            }

            TempData["success"] = "Credentials Verified";
            return RedirectToAction(nameof(Login));
        }
    }
}
