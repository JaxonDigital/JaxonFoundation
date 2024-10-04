using EPiServer.Web;
using JaxonFoundation.Logic.Constants;
using System.ComponentModel.DataAnnotations;
using Castle.Core.Internal;
using JaxonFoundation.Logic.Interfaces;
using Geta.Optimizely.Sitemaps.SpecializedProperties;
using JaxonFoundation.Logic.Models.Media;
using JaxonFoundation.Logic.Validators.DataAnnotations;
using JaxonFoundation.Models.Molecules;
using JaxonFoundation.Logic.Models.Molecules;

namespace JaxonFoundation.Logic.Models.Pages.Base
{
    public partial class BasePage : PageData, IIndexable
    {
        #region Metadata

        [UIHint(UIHint.Image)]
        [AllowedTypes(new[] { typeof(ImageFile) })]
        [Display(Name = "List Image", GroupName = PageTabs.Metadata)]
        public virtual ContentReference ListableImage { get; set; }

        [CultureSpecific]
        [Display(Name = "Page Title", Description = "The title to be used when the page is referenced.", GroupName = PageTabs.Metadata, Order = 500)]

        public virtual string PageTitle { get; set; }

        [CultureSpecific]
        [UIHint(UIHint.Textarea)]
        [Display(Name = "Page Description", Description = "The description used for the site when the page is referenced internally.", GroupName = PageTabs.Metadata, Order = 510)]
        public virtual string Description { get; set; }

        [CultureSpecific]
        [UIHint(UIHint.Textarea)]
        [Display(Name = "Meta Description", Description = "The meta description used for search engine indexing.", GroupName = PageTabs.Metadata, Order = 515)]
        public virtual string MetaDescription { get; set; }

        [CultureSpecific]
        [Display(Name = "Link Title", Description = "The title to be used when the page is linked to", GroupName = PageTabs.Metadata, Order = 520)]
        public virtual string LinkTitle { get; set; }

        [CultureSpecific]
        [Display(Name = "Link Description", Description = "The description to be used when the page is linked to", GroupName = PageTabs.Metadata, Order = 530)]
        public virtual string LinkDescription { get; set; }

        [CultureSpecific]
        [UIHint(UIHint.Textarea)]
        [Display(Name = "Page Headline", Description = "The headline for the page.", GroupName = PageTabs.Metadata, Order = 540)]
        public virtual string Headline { get; set; }

        [CultureSpecific]
        [Display(Name = "Hide from Search", Description = "If set, this page will be excluded from the site search results", GroupName = PageTabs.Metadata, Order = 40)]
        public virtual bool HideFromSearch { get; set; }

        [CultureSpecific]
        [Display(Name = "Hide link to Page", Description = "If set, the link to this page when listed will be hidden.", GroupName = PageTabs.Metadata, Order = 45)]
        public virtual bool HideLinkToPage { get; set; }

        [CultureSpecific]
        [MaxItemCount(1)]
        [AllowedTypes(new[] { typeof(LinkBlock) }, restrictedTypes: new[] { typeof(IconLinkBlock) })]
        [Display(Name = "Contact Link", Description = "Contact Link", GroupName = PageTabs.Metadata, Order = 900)]
        public virtual ContentArea ContactLink { get; set; }

        [Ignore]
        public string SearchTitle => !PageTitle.IsNullOrEmpty() ? PageTitle : !Headline.IsNullOrEmpty() ? Headline : Name;

        [Ignore]
        public string MetaDescriptionOutput => !MetaDescription.IsNullOrEmpty() ? MetaDescription : Description;

        [Ignore]
        public string SearchSummary => Description;


        #endregion

        #region IListablePage

        [Ignore]
        public string ListableDescription => !string.IsNullOrEmpty(Description) ? Description : ListableTitle;

        [Ignore]
        public bool HasTitle => !string.IsNullOrEmpty(ListableTitle);

        [Ignore]
        public bool HasDescription => !string.IsNullOrEmpty(ListableDescription);

        [Ignore]
        public bool HasImage => !ContentReference.IsNullOrEmpty(ListableImage);

        [Ignore]
        public int ListableId => this.ContentLink.ID;

        [Ignore]
        public string ListableTitle => PageTitle ?? Name;


        [Ignore]
        public string ListableAriaLabel => !LinkDescription.IsNullOrEmpty() ? LinkDescription : ListableTitle;

        [Ignore]
        public ContentReference ListableContentReference => ContentLink;


        [Ignore]
        public string ListableHeadline => Headline ?? PageTitle ?? Name;

        #endregion

        #region IXmlSitemapPage

        [UIHint("SeoSitemap")]
        [BackingType(typeof(PropertySEOSitemaps))]
        [Display(Name = "SeoSitemap", Description = "Pages properties for sitemap", GroupName = PageTabs.Metadata, Order = 90)]
        public virtual string? SEOSitemaps { get; set; }

        #endregion
    }
}