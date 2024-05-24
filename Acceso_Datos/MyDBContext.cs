using Entidades;
using Microsoft.EntityFrameworkCore;


namespace Acceso_Datos
{
    public class MyDBContext: DbContext
    {
        // Constructor:
        public MyDBContext(DbContextOptions<MyDBContext> options) 
            : base(options)
        {
             
        }

        // Tablas De DB:
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
