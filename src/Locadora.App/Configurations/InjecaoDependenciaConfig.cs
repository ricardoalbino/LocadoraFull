using Locadora.Domain.Interfaces;
using Locadora.Domain.Notificacoes;
using Locadora.Domain.Services;
using Locadora.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.App.Configurations
{
    //public class InjecaoDependenciaConfig
    //{

    //    public  static IServiceCollection ResolvendoDependencias(this IServiceCollection  services)
    //    {
    //        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
    //        services.AddScoped<IFilmeRepository, FilmeRepository>();

    //        //Servicos
    //        services.AddScoped<IUsuarioService, UsuarioService>();
    //        services.AddScoped<IFilmeService, FilmeService>();

    //        //Notificadores
    //        services.AddScoped<INotificador, Notificador>();
    //        return services;
    //    }
    //}
}
