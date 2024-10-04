using EPiServer.Web.Routing;
using Microsoft.AspNetCore.Mvc;
using JaxonFoundation.Infrastructure;
using System;



namespace JaxonFoundation.Logic.Controllers
{
    public class FaviconController : Controller
    {

        // GET: Favicon
        [Route ("/favicon.ico")]
        public ActionResult Index()
        {
            var configurationPage = SiteConfiguration.GetSiteConfiguration(ContentReference.StartPage);
            var favRef = configurationPage?.Favicon;
            if (favRef == null)
            {
                return File("~/favicon.ico", "image/x-icon");
            }
            // If we have a favicon set in the CMS, get the url to the contentref and redirect to the uploaded asset //
            var faviconUrl = UrlResolver.Current.GetUrl(favRef);
            if (string.IsNullOrWhiteSpace(faviconUrl)) { return Content(""); }

            return Redirect(faviconUrl);
        }
    }
}

