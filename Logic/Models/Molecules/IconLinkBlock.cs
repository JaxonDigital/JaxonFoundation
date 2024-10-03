using JaxonFoundation.Models.Molecules;
using System.ComponentModel.DataAnnotations;

namespace JaxonFoundation.Logic.Models.Molecules
{
	[ImageUrl("~/static/images/thumbnails/Image-Link-Block.png")]
	[ContentType(DisplayName = "IconLinkBlock", GUID = "29E7E41D-24B1-439F-8B6A-21A9916D19AA", Description = "")]
	public class IconLinkBlock : LinkBlock
	{
		[CultureSpecific]
		[Display(Name = "Icon Label", Description = "Displays icon for the appropriate social channel based on the label", GroupName = "Block Content", Order = 5)]
		public virtual string IconLabel { get; set; }

		//Since the footer links doesn't need the text, this has been hidden.
		[ScaffoldColumn(false)]
		public override string Text { get => base.Text; set => base.Text = value; }
	}
}