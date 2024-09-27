using Geta.Optimizely.ContentTypeIcons.Attributes;
using Geta.Optimizely.ContentTypeIcons;
using JaxonFoundation.Logic.Interfaces.Descriptors;
using JaxonFoundation.Logic.Models.Pages.Base;
using System.ComponentModel.DataAnnotations;

namespace JaxonFoundation.Logic.Models.Pages
{
    [ContentType(DisplayName = "Home Page", GUID = "B078BAD6-0041-4807-934D-C24DDE8D0F20", Description = "The home page of the website. Contains Top Navigation, Main Navigation, Footer and Search")]
    [AvailableContentTypes(Availability.Specific, ExcludeOn = new[] { typeof(BasePage) })]
	[ContentTypeIcon(FontAwesome5Solid.Home)]
	public class HomePage : BasePage, IHomePageIcon
    {
        [CultureSpecific]
        [Display(
      Name = "Title",
      Description = "Title for the page",
      GroupName = SystemTabNames.Content,
      Order = 1)]
        public virtual string? Title
        {
            get;
            set;
        }
    }
}
