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
using Geta.Optimizely.Sitemaps;
using EPiServer.Azure.Blobs;
using EPiServer.Data;

namespace JaxonFoundation
{
    public class Startup
    {
        private readonly IWebHostEnvironment _webHostingEnvironment;
        private readonly IConfiguration _configuration;

        public Startup(IWebHostEnvironment webHostingEnvironment, IConfiguration configuration)
        {
            _webHostingEnvironment = webHostingEnvironment;
            _configuration = configuration;
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
            else
            {
                
                // Bind AzureBlobProviderOptions to the settings in appsettings.json or appsettings.{env.EnvironmentName}.json
                services.Configure<AzureBlobProviderOptions>(_configuration.GetSection("EPiServer:Cms:AzureBlobProvider"));

                // Register Azure Blob Provider with options from the configuration
                services.AddAzureBlobProvider(options =>
                {
                    var azureBlobOptions = _configuration.GetSection("EPiServer:Cms:AzureBlobProvider").Get<AzureBlobProviderOptions>();
                    Console.WriteLine("---JAXON LOGGING---  The Blob Settings are: ", azureBlobOptions);
                    options.ConnectionString = azureBlobOptions.ConnectionString;
                    options.ContainerName = azureBlobOptions.ContainerName;
                });
                services.Configure((Action<DataAccessOptions>)(options => options.UpdateDatabaseSchema = true));
                services.AddApplicationInsightsTelemetry();
                services.AddServiceProfiler();
                services.AddAzureEventProvider(options => options.TopicName = "mysiteevents");
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
               .AddFind()
               .AddEmbeddedLocalization<Startup>();

            services.AddSitemaps(x =>
            {
                x.EnableLanguageDropDownInAdmin = false;
                x.EnableRealtimeCaching = false;
                x.EnableRealtimeSitemap = true;
            });

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
