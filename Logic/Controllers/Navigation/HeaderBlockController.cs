//using JaxonFoundation.Logic.ViewModels;
//using JaxonFoundation.Logic.Models.Pages.Base;
//using Microsoft.AspNetCore.Mvc;
//using EPiServer.Web.Routing;
//using AutoMapper;
//using JaxonFoundation.Logic.Models.Pages;
//using JaxonFoundation.Logic.Interfaces;
//using JaxonFoundation.Logic.ViewModels.Navigation;
//using EPiServer.Web.Mvc;
//// using JaxonFoundation.Logic.Models.Pages.Error;


//namespace JaxonFoundation.Logic.Controllers.Base
//{
//    public class HeaderBlockController : AsyncBlockComponent<HeaderBlock>
//    {
//        private readonly IContentLoader _contentLoader;
//        private readonly IPageRouteHelper _pageRouteHelper;
//        private readonly IMapper _mapper;

//        public HeaderBlockController(IContentLoader contentLoader, IPageRouteHelper pageRouteHelper, IMapper mapper)
//        {
//            this._contentLoader = contentLoader;
//            this._pageRouteHelper = pageRouteHelper;
//            this._mapper = mapper;
//        }

//        //[ChildActionOnly]
//        public IViewComponentResult Invoke()
//        {
//            ContentReference currentPageReference = this._pageRouteHelper.ContentLink;

//            if (ContentReference.IsNullOrEmpty(currentPageReference))
//                return Content(String.Empty);

//            var currentPage = this._pageRouteHelper.Page;
//            BasePage homePage = GetHomePage((BasePage)currentPage);
//            var header = _mapper.Map<HomePage, HomePageViewModel>((HomePage)homePage);
//            return View("~/Views/Shared/A1Header.cshtml", header);
//        }


//        private BasePage GetHomePage(BasePage currentPage)
//        {
//            ContentReference contentLink = currentPage.ContentLink;
//            var homePage = this._contentLoader.GetAncestors(contentLink)
//                .OfType<BasePage>()
//                .SkipWhile(x => x.ParentLink == null || !x.PageTypeName.EndsWith("HomePage"))
//                .FirstOrDefault();
//            return homePage;
//        }

//    }
//}
