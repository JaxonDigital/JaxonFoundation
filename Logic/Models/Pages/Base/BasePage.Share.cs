using Castle.Core.Internal;
using EPiServer.Web;
using JaxonFoundation.Logic.Constants;
using JaxonFoundation.Logic.Interfaces;
using JaxonFoundation.Logic.Models.Media;
using System.ComponentModel.DataAnnotations;

namespace JaxonFoundation.Logic.Models.Pages.Base
{
	public partial class BasePage : IIndexable
	{
		[CultureSpecific]
		[Display(Name = "Open Graph Title", Description = "The title to be used when the page is referenced by social media", GroupName = PageTabs.Metadata, Order = 600)]
		public virtual string OpenGraphTitle
		{
			get; set;
		}

		[CultureSpecific]
		[UIHint(UIHint.Textarea)]
		[Display(Name = "Open Graph Description", Description = "The description used for the site when the page is shared on social media", GroupName = PageTabs.Metadata, Order = 610)]
		public virtual string OpenGraphDescription
		{
			get; set;
		}

		[CultureSpecific]
		[Display(Name = "Open Graph Type", Description = "The open graph type (most commonly article or website)", GroupName = PageTabs.Metadata, Order = 620)]
		public virtual string OpenGraphType
		{
			get; set;
		}

		[CultureSpecific]
		[Display(Name = "Open Graph Image", Description = "Image used when shared on social media", GroupName = PageTabs.Metadata, Order = 630)]
		[UIHint(UIHint.Image)]
		[AllowedTypes(typeof(ImageFile))]
		public virtual ContentReference OpenGraphImage
		{
			get; set;
		}

		[CultureSpecific]
		[Display(Name = "Twitter Card Title", Description = "The title to be used when the page is referenced by Twitter", GroupName = PageTabs.Metadata, Order = 650)]
		public virtual string TwitterCardTitle
		{
			get; set;
		}

		[CultureSpecific]
		[UIHint(UIHint.Textarea)]
		[Display(Name = "Twitter Card Description", Description = "The description used for the site when the page is shared on Twitter", GroupName = PageTabs.Metadata, Order = 660)]
		public virtual string TwitterCardDescription
		{
			get; set;
		}

		[CultureSpecific]
		[Display(Name = "Twitter Card Image", Description = "Image used when shared on Twitter", GroupName = PageTabs.Metadata, Order = 670)]
		[UIHint(UIHint.Image)]
		[AllowedTypes(typeof(ImageFile))]
		public virtual ContentReference TwitterCardImage
		{
			get; set;
		}

		[CultureSpecific]
		[UIHint(UIHint.Textarea)]
		[Display(Name = "Email Share Subject", Description = "Email subject used when sharing by email in social share module", GroupName = PageTabs.Metadata, Order = 700)]
		public virtual string EmailShareSubject
		{
			get; set;
		}

		[CultureSpecific]
		[UIHint(UIHint.Textarea)]
		[Display(Name = "Email Share Body", Description = "Email body used when sharing by email in social share module", GroupName = PageTabs.Metadata, Order = 710)]
		public virtual string EmailShareBody
		{
			get; set;
		}

		[CultureSpecific]
		[UIHint(UIHint.Textarea)]
		[Display(Name = "Meta Tags", Description = "Custom meta tags to add to the page.", GroupName = PageTabs.Metadata, Order = 715)]
		public virtual string MetaTags { get; set; }

		[Ignore]
		public string OpenGraphTitleOutput => !OpenGraphTitle.IsNullOrEmpty() ? OpenGraphTitle : SearchTitle;

		[Ignore]
		public string OpenGraphDescriptionOutput => !OpenGraphDescription.IsNullOrEmpty() ? OpenGraphDescription : ListableDescription;

		[Ignore]
		public ContentReference OpenGraphImageOutput => OpenGraphImage != null ? OpenGraphImage : ListableImage;

		[Ignore]
		public string TwitterCardTitleOutput => !TwitterCardTitle.IsNullOrEmpty() ? TwitterCardTitle : OpenGraphTitleOutput;

		[Ignore]
		public string TwitterCardDescriptionOutput => !TwitterCardDescription.IsNullOrEmpty() ? TwitterCardDescription : OpenGraphDescriptionOutput;

		[Ignore]
		public ContentReference TwitterCardImageOutput => TwitterCardImage != null ? TwitterCardImage : OpenGraphImageOutput;

		public override void SetDefaultValues(ContentType contentType)
		{
			base.SetDefaultValues(contentType);

			OpenGraphType = DefaultContent.OpenGraphArticle;
		}
	}
}
