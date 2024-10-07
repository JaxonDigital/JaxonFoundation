using EPiServer.Web;
using Geta.Optimizely.ContentTypeIcons.Attributes;
using Geta.Optimizely.ContentTypeIcons;
using JaxonFoundation.Logic.Constants;
using JaxonFoundation.Logic.Interfaces.Descriptors;
using System.ComponentModel.DataAnnotations;
using JaxonFoundation.Infrastructure;
using JaxonFoundation.Logic.Validators.DataAnnotations;
using JaxonFoundation.Logic.Navigation.Models;
using JaxonFoundation.Logic.Models.Media;
using JaxonFoundation.Logic.Models.Navigation;

namespace JaxonFoundation.Logic.Models.Pages
{
    [Access(Roles = "CmsAdmins")]
    [ContentType(DisplayName = "Site Configuration", GUID = "805D077A-B1FD-4BE3-8DC4-930B7FAC41BD",
		Description = "Site Configurations and Settings such Google Script, Robots.txt, Headers, and Footers",
		GroupName = PageGroups.UtilityPages)]
    [AvailableContentTypes(Availability.None, IncludeOn = new[] { typeof(HomePage) })]
    [ContentTypeIcon(FontAwesome5Solid.Cogs)]
	[AllowedInstances(1, Scope = AllowedInstancesAttribute.InstanceScope.SameParentOrDescendant)]

	public class SiteConfigurationPage : PageData, ISiteConfigurationPageIcon , IAllPropertiesView
    {
        public override void SetDefaultValues(EPiServer.DataAbstraction.ContentType contentType)
        {
            base.SetDefaultValues(contentType);
            this.VisibleInMenu = false;
        }

        [CultureSpecific]
		[Display(Name = "Google Analytics Identifier", Description = "Unique Id for GA Scripts", GroupName = "Site Settings", Order = 100)]
		public virtual string? GoogleAnanlyticsId { get; set; }

		#region Robots.txt
		[UIHint(UIHint.Textarea)]
		[Display(Name = "Robots.txt", Description = "Define the robots txt rules for the page", GroupName ="Site Settings", Order = 200)]
		public virtual string? RobotsTxt { get; set; }
        #endregion

        [Display(Name = "CSS Body Class", Description = "Used for targeting site specific CSS rules", GroupName = "Site Settings", Order = 300)]
        public virtual string? CssBodyClass { get; set; }


        [CultureSpecific]
        [Display(
         Name = "Favicon",
         Description = "32 x 32",
         GroupName = "Site Settings",
         Order = 400)]
        [UIHint(UIHint.Image)]
        [AllowedTypes(typeof(ImageFile))]
        public virtual ContentReference? Favicon { get; set; }
        [CultureSpecific]
        [Display(
            Name = "Apple Touch Icon",
            Description = "180x180",
            GroupName = "Site Settings",
            Order = 500)]
        [UIHint(UIHint.Image)]
        [AllowedTypes(typeof(ImageFile))]
        public virtual ContentReference? AppleTouch { get; set; }

        #region Navigation
        [CultureSpecific]
        [Display(
           Name = "Header",
           Description = "The header and main navigation for all pages under this home page.",
           GroupName = PageTabs.Navigation,
           Order = 100)]
        [AllowedTypes(typeof(HeaderBlock))]
        [MaxItemCount(1)]
        public virtual ContentArea? Header
        {
            get; set;
        }

        [CultureSpecific]
        [Display(
          Name = "Footer",
          Description = "The Footer including copyright, disclaimers, links, etc...",
          GroupName = PageTabs.Navigation,
          Order = 100)]
        [AllowedTypes(typeof(FooterBlock))]
        [MaxItemCount(1)]
        public virtual ContentArea? Footer
        {
            get; set;
        }
        #endregion
    }
}
