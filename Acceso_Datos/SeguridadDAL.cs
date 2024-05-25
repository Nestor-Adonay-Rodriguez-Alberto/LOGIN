using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso_Datos
{
    public class SeguridadDAL
    {
        // Representa DB:
        private readonly MyDBContext _MyDBcontext;

        // Constructor:
        public SeguridadDAL(MyDBContext myDBcontext)
        {
            _MyDBcontext = myDBcontext;
        }


        // Manda Un Objeto:
        public async Task<Usuario> Creadenciales_Usuario(Usuario usuario)
        {
            Usuario? Objeto_Obtenido = await _MyDBcontext.Usuarios
                .FirstOrDefaultAsync(x=> x.NombreUsuario==usuario.NombreUsuario && 
                x.Gmail==usuario.Gmail && x.Contraseña==usuario.Contraseña);

            return Objeto_Obtenido;
        }
    }
}
