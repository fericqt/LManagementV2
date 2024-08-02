using LManagement.Data.DBContext;
using LManagement.Data.Repository.IRepository;
using LManagement.Model;
using LManagement.Utility.IUtilities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LManagementV2.Controllers {
    public class UserAccountController : Controller {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IGuid _uniqueId;

        public UserAccountController(IUnitOfWork unitOfWork, IGuid guid) {
            _unitOfWork = unitOfWork;
            _uniqueId = guid;
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
        public async Task<IActionResult> LoginPOST(User user) {
            if (user == null) {
                return View();
            }

            var tempData = _unitOfWork.UserRepo.GetBy(c => c.Username == user.Username && c.Password == user.Password);
            if (tempData == null) {

                TempData["error"] = _uniqueId.GetGuid();
                return RedirectToAction(nameof(Login));
            }
            var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, tempData.Username),
                    new Claim(ClaimTypes.Role, "Admin")
                };
            TempData["success"] = "Credentials Verified";

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));


            return RedirectToAction("Index", "Home", new {area = "Admin"});
        }
    }
}
