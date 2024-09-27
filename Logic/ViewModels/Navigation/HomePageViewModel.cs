using JaxonFoundation.Logic.Models.Pages;
using EPiServer.ServiceLocation;
using JaxonFoundation.Logic.Models.Pages.Base;

namespace JaxonFoundation.Logic.ViewModels.Navigation
{
    public class HomePageViewModel : PageViewModel<BasePage>
    {
        public HomePageViewModel(BasePage currentPage) : base(currentPage)
        {
        }


        public string? GoogleAnanlyticsId
        {
            get;
            set;
        }
        
        public string? Title
        {
            get;
            set;
        }
    }
}
