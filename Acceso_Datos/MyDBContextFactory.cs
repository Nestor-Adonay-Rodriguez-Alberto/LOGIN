using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace Acceso_Datos
{
    public class MyDBContextFactory : IDesignTimeDbContextFactory<MyDBContext>
    {
        public MyDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyDBContext>();
            const string Cadena_Conexion = "Data Source=.;Initial Catalog=Z2_LOGIN;Integrated Security=True;Trust Server Certificate=True";
            optionsBuilder.UseSqlServer(Cadena_Conexion);

            return new MyDBContext(optionsBuilder.Options);
        }
    }
}
