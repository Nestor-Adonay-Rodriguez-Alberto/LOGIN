﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Acceso_Datos
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddDALDependecies(this IServiceCollection services, IConfiguration configuration)
        {
            // Inyeccion
            services.AddDbContext<MyDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("Cadena_Conexion_2")));

            // Registrando Las Clases:
            services.AddScoped<UsuarioDAL>();
            services.AddScoped<SeguridadDAL>();

            return services;
        }

    }
}
