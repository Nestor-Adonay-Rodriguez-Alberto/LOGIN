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
            const string Cadena_Conexion_2 = "workstation id=DBLogin.mssql.somee.com;packet size=4096;user id=NestorWED_SQLLogin_1;pwd=uihozmx2cq;data source=DBLogin.mssql.somee.com;persist security info=False;initial catalog=DBLogin;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(Cadena_Conexion_2);

            return new MyDBContext(optionsBuilder.Options);
        }
    }
}
