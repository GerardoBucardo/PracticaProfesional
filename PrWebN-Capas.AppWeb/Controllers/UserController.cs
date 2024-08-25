using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrWebN_Capas.BL;
using PrWebN_Capas.EN;
using System.Security.Claims;

namespace PrWebN_Capas.AppWeb.Controllers
{
    public class UserController : Controller
    {
        // GET: UserController
        public async Task<ActionResult> Index()
        {
            var user = await UserBL.GetAll();
            return View(user);
        }

        // GET: UserController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var user = await UserBL.GetById(id);
            return View(user);
        }

        // GET: UserController/Create
        public async Task<ActionResult> Create()
        {
            var roles = await RoleBL.GetAll();
            ViewBag.Roles = roles;
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(User pUser)
        {
            try
            {
                var result = await UserBL.Create(pUser);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var user = await UserBL.GetById(id);
            var roles = await RoleBL.GetAll();
            ViewBag.Roles = roles;
            return View(user);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(User pUser)
        {
            try
            {
                var result = await UserBL.Update(pUser);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var user = await UserBL.GetById(id);
            return View(user);

        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(User pUser)
        {
            try
            {
                var result = await UserBL.Delete(pUser);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Login(string returnUrl)
        {
            ViewBag.Url = returnUrl;
            ViewBag.Error = "";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User pUser, string? pRturnURL = null)
        {
            try
            {
                var user = await UserBL.Login(pUser);
                if (user != null && user.Id > 0 && pUser.UserName == user.UserName)
                {
                    user.Roles = await RoleBL.GetById(user.RoleId);
                    var claims = new[] { new Claim(ClaimTypes.Name, user.UserName), new Claim(ClaimTypes.Role, user.Roles.Name) };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                }
                else
                {
                    throw new Exception("Credenciales incorrectas");
                }
                if (!string.IsNullOrWhiteSpace(pRturnURL))
                {
                    return Redirect(pRturnURL);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {

                ViewBag.Url = pRturnURL;
                ViewBag.Error = ex.Message;
                return View(new User { UserName = pUser.UserName });
            }
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "User");
        }
    }
}
