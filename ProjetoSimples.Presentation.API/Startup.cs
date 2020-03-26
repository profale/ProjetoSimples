using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Xml;
using Microsoft.Owin;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using ProjetoSimples.Domain.Contracts.DomainServices;
using ProjetoSimples.Domain.Contracts.Repositories;
using ProjetoSimples.Domain.DomainServices;
using ProjetoSimples.Infra.Context;
using ProjetoSimples.Infra.Repositories;
using ProjetoSimples.Presentation.API.Mappers;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;


[assembly: OwinStartup(typeof(ProjetoSimples.Presentation.API.Startup))]

namespace ProjetoSimples.Presentation.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            //Configurar SimpleInjector
            var container = SimpleInjectorConfig.Configure();
            //configuracao necessaria para permitir o uso de injecao de dependencia, se necessária
            var config = new HttpConfiguration
            {
                DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container),


            };

            var formatters = config.Formatters;
            formatters.Remove(formatters.XmlFormatter);

            var jsonSettings = formatters.JsonFormatter.SerializerSettings;
            jsonSettings.Formatting = Newtonsoft.Json.Formatting.None;
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
            formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            //Informar que esta usando WebApi ou MVC
            app.UseWebApi(config);
            ConfigureWebApi(config);
            config.EnableCors();

            //registrar o AutoMapper.. 
            AutoMapperConfig.Configure();




        }

        //Configurar WebApi
        public static void ConfigureWebApi(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


        }

        private static class SimpleInjectorConfig
        {
            public static Container Configure()
            {
                var container = new Container();
                container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

                container.Register<IContatoRepository, ContatoRepository>(Lifestyle.Scoped);
                container.Register<IOperadoraRepository, OperadoraRepository>(Lifestyle.Scoped);

                container.Register<IContatoDomainService, ContatoDomainService>(Lifestyle.Scoped);
                container.Register<IOperadoraDomainService, OperadoraDomainService>(Lifestyle.Scoped);

                container.Register<DataContext>(Lifestyle.Scoped);

                container.Verify();
                return container;
            }
        }
    }
}
