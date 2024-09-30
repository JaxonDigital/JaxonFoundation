using EPiServer.Web.Mvc;
using JaxonFoundation.Logic.Models.Pages.Base;
using JaxonFoundation.Logic.Models.Pages;
using JaxonFoundation.Logic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using JaxonFoundation.Logic.ViewModels.Navigation;
using Cache = System.Runtime.Caching.MemoryCache;
using EPiServer.Core.Internal;
using EPiServer.ServiceLocation;


namespace JaxonFoundation.Logic.Controllers.Pages
{
    public class HomePageController : PageController<HomePage>
    {
        private readonly IMapper _mapper;
        private static readonly Cache _cache = Cache.Default;
        private IContentRepository? _contentRepository;

        public HomePageController(IMapper mapper)
        {
            _mapper = mapper;
        }
        public ActionResult Index(HomePage currentPage)
        {
            
            var viewModel = _mapper.Map<HomePage, HomePageViewModel>(currentPage);
            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            var children = contentRepository.GetChildren<PageData>(currentPage.ContentLink);
            var siteSettingsPage = children.OfType<SiteSettingsPage>().FirstOrDefault();
            string RobotsCacheKey = "SiteSettingsRobots";
            var robots = _cache.Get(RobotsCacheKey);
            string GoogleCacheKey = "SiteSettingsGoogleId";
            var googleId = _cache.Get(GoogleCacheKey);
            if (robots != null)
            {
                viewModel.RobotsTxt = robots.ToString();
            }
            else 
            {
                viewModel.RobotsTxt = siteSettingsPage?.RobotsTxt;
                _cache.Add(RobotsCacheKey, siteSettingsPage?.RobotsTxt, DateTimeOffset.Now.AddDays(365));
            }
            if (googleId != null) 
            {
                viewModel.GoogleAnanlyticsId = googleId.ToString();
            }
            else
            {
                viewModel.GoogleAnanlyticsId = siteSettingsPage?.GoogleAnanlyticsId;
                _cache.Add(GoogleCacheKey, siteSettingsPage?.GoogleAnanlyticsId, DateTimeOffset.Now.AddDays(365));
            }
            return View(viewModel);
        }
    }
}