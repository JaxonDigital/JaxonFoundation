using JaxonFoundation.Logic.Constants;
using JaxonFoundation.Logic.Interfaces.Descriptors;
using JaxonFoundation.Logic.Models.Pages.Base;
using System.ComponentModel.DataAnnotations;

namespace JaxonFoundation.Logic.Models.Pages
{
    [ContentType(DisplayName = "Home Page", GUID = "B078BAD6-0041-4807-934D-C24DDE8D0F20", Description = "The home page of the website. Contains Top Navigation, Main Navigation, Footer and Search")]
    [AvailableContentTypes(Availability.Specific, ExcludeOn = new[] { typeof(BasePage) })]
    public class HomePage : BasePage, IHomePageIconDescriptor
    {
        [CultureSpecific]
        [Display(
           Name = "Header",
           Description = "The header and main navigation for all pages under this home page.",
           GroupName = PageTabs.Navigation,
           Order = 100)]
        public virtual ContentArea? Header
        {
            get; set;
        }

        [CultureSpecific]
        [Display(
            Name = "Footer",
            Description = "The footer navigation for all pages under this home page.",
            GroupName = PageTabs.Navigation,
            Order = 200)]
        public virtual ContentArea? Footer
        {
            get; set;
        }
    }
}
