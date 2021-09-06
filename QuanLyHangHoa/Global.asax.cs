using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FX.Core;
using FX.Utils;
using log4net;
using log4net.Config;

namespace QuanLyHangHoa
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(MvcApplication));
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            XmlConfigurator.ConfigureAndWatch(new FileInfo(Server.MapPath("~/") + "Config/logging.config"));
            AreaRegistration.RegisterAllAreas();

            //// Use LocalDB for Entity Framework by default
            //Database.DefaultConnectionFactory = new SqlConnectionFactory(@"Data Source=(localdb)\v11.0; Integrated Security=True; MultipleActiveResultSets=True");

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            Bootstrapper.InitializeContainer();
        }

        private void GetCurrentSite(HttpContext context)
        {
            IFXContext _FXcontext = FXContext.Current;
            try
            {
                string siteUrl = UrlUtil.GetSiteUrl();
                _FXcontext.PhysicalSiteDataDirectory = context.Server.MapPath("SiteData");
                string sitepath = FXContext.Current.PhysicalSiteDataDirectory;
            }
            catch (Exception ex)
            {
                log.Error("An unexpected error occured while setting the current site context.", ex);
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            GetCurrentSite(HttpContext.Current);
        }
    }
}