using Entidades;
using Microsoft.EntityFrameworkCore;


namespace Acceso_Datos
{
    public class UsuarioDAL
    {
        // Representa DB:
        private readonly MyDBContext _MyDBContext;

        // Constructor:
        public UsuarioDAL(MyDBContext myDBContext)
        {
            _MyDBContext = myDBContext;
        }

        // ******* METODOS QUE MANDARAN OBJETOS A LAS VISTAS ********
        // **********************************************************

        // Manda Un Objeto Encontrado:
        public async Task<Usuario> Obtener_PorId(Usuario usuario)
        {
            Usuario Objeto_Obtenido = await _MyDBContext.Usuarios.FirstOrDefaultAsync(x=> x.Id_Usuario==usuario.Id_Usuario);

            return Objeto_Obtenido;
        }


        // Manda Todos Los Objetos:
        public async Task<List<Usuario>> Obtener_Todos()
        {
            List<Usuario> Objetos_Obtenidos = await _MyDBContext.Usuarios.ToListAsync();

            return Objetos_Obtenidos;
        }




        // *******  METODOS QUE RECIBIRAN OBJETOS Y MODIFICARAN LA DB  ********
        // ********************************************************************

        // Recibe Un Objeto Lo Guarda En La DB:
        public async Task<int> Registrarce(Usuario usuario)
        {
            _MyDBContext.Add(usuario);

            return await _MyDBContext.SaveChangesAsync();
        }


        // Recibe Un Objeto Lo Busca Y Modifica El Encontrado Con El Nuevo:
        public async Task<int> Edit(Usuario usuario)
        {
            Usuario? Objeto_Obtenido = await _MyDBContext.Usuarios.FirstOrDefaultAsync(x => x.Id_Usuario == usuario.Id_Usuario);

            if(Objeto_Obtenido!=null)
            {
                // Modificando Todos:
                Objeto_Obtenido.NombreCompleto = usuario.NombreCompleto;
                Objeto_Obtenido.NombreUsuario = usuario.NombreUsuario;
                Objeto_Obtenido.FechaNacimiento = usuario.FechaNacimiento;
                Objeto_Obtenido.Gmail = usuario.Gmail;
                Objeto_Obtenido.Contraseña = usuario.Contraseña;
                Objeto_Obtenido.Genero = usuario.Genero;
                Objeto_Obtenido.Residencia = usuario.Residencia;
                Objeto_Obtenido.RolUsuario = usuario.RolUsuario;
                Objeto_Obtenido.Fotografia = usuario.Fotografia;
            }

            _MyDBContext.Update(Objeto_Obtenido);

            return await _MyDBContext.SaveChangesAsync();
        }


        // Recibe Un Objeto Lo Busca Y Elimina El Encontrado:
        public async Task<int> Delete(Usuario usuario)
        {
            Usuario? Objeto_Obtenido = await _MyDBContext.Usuarios.FirstOrDefaultAsync(x => x.Id_Usuario == usuario.Id_Usuario);

            if(Objeto_Obtenido!=null)
            {
                _MyDBContext.Remove(Objeto_Obtenido);
            }

            return await _MyDBContext.SaveChangesAsync();
        }
    }
}
