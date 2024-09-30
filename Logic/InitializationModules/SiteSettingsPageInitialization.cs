using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using JaxonFoundation.Logic.Models.Pages;
using System.Configuration;
using Cache = System.Runtime.Caching.MemoryCache;

namespace JaxonFoundation.Logic.InitializationModules
{
    [InitializableModule]
    public class SiteSettingsPageInitialization : IInitializableModule
    {
        private IContentEvents? _contentEvents;
        private IContentRepository? _contentRepository;
        private static readonly Cache _cache = Cache.Default;
        private static bool _isModifyingContent = false; // Flag to prevent infinite loop
        Injected<IContentTypeRepository> _contentTypeRepository;
        public void Initialize(InitializationEngine context)

        {
            _contentEvents = context.Locate.Advanced.GetInstance<IContentEvents>();
            _contentEvents.PublishedContent += OnPublishedContent;
        }

        public void Uninitialize(InitializationEngine context)
        {
            throw new NotImplementedException();
        }


        private void OnPublishedContent(object sender, ContentEventArgs e)
        {
            if (e.Content is SiteSettingsPage siteSettingsPage)
            {
                var editablePage = siteSettingsPage.CreateWritableClone() as SiteSettingsPage;

                string GoogleCacheKey = editablePage.Name + "GoogleId";

                if (editablePage != null & _cache.Contains(GoogleCacheKey) && _cache.Get(GoogleCacheKey) != null)
                {
                    _cache.Remove(GoogleCacheKey);
                    _cache.Add(GoogleCacheKey, editablePage.GoogleAnanlyticsId, DateTimeOffset.Now.AddDays(365));
                }
                else if (!_cache.Contains(GoogleCacheKey) && editablePage != null)
                {
                    _cache.Add(GoogleCacheKey, editablePage.GoogleAnanlyticsId, DateTimeOffset.Now.AddDays(365));
                }

                string RobotsCacheKey = editablePage.Name + "Robots";
                if (editablePage != null & _cache.Contains(RobotsCacheKey) && _cache.Get(RobotsCacheKey) != null)
                {
                    _cache.Remove(RobotsCacheKey);
                    _cache.Add(RobotsCacheKey, editablePage.RobotsTxt, DateTimeOffset.Now.AddDays(365));
                }
                else if (!_cache.Contains(RobotsCacheKey) && editablePage != null)
                {
                    _cache.Add(RobotsCacheKey, editablePage.RobotsTxt, DateTimeOffset.Now.AddDays(365));
                }
            }
        }
    }
}
