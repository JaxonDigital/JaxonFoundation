using EPiServer.Web.Mvc;
using JaxonFoundation.Logic.Models.Pages.Base;
using JaxonFoundation.Logic.Models.Pages;
using JaxonFoundation.Logic.ViewModels.Pages;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;




namespace JaxonFoundation.Logic.Controllers.Pages
{
    public class HomePageController : PageController<HomePage>
    {
        public ActionResult Index(HomePage currentPage)
        {

            var viewModel = new PageViewModel<BasePage>(currentPage);

            return View(viewModel);
        }
    }
}