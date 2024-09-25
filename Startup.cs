using EPiServer.Cms.Shell;
using EPiServer.Cms.UI.AspNetIdentity;
using EPiServer.Scheduler;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using EPiServer.Web.Mvc.Html;
using Geta.Optimizely.ContentTypeIcons.Infrastructure.Configuration;
using Geta.Optimizely.ContentTypeIcons.Infrastructure.Initialization;
using JaxonFoundation.Logic.Mapping;

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
            }

            services
                .AddCmsAspNetIdentity<ApplicationUser>()
                .AddCms()
                .AddAdminUserRegistration()
                .AddEmbeddedLocalization<Startup>();

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

            services.AddControllersWithViews().AddNewtonsoftJson();

            services.AddMvc();

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
                pattern: "Pages/{controller}/{action}",
                new { action = "Index" });

                endpoints.MapControllerRoute(
                    "Default",
                    "{controller}/{action}/{id?}");

                endpoints.MapControllerRoute(
                    name: "DefaultPartial",
                    pattern: "{language}/{area}/{controller}/{action=Index}/{node}");

                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
                endpoints.MapContent();
            });
        }
    }
}
