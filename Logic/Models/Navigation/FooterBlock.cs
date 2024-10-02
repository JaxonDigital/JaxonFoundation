using EPiServer.Web;
using Geta.Optimizely.ContentTypeIcons.Attributes;
using Geta.Optimizely.ContentTypeIcons;
using JaxonFoundation.Logic.Constants;
using JaxonFoundation.Logic.Models.Blocks;
using JaxonFoundation.Logic.Models.Media;
using System.ComponentModel.DataAnnotations;

namespace JaxonFoundation.Logic.Models.Navigation
{
    [ContentType(
        DisplayName = "Footer",
        GUID = "FBD07C5E-3580-411C-9883-9E9FD052B023",
        Description = "To provide users with links, social media links and copyright",
        GroupName = BlockGroups.NavigationBlocks)]
    [ContentTypeIcon(FontAwesome5Solid.PollH)]
    public class FooterBlock : StandardBlockBase
    {
        [CultureSpecific]
        [Display(
            Name = "Logo",
            Description = "123x64",
            GroupName = "Block Content",
            Order = 10)]
        [UIHint(UIHint.Image)]
        [AllowedTypes(typeof(ImageFile))]
        public virtual ContentReference Logo { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Copyright",
            Description = "Legal copyright text",
            GroupName = "Block Content",
            Order = 15)]
        public virtual string Copyright
        {
            get; set;
        }

        //[CultureSpecific]
        //[Display(
        //    Name = "Links",
        //    Description = "Collection of legal links",
        //    GroupName = BlockTabs.BlockContent,
        //    Order = 20)]
        //[AllowedTypes(new[] { typeof(LinkBlock) }, restrictedTypes: new[] { typeof(IconLinkBlock) })]
        //public virtual ContentArea Links
        //{
        //    get; set;
        //}

        [CultureSpecific]
        [Display(
            Name = "Social Links Headline",
            Description = "Social Links Headline",
            GroupName = "Block Content",
            Order = 30)]
        public virtual string SocialLinksHeadline
        {
            get; set;
        }

        //[CultureSpecific]
        //[Display(
        //    Name = "Social Links",
        //    Description = "Collection of Social Links",
        //    GroupName = BlockTabs.BlockContent,
        //    Order = 40)]
        //[AllowedTypes(new[] { typeof(IconLinkBlock) })]
        //public virtual ContentArea SocialLinks
        //{
        //    get; set;
        //}

        [CultureSpecific]
        [Display(
            Name = "Back to top",
            Description = "Back to top text",
            GroupName = "Block Content",
            Order = 50)]
        public virtual string BackToTop
        {
            get; set;
        }

        [CultureSpecific]
        [Display(
            Name = "Logo Link Aria Label",
            Description = "",
            GroupName = "Block Content",
            Order = 60)]
        public virtual string LogoLinkAriaLabel
        {
            get; set;
        }
    }
}