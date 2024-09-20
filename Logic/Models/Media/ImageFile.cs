using JaxonFoundation.Logic.Interfaces;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web;
using System.ComponentModel.DataAnnotations;
using JaxonFoundation.Logic.Constants;

namespace JaxonFoundation.Logic.Models.Media
{
    [ContentType(DisplayName = "Image", GUID = "0F7A16B8-EF7B-48A1-8D57-896F4A16EE5B")]
    [MediaDescriptor(ExtensionString = "jpg,jpeg,jpe,ico,gif,bmp,png")]
    public class ImageFile : ImageData, MediaFile
    {
        #region Media Content

        [Ignore]
        [Editable(true)]
        [CultureSpecific]
        [Display(Name = "Display name", GroupName = MediaTabs.MediaContent, Order = 10)]
        public virtual string? DisplayName { get; set; }

        [Editable(true)]
        [CultureSpecific]
        [Display(Name = "Alt text", GroupName = MediaTabs.MediaContent, Order = 20)]
        [UIHint(UIHint.Textarea)]
        public virtual string? Description { get; set; }

        [Editable(true)]
        [CultureSpecific]
        [Display(Name = "Download Aria Label", GroupName = MediaTabs.MediaContent, Order = 30)]
        public virtual string? DownloadAriaLabel { get; set; }

        #endregion

        #region Metadata

        [CultureSpecific]
        [Display(Name = "Hide from Search", GroupName = PageTabs.Metadata, Order = 10)]
        public virtual bool HideFromSearch { get; set; }


        [Editable(false)]
        [Display(Name = "File size", GroupName = MediaTabs.Metadata, Order = 20)]
        public virtual string? FileSize { get; set; }

        [Editable(false)]
        [Display(Name = "File type", GroupName = MediaTabs.Metadata, Order = 30)]
        public virtual string? FileType { get; set; }

        #endregion

        [Ignore]
        public string SearchTitle => Name;

        [Ignore]
        public string? SearchSummary => Description;

        [Ignore]
        public string AriaLabel => SearchTitle;


        [Ignore]
        public bool HasPreviewImage => true;
    }
}