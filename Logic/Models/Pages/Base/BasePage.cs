using EPiServer.Web;
using JaxonFoundation.Logic.Constants;
using System.ComponentModel.DataAnnotations;
using Castle.Core.Internal;
using JaxonFoundation.Logic.Interfaces;

namespace JaxonFoundation.Logic.Models.Pages.Base
{
    public partial class BasePage: PageData, IIndexable
    {
        #region Metadata
        [CultureSpecific]
        [Display(Name = "Page Title", Description = "The title to be used when the page is referenced.", GroupName = PageTabs.Metadata, Order = 500)]

        public virtual string? PageTitle { get; set; }

        [CultureSpecific]
        [UIHint(UIHint.Textarea)]
        [Display(Name = "Page Description", Description = "The description used for the site when the page is referenced internally.", GroupName = PageTabs.Metadata, Order = 520)]
        public virtual string? Description { get; set; }

        [CultureSpecific]
        [UIHint(UIHint.Textarea)]
        [Display(Name = "Meta Description", Description = "The meta description used for search engine indexing.", GroupName = PageTabs.Metadata, Order = 530)]
        public virtual string? MetaDescription { get; set; }

        [CultureSpecific]
        [Display(Name = "Link Title", Description = "The title to be used when the page is linked to", GroupName = PageTabs.Metadata, Order = 540)]
        public virtual string? LinkTitle { get; set; }

        [CultureSpecific]
        [Display(Name = "Link Description", Description = "The description to be used when the page is linked to", GroupName = PageTabs.Metadata, Order = 550)]
        public virtual string? LinkDescription { get; set; }

        [CultureSpecific]
        [UIHint(UIHint.Textarea)]
        [Display(Name = "Page Headline", Description = "The headline for the page.", GroupName = PageTabs.Metadata, Order = 540)]
        public virtual string? Headline { get; set; }

        [CultureSpecific]
        [Display(Name = "Hide from Search", Description = "If set, this page will be excluded from the site search results", GroupName = PageTabs.Metadata, Order = 10)]
        public virtual bool HideFromSearch { get; set; }

        [Ignore]
        public string? SearchTitle => !PageTitle.IsNullOrEmpty() ? PageTitle : !Headline.IsNullOrEmpty() ? Headline : Name;

        [Ignore]
        public string? MetaDescriptionOutput => !MetaDescription.IsNullOrEmpty() ? MetaDescription : Description;

        [Ignore]
        public string? SearchSummary => Description;
        #endregion
    }
}
