using EPiServer.Security;
using System.ComponentModel.DataAnnotations;

namespace JaxonFoundation.Logic.Constants
{
    public static class MediaTabs
    {

        [Display(Name = "Media Content", Order = 100)]
        [RequiredAccess(AccessLevel.Edit)]
        public const string MediaContent = "Media Content";

        [Display(Name = "Metadata", Order = 200)]
        [RequiredAccess(AccessLevel.Edit)]
        public const string Metadata = "Metadata";

        [Display(Name = "Translations", Order = 500)]
        [RequiredAccess(AccessLevel.Edit)]
        public const string Translations = "Translations";

    }
}
