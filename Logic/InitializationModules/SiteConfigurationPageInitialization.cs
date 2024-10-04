using EPiServer.DataAccess;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Security;
using EPiServer.ServiceLocation;
using JaxonFoundation.Logic.Models.Pages;
using Cache = System.Runtime.Caching.MemoryCache;
using JaxonFoundation.Logic.Constants;
using JaxonFoundation.Infrastructure;

namespace JaxonFoundation.Logic.InitializationModules
{
    [InitializableModule]
    public class SiteConfigurationPageInitialization : IInitializableModule
    {
        private IContentEvents? _contentEvents;
        private  IContentRepository? _contentRepository;
        private static readonly Cache _cache = Cache.Default;
        private static bool _isModifyingContent = false; // Flag to prevent infinite loop
        Injected<IContentTypeRepository> _contentTypeRepository;
        public void Initialize(InitializationEngine context)

        {
            _contentRepository = context.Locate.Advanced.GetInstance<IContentRepository>();
            _contentEvents = context.Locate.Advanced.GetInstance<IContentEvents>();
            _contentEvents.PublishedContent += OnPublishedContent;
        }

        public void Uninitialize(InitializationEngine context)
        {
            throw new NotImplementedException();
        }


        private void OnPublishedContent(object sender, ContentEventArgs e)
        {
            if (e.Content is SiteConfigurationPage siteConfigurationPage)
            {
                if (_isModifyingContent)
                {
                    return; // Prevent infinite loop by exiting if we are already modifying content
                }
                try
                {
                    // Set the flag to true to indicate we are now modifying content
                    _isModifyingContent = true;
                    var editablePage = siteConfigurationPage.CreateWritableClone() as SiteConfigurationPage;

                    string CacheKey = editablePage.ContentLink.ID + DefaultContent.Cache.Configuration;

                    if (_cache.Contains(CacheKey))
                    {
                        _cache.Remove(CacheKey);
                    }

                    editablePage.VisibleInMenu = false;
                    _contentRepository.Save(editablePage, SaveAction.Save | SaveAction.Publish | SaveAction.SkipValidation | SaveAction.ForceCurrentVersion,
                            AccessLevel.NoAccess);

                    SiteConfiguration.GetSiteConfiguration(editablePage.ContentLink);
                }
                finally
                {
                    // Reset the flag after modifications are complete
                    _isModifyingContent = false;
                }
            }
        }
    }
}
