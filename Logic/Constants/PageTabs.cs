using EPiServer.Security;
using System.ComponentModel.DataAnnotations;

namespace JaxonFoundation.Logic.Constants
{
    [GroupDefinitions]
    public class PageTabs
    {
        [Display(Name = "Content", Order = 10)]
        [RequiredAccess(AccessLevel.Edit)]
        public const string Content = "Content";

        [Display(Order = 15)]
        [RequiredAccess(AccessLevel.Edit)]
        public const string Navigation = "Navigation";

        [Display(Name = "Metadata", Order = 20)]
        [RequiredAccess(AccessLevel.Edit)]
        public const string Metadata = "Metadata";

        [Display(Name = "Configuration", Order = 25)]
        [RequiredAccess(AccessLevel.Edit)]
        public const string Configuration = "Configuration";

        [Display(Name = "Sitedata", Order = 600)]
        [RequiredAccess(AccessLevel.Edit)]
        public const string Sitedata = "Sitedata";
    }
}
