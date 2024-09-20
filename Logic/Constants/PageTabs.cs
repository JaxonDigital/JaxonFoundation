using EPiServer.Security;
using System.ComponentModel.DataAnnotations;

namespace JaxonFoundation.Logic.Constants
{
    public class PageTabs
    {
        [Display(Name = "Page Content", Order = 100)]
        [RequiredAccess(AccessLevel.Edit)]
        public const string PageContent = "Page Content";

        [Display(Order = 110)]
        [RequiredAccess(AccessLevel.Edit)]
        public const string Navigation = "Navigation";

        [Display(Name = "Metadata", Order = 200)]
        [RequiredAccess(AccessLevel.Edit)]
        public const string Metadata = "Metadata";

        [Display(Name = "Sitedata", Order = 600)]
        [RequiredAccess(AccessLevel.Edit)]
        public const string Sitedata = "Sitedata";
    }
}
