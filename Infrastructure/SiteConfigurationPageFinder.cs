using EPiServer.ServiceLocation;
using JaxonFoundation.Logic.Models.Pages;

namespace JaxonFoundation.Infrastructure
{
    public class SiteConfigurationPageFinder
    {
        public static PageData? GetSiteConfigurationPage(PageData currentPage)
        {
            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            if (currentPage is SiteConfigurationPage)
            {
                return currentPage;
            }

            ContentReference contentLink = currentPage.ContentLink;
            var settingsPage = contentLoader.GetAncestors(contentLink)
                .OfType<PageData>()
                .SkipWhile(x => x.ParentLink == null || !x.PageTypeName.EndsWith("ConfigurationPage"))
                .FirstOrDefault();
            return settingsPage;
        }
    }
}
