using JaxonFoundation.Logic.Models.Media;
using JaxonFoundation.Logic.Models.Pages.Base;
using EPiServer.ServiceLocation;

namespace JaxonFoundation.Logic.ViewModels
{
    public class SettingsPageViewModel<T> where T : BasePage
    {
        public SettingsPageViewModel(T currentPage)
        {
            var loader = ServiceLocator.Current.GetInstance<IContentLoader>();

            Name = currentPage.Name;
            ContentArea? Hero = currentPage.Hero;
            ContentArea? MainContent = currentPage.MainContent;
            HasHero = currentPage.HasHero;
            HasMainContent = currentPage.HasMainContent;

            string? PageTitle = currentPage.PageTitle;
            string? MetaDescription = currentPage.MetaDescription;
            
        }

        public string Name { get; private set; }

        public string LanguageCode { get; private set; }

        public ContentArea? Hero { get; private set; }

        public ContentArea? MainContent { get; private set; }

        public bool HasHero { get; private set; }

        public bool HasMainContent { get; private set; }

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

        public string MetaTags
        {
            get;
            set;
        }

        public string GoogleAnanlyticsId
        {
            get;
            set;
        }
        public string RobotsTxtContext
        {
            get;
            set;
        }
    }
}