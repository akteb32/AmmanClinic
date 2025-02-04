using AmmanClinic.Models;
using AmmanClinic.Services;
using Microsoft.AspNetCore.Mvc;

namespace AmmanClinic.Controllers
{
    public class AccountController : Controller
    {
        IAccountService accountService;
        public AccountController(IAccountService _accountService)
        {
            accountService = _accountService;
        }
        public IActionResult CreateAccount()
        {
            return View("CreateAccount");
        }

        public async Task<IActionResult> SignUp(SignUpDTO signUp)
        {

            var result = await accountService.CreateAccount(signUp);
            ViewData["Msg"] = result;
            return View("CreateAccount");
        }

        public IActionResult SignIn()
        {
            return View("SignIn");
        }

        public async Task<IActionResult> Login(SignInDTO DTO)
        {
            var result = await accountService.SignIn(DTO);
            if (result.Succeeded == true)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ViewData["err"] = "Invalid username or password";
                return View("SignIn");
            }
        }

        public IActionResult NewRole()
        {
            return View("NewRole");
        }

        public async Task<IActionResult> SaveRole(RoleDTO dto)
        {
            var result = await accountService.CreateRole(dto);

            return View("NewRole");
        }

        public async Task<IActionResult> UserList()
        {
            List<UserDTO> users = await accountService.GetUsers();
            return View("UserList", users);
        }

        public async Task<IActionResult> UserRole(string UserId)
        {
            List<UserRolesDTO> userRoles = await accountService.GetRoles(UserId);
            return View("UserRole", userRoles);
        }

        public async Task<IActionResult> UpdateRole(List<UserRolesDTO> userRoles)
        {
            await accountService.UpdateUserRoles(userRoles);
            userRoles = await accountService.GetRoles(userRoles[0].UserId);
            return View("UserRole", userRoles);
        }

        public IActionResult AccessDenied()
        {
            return View("AccessDenied");
        }

        public async Task<IActionResult> Logout()
        {
            await accountService.Logout();
            return RedirectToAction("SignIn");
        }
    }
}
