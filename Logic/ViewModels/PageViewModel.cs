using JaxonFoundation.Logic.Models.Pages.Base;
using EPiServer.ServiceLocation;
using JaxonFoundation.Logic.Models.Pages;

namespace JaxonFoundation.Logic.ViewModels
{
    public class PageViewModel<T> where T : BasePage
    {
        public PageViewModel(T currentPage)
        {
            var loader = ServiceLocator.Current.GetInstance<IContentLoader>();

            string? PageTitle = currentPage.PageTitle;
            string? MetaDescription = currentPage.MetaDescription;
        }

        public string? Name { get; private set; }
        public string? LanguageCode { get; private set; }
        public string? PageTitle
        {
            get;
            set;
        }

        public string? SiteUrl
        {
            get;
            set;
        }

        public string? CanonicalUrl
        {
            get;
            set;
        }

        public string? MetaDescription
        {
            get;
            set;
        }

        public string? MetaTags
        {
            get;
            set;
        }
    }
}