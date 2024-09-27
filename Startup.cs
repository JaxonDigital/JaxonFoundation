using EPiServer.Cms.Shell;
using EPiServer.Cms.UI.AspNetIdentity;
using EPiServer.Scheduler;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using Geta.Optimizely.ContentTypeIcons.Infrastructure.Configuration;
using Geta.Optimizely.ContentTypeIcons.Infrastructure.Initialization;
using EPiServer.Framework.Web.Resources;
using EPiServer.Web;
using Oxy.Com.Logic.Mapping;

namespace JaxonFoundation
{
    public class Startup
    {
        private readonly IWebHostEnvironment _webHostingEnvironment;

        public Startup(IWebHostEnvironment webHostingEnvironment)
        {
            _webHostingEnvironment = webHostingEnvironment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            if (_webHostingEnvironment.IsDevelopment())
            {
                AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(_webHostingEnvironment.ContentRootPath, "App_Data"));

                services.Configure<SchedulerOptions>(options => options.Enabled = false);
                services.Configure<ClientResourceOptions>(uiOptions =>
                {
                    uiOptions.Debug = true;
                });
            }


			// Geta Content Type Icons
			services.AddContentTypeIcons(x =>
			{
				x.EnableTreeIcons = true;
				x.ForegroundColor = "#ffffff";
				x.BackgroundColor = "#1c4773";
				x.FontSize = 40;
				x.CachePath = "[appDataPath]\\thumb_cache\\";
				x.CustomFontPath = "[appDataPath]\\fonts\\";
			});

            services.AddMvc().AddRazorOptions(options =>
            {
                options.ViewLocationFormats.Add("~/Views/Molecules/{0}.cshtml");
                options.ViewLocationFormats.Add("~/Views/Blocks/{0}.cshtml");
                options.ViewLocationFormats.Add("~/Views/Blocks/HeroBlocks/{0}.cshtml");
                options.ViewLocationFormats.Add("~/Views/Blocks/ContentBlocks/{0}.cshtml");
                options.ViewLocationFormats.Add("~/Views/Blocks/SearchBlocks/{0}");
            });

            services
               .AddCmsAspNetIdentity<ApplicationUser>()
               .AddCms()
               .AddCmsCoreWeb()
               .AddAdminUserRegistration()
               .AddEmbeddedLocalization<Startup>();


            services.AddControllersWithViews().AddNewtonsoftJson();
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<DefaultAutoMapperProfile>();
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            // Use Geta Content Type Icons
            app.UseContentTypeIcons();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "PageController",
                    pattern: "~/Pages/{controller}/{action}",
                    new { action = "Index" });

                endpoints.MapControllerRoute(
                    "Default",
                    "{controller}/{action}/{id?}");

                endpoints.MapControllerRoute(
                    name: "DefaultPartial",
                    pattern: "{language}/{area}/{controller}/{action=Index}/{node}"
                    );

                endpoints.MapControllerRoute(
                  name: "AccessibilityReport",
                  pattern: "accessibilityreport/{action}",
                  defaults: new { controller = "AccessibilityReport", action = "Index" }
                  );

                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
                endpoints.MapContent();
            });
        }
    }
}
