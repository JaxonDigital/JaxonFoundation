using EPiServer.Find.Cms;
using JaxonFoundation.Logic.Constants;
using JaxonFoundation.Logic.Validators.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace JaxonFoundation.Models.Molecules
{
	[IndexInContentAreas]
	[ImageUrl("~/static/images/thumbnails/Link-Block.png")]
	[ContentType(DisplayName = "Link", GUID = "8EC820B7-DA59-4E32-8735-2205A06B829C", Description = "An hyperlink molecule.", GroupName = BlockGroups.NavigationBlocks)]
	public class LinkBlock : BlockData
	{
		[CultureSpecific]
		[Display(Name = "Text", Description = "The displayed link text.", GroupName = "Block Content", Order = 10)]
		public virtual string? Text { get; set; }

		[CultureSpecific]
		[Display(Name = "Title", Description = "The text used for the title property.", GroupName = "Block Content", Order = 20)]
		public virtual string? Title { get; set; }

		[CultureSpecific]
		[Display(Name = "Open in a new tab", Description = "When the checkbox is selected, the link will open in a new tab.", GroupName = "Block Content", Order = 30)]
		public virtual bool Target { get; set; }

		[CultureSpecific]
		[AllowedTypes(new[] { typeof(PageData) })]
		[Display(Name = "Page", Description = "Reference to a page.", GroupName = "Block Content", Order = 40)]
		public virtual ContentReference? Page { get; set; }

		[CultureSpecific]
		[AllowedTypes(new[] { typeof(MediaData) })]
		[Display(Name = "Media", Description = "34x114.", GroupName = "Block Content", Order = 50)]
		public virtual ContentReference? Media { get; set; }

		[CultureSpecific]
		[Display(Name = "Remaining Url", Description = "Postfix a url segment when using the Page or Media reference properties.", GroupName = "Block Content", Order = 60)]
		public virtual string? RemainingUrl { get; set; }

		[IsValidEmail]
		[CultureSpecific]
		[Display(Name = "Email", Description = "Link to an email address.", GroupName = "Block Content", Order = 70)]
		public virtual string? Email { get; set; }

		[IsValidUrl]
		[CultureSpecific]
		[Display(Name = "External", Description = "Link to a external page.", GroupName = "Block Content", Order = 80)]
		public virtual string? External { get; set; }
	}
}