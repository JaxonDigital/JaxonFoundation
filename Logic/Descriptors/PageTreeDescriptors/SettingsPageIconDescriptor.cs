using EPiServer.Shell;
using JaxonFoundation.Logic.Constants;
using JaxonFoundation.Logic.Interfaces.Descriptors;

namespace JaxonFoundation.Logic.Descriptors.PageTreeDescriptors
{
	[UIDescriptorRegistration]
	public class SettingsPageIconDescriptor : UIDescriptor<ISettingsPageIconDescriptor>
    {
        /// <summary>
		/// Sets an icon for the home page.
		/// A full list of icons can be found here: http://ux.episerver.com/#icons
		/// </summary>
		public SettingsPageIconDescriptor()
        {
            IconClass = EpiserverDefaultContentIcons.ActionIcons.Settings;
        }
    }
}
