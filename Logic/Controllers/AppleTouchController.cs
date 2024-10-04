using EPiServer.Web.Routing;
using Microsoft.AspNetCore.Mvc;
using JaxonFoundation.Infrastructure;
using System;



namespace JaxonFoundation.Logic.Controllers
{
    public class AppleTouchController : Controller
    {

        // GET: Favicon
        [Route ("/apple-touch-icon.png")]
        public ActionResult Index()
        {
            var configurationPage = SiteConfiguration.GetSiteConfiguration(ContentReference.StartPage);
            var favRef = configurationPage?.Favicon;
            if (favRef == null)
            {
                return File("~/apple-touch-icon.png", "image/png");
            }
            // If we have a favicon set in the CMS, get the url to the contentref and redirect to the uploaded asset //
            var faviconUrl = UrlResolver.Current.GetUrl(favRef);
            if (string.IsNullOrWhiteSpace(faviconUrl)) { return Content(""); }

            return Redirect(faviconUrl);
        }
    }
}

