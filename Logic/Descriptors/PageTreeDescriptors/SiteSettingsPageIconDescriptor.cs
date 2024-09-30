using EPiServer.Shell;
using JaxonFoundation.Logic.Constants;
using JaxonFoundation.Logic.Interfaces.Descriptors;

namespace JaxonFoundation.Logic.Descriptors.PageTreeDescriptors
{
	[UIDescriptorRegistration]
	public class SiteSettingsPageIconDescriptor : UIDescriptor<ISiteSettingsPageIcon>
    {
        /// <summary>
		/// Sets an icon for the home page.
		/// A full list of icons can be found here: http://ux.episerver.com/#icons
		/// </summary>
		public SiteSettingsPageIconDescriptor()
        {
            IconClass = EpiserverDefaultContentIcons.ActionIcons.Settings;
        }
    }
}
