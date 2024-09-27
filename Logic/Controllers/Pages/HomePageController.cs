using EPiServer.Web.Mvc;
using JaxonFoundation.Logic.Models.Pages.Base;
using JaxonFoundation.Logic.Models.Pages;
using JaxonFoundation.Logic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using EPiServer.Web.Routing;
using JaxonFoundation.Logic.ViewModels.Navigation;
using Oxy.Com.Logic.Navigation.Models;

namespace JaxonFoundation.Logic.Controllers.Pages
{
    public class HomePageController : PageController<HomePage>
    {
        private readonly IMapper _mapper;

        public HomePageController(IMapper mapper)
        {
            _mapper = mapper;
        }
        public ActionResult Index(HomePage currentPage)
        {
            
            var viewModel = _mapper.Map<HomePage, HomePageViewModel>(currentPage);
            viewModel.GoogleAnanlyticsId = "NotYetFinished";
            return View(viewModel);
        }
    }
}