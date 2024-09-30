using Geta.Optimizely.ContentTypeIcons.Attributes;
using Geta.Optimizely.ContentTypeIcons;
using JaxonFoundation.Logic.Interfaces.Descriptors;
using JaxonFoundation.Logic.Models.Pages.Base;
using System.ComponentModel.DataAnnotations;

namespace JaxonFoundation.Logic.Models.Pages
{
    [ContentType(DisplayName = "Standard Page", GUID = "F500A21D-9EB8-4344-B900-244A7DC2E0E0", Description = "Standard Page Type")]

    [AvailableContentTypes(Availability.Specific, IncludeOn = new[] { typeof(HomePage) })]
    [ContentTypeIcon(FontAwesome5Solid.File)]
    public class StandardPage : BasePage
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