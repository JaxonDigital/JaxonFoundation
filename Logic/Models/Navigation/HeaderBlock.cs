using EPiServer.Web;
using JaxonFoundation.Logic.Constants;
using JaxonFoundation.Logic.Models.Blocks;
using JaxonFoundation.Logic.Models.Media;
using System.ComponentModel.DataAnnotations;

namespace JaxonFoundation.Logic.Navigation.Models
{
	[ContentType(
		DisplayName = "Header",
		GUID = "0ED073B3-ABAE-420B-909D-3760AFD7542C",
		Description = "Header and navigation for the web site",
		GroupName = BlockGroups.NavigationBlocks)]
	public class HeaderBlock : StandardBlockBase
	{
		
		[CultureSpecific]
		[Display(
			Name = "Logo",
			Description = "40x42",
			GroupName = PageTabs.Navigation,
			Order = 130)]
		[UIHint(UIHint.Image)]
		[AllowedTypes(typeof(ImageFile))]
		public virtual ContentReference? Logo { get; set; }

		[CultureSpecific]
		[Display(
			Name = "Label Overview",
			Description = "The generic label for the overview pages in the mobile navigation",
			GroupName = PageTabs.Navigation,
			Order = 150)]
		public virtual string? LabelOverview
		{
			get; set;
		}

		[CultureSpecific]
		[Display(
			Name = "Skip To Content",
			Description = "Content for the skip to content link",
			GroupName = PageTabs.Navigation,
			Order = 155)]
		public virtual string? SkipToContent
		{
			get; set;
		}

		[CultureSpecific]
		[Display(
			Name = "Logo Link Aria Label",
			Description = "",
			GroupName = PageTabs.Navigation,
			Order = 160)]
		public virtual string? LogoLinkAriaLabel
		{
			get; set;
		}

	}
}