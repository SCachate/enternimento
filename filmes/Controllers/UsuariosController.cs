using filmes.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using infra.Data;
using Microsoft.EntityFrameworkCore.Internal;

namespace filmes.Controllers
{
    public class UsuariosController : Controller
    {

        private readonly enterterimentoDbContext _context;

        public UsuariosController(enterterimentoDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public ActionResult Index()
        {
            List<UsuariosModel> usuarios = _context.Usuarios.OrderBy(_ => _.Usuario).ToList();
            return View(usuarios);
        }

        [AllowAnonymous]
        public ActionResult Registrar()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Registrar(RegistrarModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuariosModel usuario = new UsuariosModel();
                    usuario.Usuario = model.Usuario;
                    usuario.Nome = model.Nome;
                    usuario.Senha = model.Senha;
                    _context.Usuarios.Add(usuario);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.InnerException.Message);
            }
            return View(model);
        }

        [Authorize]
        public ActionResult Alterar(string usuario)
        {
            var registro = _context.Usuarios.FirstOrDefault(_ => _.Usuario.Equals(usuario));
            var model = new RegistrarModel();
            if (registro != null)
            {
                model.Usuario = registro.Usuario;
                model.Nome = registro.Nome;
            }
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Alterar(RegistrarModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuariosModel usuario = new UsuariosModel();
                    usuario.Usuario = model.Usuario;
                    usuario.Nome = model.Nome;
                    usuario.Senha = model.Senha;
                    _context.Usuarios.Update(usuario);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.InnerException.Message);
            }
            return View(model);
        }

        [Authorize]
        public ActionResult Excluir(string usuario)
        {
            var registro = _context.Usuarios.FirstOrDefault(_ => _.Usuario.Equals(usuario));
            var model = new RegistrarModel();
            if (registro != null)
            {
                model.Usuario = registro.Usuario;
                model.Nome = registro.Nome;
            }
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Excluir(RegistrarModel model)
        {
            try
            {
                UsuariosModel usuario = new UsuariosModel();
                usuario.Usuario = model.Usuario;
                usuario.Nome = model.Nome;
                usuario.Senha = model.Senha;

                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.InnerException.Message);
            }
            return View(model);
        }
    }
}
