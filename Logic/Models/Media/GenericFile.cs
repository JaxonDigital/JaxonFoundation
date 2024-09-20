using EPiServer.Framework.DataAnnotations;
using EPiServer.Web;
using System.ComponentModel.DataAnnotations;
using JaxonFoundation.Logic.Constants;

namespace JaxonFoundation.Logic.Models.Media
{
    [ContentType(DisplayName = "File", GUID = "3D5D549D-3A2F-4CCA-98A3-CD65C4A8429D")]
    [MediaDescriptor(ExtensionString = "pdf,pptx,tif,doc,docx,zip,pem")]
    public class GenericFile : MediaData
    {
        #region Media Content

        [Editable(true)]
        [CultureSpecific]
        [Display(Name = "Title", Description = "Optional Title to be displayed instead of name", GroupName = MediaTabs.MediaContent, Order = 10)]
        public virtual string? DisplayName { get; set; }

        [Editable(true)]
        [CultureSpecific]
        [Display(Name = "Description", Description = "Displayed in search summary", GroupName = MediaTabs.MediaContent, Order = 20)]
        [UIHint(UIHint.Textarea)]
        public virtual string? Description { get; set; }

        [Editable(true)]
        [CultureSpecific]
        [Display(Name = "Link Text", GroupName = MediaTabs.MediaContent, Order = 30)]
        public virtual string? LinkText { get; set; }

        [Editable(true)]
        [CultureSpecific]
        [Display(Name = "Aria Label", GroupName = MediaTabs.MediaContent, Order = 40)]
        public virtual string? AriaLabel { get; set; }

        [CultureSpecific]
        [UIHint(UIHint.Image)]
        [Display(Name = "Preview Image", GroupName = MediaTabs.MediaContent, Order = 50)]
        public virtual ContentReference? PreviewImage { get; set; }

        #endregion

        #region Metadata

        [CultureSpecific]
        [Display(Name = "Hide from Search", Description = "", GroupName = PageTabs.Metadata, Order = 1)]
        public virtual bool HideFromSearch { get; set; }

        [Editable(false)]
        [Display(Name = "File size", GroupName = MediaTabs.Metadata, Order = 3)]
        public virtual string? FileSize { get; set; }

        [Editable(false)]
        [Display(Name = "File type", GroupName = MediaTabs.Metadata, Order = 4)]
        public virtual string? FileType { get; set; }

        #endregion

        [Ignore]
        public string SearchTitle => DisplayName ?? Name;

        [Ignore]
        public string? SearchSummary => Description;

        [Ignore]
        public string LinkTextOutput => LinkText ?? Name;

        [Ignore]
        public bool HasPreviewImage => PreviewImage != null && PreviewImage != ContentReference.EmptyReference;
    }
}