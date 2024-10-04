using JaxonFoundation.Logic.Models.Pages.Base;
using EPiServer.ServiceLocation;
using JaxonFoundation.Logic.Models.Pages;
using JaxonFoundation.Logic.Models.Media;

namespace JaxonFoundation.Logic.ViewModels.Pages
{
    public class PageViewModel<T>
         where T : BasePage
    {
        public PageViewModel(T currentPage)
        {
            var loader = ServiceLocator.Current.GetInstance<IContentLoader>();

            Name = currentPage.Name;
            Hero = currentPage.Hero;
            MainContent = currentPage.MainContent;
            HasHero = currentPage.HasHero;
            HasMainContent = currentPage.HasMainContent;
            ContentLink = currentPage.ContentLink;


            PageTitle = currentPage.PageTitle;
            MetaDescription = currentPage.MetaDescription;
            var listableCardImage = (currentPage as BasePage).ListableImage;
            if (listableCardImage != null)
            {
                ListableImage = loader.Get<ImageFile>((currentPage as BasePage).ListableImage);
            }
            OpenGraphTitle = currentPage.OpenGraphTitleOutput;
            OpenGraphDescription = currentPage.OpenGraphDescriptionOutput;
            OpenGraphType = currentPage.OpenGraphType;

            var openCardImage = (currentPage as BasePage).OpenGraphImageOutput;
            if (openCardImage != null)
            {
                OpenGraphImage = loader.Get<ImageFile>((currentPage as BasePage).OpenGraphImageOutput);
            }
            TwitterCardTitle = currentPage.TwitterCardTitleOutput;
            TwitterCardDescription = currentPage.TwitterCardDescriptionOutput;

            var twitterCardImage = (currentPage as BasePage).TwitterCardImageOutput;
            if (twitterCardImage != null)
            {
                TwitterCardImage = loader.Get<ImageFile>((currentPage as BasePage).TwitterCardImageOutput);
            }
            EmailShareSubject = currentPage.EmailShareSubject;
            EmailShareBody = currentPage.EmailShareBody;
            MetaTags = currentPage.MetaTags;
            LanguageCode = currentPage.Language.Name;
        }

        public string? Name { get; private set; }

        public string? LanguageCode { get; private set; }

        public ContentArea? Hero { get; private set; }

        public ContentArea? MainContent { get; private set; }

        public bool? HasHero { get; private set; }

        public bool? HasMainContent { get; private set; }

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

        public ImageFile? ListableImage
        {
            get;
            set;
        }

        public string? OpenGraphTitle
        {
            get;
            set;
        }

        public string? OpenGraphDescription
        {
            get;
            set;
        }

        public string? OpenGraphType
        {
            get;
            set;
        }

        public ImageFile? OpenGraphImage
        {
            get;
            set;
        }

        public bool HasOpenGraphImage => OpenGraphImage != null;

        public string? OpenGraphImageAltText => HasOpenGraphImage ? OpenGraphImage?.Description : string.Empty;

        public string? OpenGraphImageUrl
        {
            get;
            set;
        }

        public string? TwitterCardTitle
        {
            get;
            set;
        }

        public string? TwitterCardDescription
        {
            get;
            set;
        }

        public virtual string? TwitterCardType => HasTwitterCardImage ? "summary_large_image" : "summary";

        public ImageFile? TwitterCardImage
        {
            get;
            set;
        }

        public string? TwitterCardImageUrl
        {
            get;
            set;
        }

        public bool HasTwitterCardImage => TwitterCardImage != null;

        public string? TwitterCardImageAltText => HasTwitterCardImage ? TwitterCardImage?.Description : string.Empty;

        public string? EmailShareSubject
        {
            get;
            set;
        }

        public string? EmailShareBody
        {
            get;
            set;
        }

        public string? MetaTags
        {
            get;
            set;
        }
        public string? CssBodyClass
        {
            get;
            set;
        }

        public ContentReference? ContentLink
        {
            get;
            set;
        }
    }
}