using EPiServer.Web.Mvc;
using JaxonFoundation.Logic.Models.Pages.Base;
using JaxonFoundation.Logic.Models.Pages;
using JaxonFoundation.Logic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JaxonFoundation.Logic.Controllers.Pages
{
	public class SettingsPageController : PageController<SettingsPage>
	{
        public ActionResult Index(SettingsPage currentPage)
		{
			var viewModel = new PageViewModel<BasePage>(currentPage);
			return View(currentPage);
		}
	}
}
