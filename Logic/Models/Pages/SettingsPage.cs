using EPiServer.Web;
using Geta.Optimizely.ContentTypeIcons.Attributes;
using Geta.Optimizely.ContentTypeIcons;
using JaxonFoundation.Logic.Constants;
using JaxonFoundation.Logic.Interfaces.Descriptors;
using JaxonFoundation.Logic.Models.Pages.Base;
using System.ComponentModel.DataAnnotations;

namespace JaxonFoundation.Logic.Models.Pages
{
	[ContentType(DisplayName = "Settings", GUID = "805D077A-B1FD-4BE3-8DC4-930B7FAC41BD",
		Description = "Global Site Settings such Google Script and Robots.txt",
		GroupName = PageGroups.UtilityPages)]
    [AvailableContentTypes(Availability.Specific, ExcludeOn = new[] { typeof(BasePage) })]
	[ContentTypeIcon(FontAwesome5Solid.Cog)]
	
	public class SettingsPage : BasePage, ISettingsPageIconDescriptor
	{
		[CultureSpecific]
		[UIHint(UIHint.Textarea)]
		[Display(Name = "Google Analytics Identifier", Description = "Unique Id for GA Scripts", GroupName = SystemTabNames.Settings, Order = 100)]
		public virtual string? GoogleAnanlyticsId { get; set; }

		#region Robots.txt
		[UIHint(UIHint.Textarea)]
		[Display(Name = "Robots.txt Context", Description = "Define the robots txt rules for the page", GroupName = SystemTabNames.Settings, Order = 200)]
		public virtual string? RobotsTxtContext { get; set; }
		#endregion
	}
}
