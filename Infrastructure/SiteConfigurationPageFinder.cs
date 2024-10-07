using EPiServer.ServiceLocation;
using JaxonFoundation.Logic.Models.Pages;
public static class SiteConfigurationPageFinder
{
    public static PageData? GetSiteConfigurationPage(PageData currentPage)
    {
        var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
        if (currentPage is SiteConfigurationPage)
        {
            return currentPage;
        }

        ContentReference contentLink = currentPage.ContentLink;
        PageData? configurationPage;
        if (currentPage.PageTypeName == "HomePage")
        {
            configurationPage = contentLoader.GetChildren<PageData>(contentLink)
            .OfType<PageData>()
            .SkipWhile(x => x.ParentLink == null || !x.PageTypeName.EndsWith("ConfigurationPage"))
            .FirstOrDefault();
            return configurationPage;
        }
        else
        {
            configurationPage = contentLoader.GetAncestors(contentLink)
            .OfType<PageData>()
            .SkipWhile(x => x.ParentLink == null || !x.PageTypeName.EndsWith("ConfigurationPage"))
            .FirstOrDefault();
            return configurationPage;
        }
    }
}
