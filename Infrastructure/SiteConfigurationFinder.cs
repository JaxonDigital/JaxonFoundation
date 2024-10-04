using Castle.Core.Internal;
using EPiServer.Find.Helpers;
using EPiServer.ServiceLocation;
using JaxonFoundation.Logic.Models.Pages;
using Cache = System.Runtime.Caching.MemoryCache;
using JaxonFoundation.Logic.Constants;


namespace JaxonFoundation.Infrastructure
{
    public class SiteConfiguration
    {
        private static readonly Cache _cache = Cache.Default;
        public static SiteConfigurationPage? GetSiteConfiguration(ContentReference contentLink)
        {
            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            PageData currentPage = contentLoader.Get<PageData>(contentLink);
            SiteConfigurationPage? siteConfigurationPage = SiteConfigurationPageFinder.GetSiteConfigurationPage(currentPage) as SiteConfigurationPage;
            string CacheKey = siteConfigurationPage?.WorkPageID + DefaultContent.Cache.Configuration;
           
            SiteConfigurationPage? configurationPage = null;
            if (_cache.Contains(CacheKey) && !_cache.Get(CacheKey).ToString().IsNullOrEmpty())
            {
                configurationPage = _cache.Get(CacheKey) as SiteConfigurationPage;
            }
            else if (_cache.Contains(CacheKey) && _cache.Get(CacheKey).IsNull())
            {
                configurationPage = _cache.Get(CacheKey) as SiteConfigurationPage;
                _cache.Remove(CacheKey);
                _cache.Add(CacheKey, siteConfigurationPage, DateTimeOffset.Now.AddDays(365));
            }
            else
            {
                configurationPage = _cache.Get(CacheKey) as SiteConfigurationPage;
                _cache.Add(CacheKey, siteConfigurationPage, DateTimeOffset.Now.AddDays(365));
            }
            return configurationPage;
        }
    }
}
