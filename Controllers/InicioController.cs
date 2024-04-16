using Microsoft.AspNetCore.Mvc;
using Proyecto1.Models;
using Proyecto1.Recursos;
using Proyecto1.Servicios.Contrato;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Proyecto1.Controllers
{
    public class InicioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public InicioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrarse(Usuario modelo)
        {
            modelo.Contraseña = Utilidades.EncriptarClave(modelo.Contraseña);
            Usuario usuario_creado = await _usuarioService.SaveUsuarios(modelo);

            if (usuario_creado.Idusuario > 0)
                return RedirectToAction("IniciarSesion", "Inicio");

            ViewData["Mensaje"] = "No se pudo crear el usuario";
            return View();
        }

        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(string Correo, string Contraseña)
        {
            Usuario usuario_encontrado = await _usuarioService.GetUsuarios(Correo, Utilidades.EncriptarClave(Contraseña));

            if (usuario_encontrado == null)
            {
                ViewData["Mensaje"] = "No se encontraron coincidencias";
                return View(); // Otra opción sería redirigir a una vista que muestre el mensaje de error
            }

            List<Claim> claims = new List<Claim>();
            if (!string.IsNullOrEmpty(usuario_encontrado.NombreUsuario)) // Verificación de nulidad para NombreUsuario
            {
                claims.Add(new Claim(ClaimTypes.Name, usuario_encontrado.NombreUsuario));

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties
                );

                return RedirectToAction("index", "Home");
            }
            else
            {
                ViewData["Mensaje"] = "El nombre de usuario no es válido";
                return View(); // Otra opción sería redirigir a una vista que muestre el mensaje de error
            }
        }
    }
}
