//using EPiServer.ServiceLocation;
//using JaxonFoundation.Logic.Models.Pages;


//namespace JaxonFoundation.Infrastructure
//{
//    public class GoogleAnalyticsIdFinder
//    {
//        public static string? AnalyticsId(ContentReference contentLink)
//        {
//            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
//            PageData currentPage = contentLoader.Get<PageData>(contentLink);
//            PageData? settingsPage = GetSettingsPage(currentPage);
//            string? analyticsId = (settingsPage as SettingsPage)?.GoogleAnanlyticsId;
//            return analyticsId;
//        }

//        public static PageData? GetSettingsPage(PageData currentPage)
//        {
//            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
//            if (currentPage is SettingsPage)
//            {
//                return currentPage;
//            }

//            ContentReference contentLink = currentPage.ContentLink;
//            var settingsPage = contentLoader.GetAncestors(contentLink)
//                .OfType<PageData>()
//                .SkipWhile(x => x.ParentLink == null || !x.PageTypeName.EndsWith("SettingsPage"))
//                .FirstOrDefault();
//            return settingsPage;
//        }
//    }
//}
