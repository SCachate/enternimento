using filmes.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace filmes.Controllers
{
    public class AcessoController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginModel loginModel, string? returnUrl)
        {
            if (ModelState.IsValid)
            {

                if (loginModel.Usuario == "admin" && loginModel.Senha == "admin")
                {
                    var claims = new List<Claim>();
                    claims.Add(new Claim("Usuario", loginModel.Usuario));
                    claims.Add(new Claim(ClaimTypes.Role, "Usuario"));
                    claims.Add(new Claim(ClaimTypes.Name, loginModel.Usuario));
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(principal));
                    return Redirect(returnUrl ?? "/");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Usuário ou senha inválidos");
                }
            }
            return View(loginModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

    }
}
