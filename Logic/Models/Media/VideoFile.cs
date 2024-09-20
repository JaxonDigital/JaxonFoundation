using EPiServer.Framework.DataAnnotations;
using EPiServer.Web;
using System.ComponentModel.DataAnnotations;
using JaxonFoundation.Logic.Constants;
using JaxonFoundation.Logic.Interfaces;

namespace JaxonFoundation.Logic.Models.Media
{
    [ContentType(DisplayName = "Video", GUID = "D033AA48-7B8B-4F48-B6B1-4FE70C005D76")]
    [MediaDescriptor(ExtensionString = "mp4")]
    public class VideoFile : VideoData, MediaFile
    {
        #region Media Content

        [Editable(true)]
        [CultureSpecific]
        [Display(Name = "Display name", GroupName = MediaTabs.MediaContent, Order = 1)]
        public virtual string? DisplayName { get; set; }

        [Editable(true)]
        [CultureSpecific]
        [Display(Name = "Description", GroupName = MediaTabs.MediaContent, Order = 2)]
        [UIHint(UIHint.Textarea)]
        public virtual string? Description { get; set; }

        [CultureSpecific]
        [UIHint(UIHint.Image)]
        [Display(Name = "Preview Image", GroupName = MediaTabs.MediaContent, Order = 3)]
        public virtual ContentReference? PreviewImage { get; set; }

        #endregion

        #region Metadata

        [CultureSpecific]
        [Display(Name = "Hide from Search", GroupName = PageTabs.Metadata, Order = 1)]
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
        public bool HasPreviewImage
        {
            get
            {
                return PreviewImage != null && PreviewImage != ContentReference.EmptyReference;
            }
        }
    }
}
