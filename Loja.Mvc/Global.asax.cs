﻿using Loja.Mvc.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Loja.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            //https://stackoverflow.com/questions/26067296/how-to-add-web-api-to-an-existing-asp-net-mvc-5-web-application-project
            // Manually installed WebAPI 2.2 after making an MVC project.
            GlobalConfiguration.Configure(WebApiConfig.Register); // NEW way
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);


            log4net.Config.XmlConfigurator.Configure();
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            var cultura = new CulturaHelper();

            Thread.CurrentThread.CurrentCulture = cultura.CultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultura.CultureInfo;
        }
    }
}
