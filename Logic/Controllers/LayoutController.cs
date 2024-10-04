using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc.Html;
using JaxonFoundation.Logic.Models.Pages.Base;
using JaxonFoundation.Logic.ViewModels.Pages;
using Microsoft.AspNetCore.Mvc;

namespace JaxonFoundation.Logic.Navigation.Controllers
{
    public class LayoutController : Controller
	{
		private readonly IContentLoader contentLoader;

		public LayoutController() : this(
			ServiceLocator.Current.GetInstance<IContentLoader>())
		{
		}

		public LayoutController(
			IContentLoader contentLoader)
		{
			this.contentLoader = contentLoader;
		}

		private PageViewModel<BasePage> GetPageViewModel(BasePage currentPage)
		{
			var viewModel = new PageViewModel<BasePage>(currentPage);

			var host = new Uri(Request.Path.Value);
			var leftPartURL = host.GetLeftPart(System.UriPartial.Authority);
			viewModel.SiteUrl = leftPartURL;
			viewModel.CanonicalUrl = host.ToString();

			if (viewModel.OpenGraphImage != null)
			{
				viewModel.OpenGraphImageUrl = Url.ContentUrl(viewModel.OpenGraphImage.ContentLink);
			}
			if (viewModel.TwitterCardImage != null)
			{
				viewModel.TwitterCardImageUrl = Url.ContentUrl(viewModel.TwitterCardImage.ContentLink);
			}
			return viewModel;
		}
	}
}
