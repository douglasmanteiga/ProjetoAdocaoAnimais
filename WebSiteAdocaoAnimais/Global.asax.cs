using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebSiteAdocaoAnimais.App_Start;
using WebSiteAdocaoAnimais.AutoMapper;

namespace WebSiteAdocaoAnimais
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Inicializa a injeção de dependência
            SimpleInjectorInitializer.Initialize();

            // Configurando o AutoMapper para registrar os profiles
            // de mapeamento durante a inicialização da aplicação.
            AutoMapperConfig.RegisterMappings();
        }
    }
}
