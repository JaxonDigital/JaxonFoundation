using EPiServer.Shell;
using JaxonFoundation.Logic.Interfaces.Descriptors;

namespace JaxonFoundation.Logic.Descriptors.EditorDescriptors
{
    [UIDescriptorRegistration]
    public class AllPropertiesView : UIDescriptor<IAllPropertiesView>
    {
        /// <summary>
        /// Sets an icon for the home page.
        /// A full list of icons can be found here: http://ux.episerver.com/#icons
        /// </summary>
        public AllPropertiesView()
        {
            DefaultView = CmsViewNames.AllPropertiesView;
        }
    }
}
