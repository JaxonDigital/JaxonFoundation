namespace JaxonFoundation.Logic.ViewModels.Navigation
{
    public class HomePageViewModel
    {
        public ContentArea? Header
        {
            get;
            set;
        }

        public ContentArea? Footer
        {
            get;
            set;
        }

        public bool HasHeaderContent => Header != null && Header.FilteredItems.Any();

        public bool HasFooterContent => Footer != null && Footer.FilteredItems.Any();
    }
}
