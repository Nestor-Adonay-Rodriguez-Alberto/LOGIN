using Entidades;
using Logica_Negocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace UI_Login.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        // Puente con DB y UI:
        private readonly UsuarioBL _UsuarioBL;

        // Constructor:
        public UsuarioController(UsuarioBL usuarioBL)
        {
            _UsuarioBL = usuarioBL;
        }

        // Manda Todos Los Registros De La Tabla:
        [Authorize(Roles ="Administrador.")]
        public async Task<ActionResult> Usuarios_Registrados()
        {
            List<Usuario> Objetos_Obtenidos = await _UsuarioBL.Obtener_Todos();

            return View(Objetos_Obtenidos);
        }


        // Manda Un Objeto Encontrado De La Tabla:
        [Authorize(Roles = "Administrador.")]
        public async Task<ActionResult> Detalle(int id)
        {
            Usuario Objeto_Obtenido = await _UsuarioBL.Obtener_PorId(new Usuario() { Id_Usuario = id });

            return View(Objeto_Obtenido);
        }

        [AllowAnonymous]
        public ActionResult Registrarce()
        {
            return View();
        }


        // Recibe Un Objeto Y Lo Guarda En La Tabla:
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<ActionResult> Registrarce(Usuario usuario, IFormFile Fotografia)
        {
            // Convirtiendo a Arreglo De Bytes:
            if (Fotografia != null && Fotografia.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    Fotografia.CopyTo(memoryStream);

                    usuario.Fotografia = memoryStream.ToArray();
                }
            }

            // Contraseña Encriptada:
            usuario.Contraseña = EncriptarMD5(usuario.Contraseña);

            await _UsuarioBL.Registrarce(usuario);

            return RedirectToAction("Usuarios_Registrados", "Usuario");
        }


        // Manda Un Objeto Encontrado De La Tabla
        [Authorize(Roles = "Administrador.")]
        public async Task<ActionResult> Edit(int id)
        {
            Usuario Objeto_Obtenido = await _UsuarioBL.Obtener_PorId(new Usuario() { Id_Usuario = id });

            return View(Objeto_Obtenido);
        }


        // Recibe El Objeto Que Fue Enviado Anteriormente:
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador.")]
        public async Task<ActionResult> Edit(Usuario usuario, IFormFile Fotografia)
        {
            Usuario Objeto_Obtenido = await _UsuarioBL.Obtener_PorId(new Usuario() { Id_Usuario = usuario.Id_Usuario });

            // Convirtiendo a Arreglo De Bytes:
            if (Fotografia != null && Fotografia.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    Fotografia.CopyTo(memoryStream);

                    usuario.Fotografia = memoryStream.ToArray();
                }
            }
            else
            {
                usuario.Fotografia = Objeto_Obtenido.Fotografia;
            }

            // Contraseña Ya Existente:
            usuario.Contraseña = Objeto_Obtenido.Contraseña;

            await _UsuarioBL.Edit(usuario);

            return RedirectToAction("Usuarios_Registrados", "Usuario");
        }


        // Manda Un Objeto Encontrado De La Tabla:
        [Authorize(Roles = "Administrador.")]
        public async Task<ActionResult> Eliminar_Usuario(int id)
        {
            Usuario Objeto_Obtenido = await _UsuarioBL.Obtener_PorId(new Usuario() { Id_Usuario = id });

            return View(Objeto_Obtenido);
        }

        // Recibe El Objeto Que Se Le Fue Enviado Anteriormente:
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador.")]
        public async Task<ActionResult> Eliminar_Usuario(Usuario usuario)
        {
            await _UsuarioBL.Delete(usuario);

            return RedirectToAction("Usuarios_Registrados", "Usuario");
        }


        // * * * * * * * * * * * METODOS PARA PERFIL * * * * * * * * * * * 

        // Manda Un Objeto Del Usuario Que A Iniciado Sesion:
        public async Task<IActionResult> Perfil()
        {
            int Id_Usuario = Convert.ToInt32(User.FindFirstValue("IdUsuario"));

            Usuario Objeto_Obtenido = await _UsuarioBL.Obtener_PorId(new Usuario() { Id_Usuario = Id_Usuario });

            return View(Objeto_Obtenido);
        }

        // Manda Un Objeto Encontrado De La Tabla
        public async Task<ActionResult> Editar_Perfil()
        {
            int Id_Usuario = Convert.ToInt32(User.FindFirstValue("IdUsuario"));

            Usuario Objeto_Obtenido = await _UsuarioBL.Obtener_PorId(new Usuario() { Id_Usuario = Id_Usuario });

            return View(Objeto_Obtenido);
        }


        // Recibe El Objeto Que Fue Enviado Anteriormente:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar_Perfil(Usuario usuario, IFormFile Fotografia)
        {
            Usuario Objeto_Obtenido = await _UsuarioBL.Obtener_PorId(new Usuario() { Id_Usuario = usuario.Id_Usuario });

            // Convirtiendo a Arreglo De Bytes:
            if (Fotografia != null && Fotografia.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    Fotografia.CopyTo(memoryStream);

                    usuario.Fotografia = memoryStream.ToArray();
                }
            }
            else
            {
                usuario.Fotografia = Objeto_Obtenido.Fotografia;
            }

            // Datos Ya Existentes
            usuario.Contraseña = Objeto_Obtenido.Contraseña;
            usuario.RolUsuario = Objeto_Obtenido.RolUsuario;

            await _UsuarioBL.Edit(usuario);

            return RedirectToAction("Index", "Home");
        }




        // * * * * * * * * * OTROS METODOS * * * * * * * * * 

        // Encripta Contraseñas
        [AllowAnonymous]
        private string EncriptarMD5(string Password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(Password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder Contraseña_Encriptada = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    Contraseña_Encriptada.Append(hashBytes[i].ToString("x2"));
                }

                return Contraseña_Encriptada.ToString();
            }
        }

    }
}
