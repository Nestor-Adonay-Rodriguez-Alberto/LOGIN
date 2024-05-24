using Acceso_Datos;
using Entidades;


namespace Logica_Negocio
{
    public class UsuarioBL
    {
        // Objeto De La DB:
        private readonly UsuarioDAL _UsuarioDAL;

        // Constructor:
        public UsuarioBL(UsuarioDAL usuarioDAL)
        {
            _UsuarioDAL = usuarioDAL;
        }



        // ******* METODOS QUE MANDARAN OBJETOS A LAS VISTAS ********
        // **********************************************************

        // Manda Un Objeto Encontrado:
        public async Task<Usuario> Obtener_PorId(Usuario usuario)
        {
            return await _UsuarioDAL.Obtener_PorId(usuario);
        }


        // Manda Todos Los Objetos:
        public async Task<List<Usuario>> Obtener_Todos()
        {
            return await _UsuarioDAL.Obtener_Todos();
        }




        // *******  METODOS QUE RECIBIRAN OBJETOS Y MODIFICARAN LA DB  ********
        // ********************************************************************

        // Recibe Un Objeto Lo Guarda En La DB:
        public async Task<int> Registrarce(Usuario usuario)
        {
            return await _UsuarioDAL.Registrarce(usuario);
        }


        // Recibe Un Objeto Lo Busca Y Modifica El Encontrado Con El Nuevo:
        public async Task<int> Edit(Usuario usuario)
        {
            return await _UsuarioDAL.Edit(usuario);
        }


        // Recibe Un Objeto Lo Busca Y Elimina El Encontrado:
        public async Task<int> Delete(Usuario usuario)
        {
            return await _UsuarioDAL.Delete(usuario);
        }
    }
}
