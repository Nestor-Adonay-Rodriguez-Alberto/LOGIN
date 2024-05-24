using Entidades;
using Logica_Negocio;
using Microsoft.AspNetCore.Mvc;


namespace UI_Login.Controllers
{
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
        public async Task<ActionResult> Usuarios()
        {
            List<Usuario> Objetos_Obtenidos = await _UsuarioBL.Obtener_Todos();

            return View(Objetos_Obtenidos);
        }


        // Manda Un Objeto Encontrado De La Tabla:
        public async Task<ActionResult> Detalle(int id)
        {
            Usuario Objeto_Obtenido = await _UsuarioBL.Obtener_PorId(new Usuario() { Id_Usuario = id });

            return View(Objeto_Obtenido);
        }

        
        public ActionResult Registrarce()
        {
            return View();
        }


        // Recibe Un Objeto Y Lo Guarda En La Tabla:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Registrarce(Usuario usuario)
        {
            await _UsuarioBL.Registrarce(usuario);

            return RedirectToAction(nameof(Index));
        }


        // Manda Un Objeto Encontrado De La Tabla
        public async Task<ActionResult> Edit(int id)
        {
            Usuario Objeto_Obtenido = await _UsuarioBL.Obtener_PorId(new Usuario() { Id_Usuario = id });

            return View(Objeto_Obtenido);
        }


        // Recibe El Objeto Que Fue Enviado Anteriormente:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Usuario usuario)
        {
            await _UsuarioBL.Edit(usuario);

            return RedirectToAction(nameof(Index));
        }


        // Manda Un Objeto Encontrado De La Tabla:
        public async Task<ActionResult> Delete(int id)
        {
            Usuario Objeto_Obtenido = await _UsuarioBL.Obtener_PorId(new Usuario() { Id_Usuario = id });

            return View(Objeto_Obtenido);
        }

        // Recibe El Objeto Que Se Le Fue Enviado Anteriormente:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Usuario usuario)
        {
            await _UsuarioBL.Delete(usuario);

            return RedirectToAction(nameof(Index));
        }

    }
}
