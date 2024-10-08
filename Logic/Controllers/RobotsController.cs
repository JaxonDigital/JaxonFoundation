﻿using Microsoft.AspNetCore.Mvc;
using Geta.Optimizely.Sitemaps.Repositories;
using Geta.Optimizely.Sitemaps.Entities;
using System.Text;
using JaxonFoundation.Infrastructure;
using JaxonFoundation.Logic.Models.Pages.Base;

namespace JaxonFoundation.Logic.Controllers
{
    public class RobotsController : Controller
    {
        private readonly ISitemapRepository _sitemapRepository;

        public RobotsController(ISitemapRepository sitemapRepository, IContentLoader contentLoader, IConfiguration configuration)
        {
            this._sitemapRepository = sitemapRepository;
        }

        [Route("robots.txt")]
        public ActionResult Index()
        {
            if (Environment.IsProd())
                return Public();
            else
                return Private();
        }

        public ActionResult Public()
        {
            string? configurationPageRobots = String.Empty;
            var configurationPage = SiteConfiguration.GetSiteConfiguration(ContentReference.StartPage);

            configurationPageRobots = configurationPage?.RobotsTxt;

            string fullOrigin = "https://" + this.HttpContext.Request.Host.Value.ToString() + "/";
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(configurationPageRobots);
            stringBuilder.AppendLine("");
            foreach (SitemapData sitemapData in this._sitemapRepository.GetAllSitemapData())
            {
                if (fullOrigin == sitemapData.SiteUrl)
                {
                    stringBuilder.AppendLine(@"Sitemap: " + this._sitemapRepository.GetSitemapUrl(sitemapData));
                }
            }

            //Fetch all content pages that should not let crawlers access it
            return Content(stringBuilder.ToString(), "text/plain");
        }

        public ActionResult Private()
        {
            string fullOrigin = "https://" + this.HttpContext.Request.Host.Value.ToString() + "/";
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(@"User-agent: *");
            stringBuilder.AppendLine(@"Disallow: /");

            // Comment Out this Foreach when deployed
            //foreach (SitemapData sitemapData in this._sitemapRepository.GetAllSitemapData())
            //{

            //    if (fullOrigin == sitemapData.SiteUrl)
            //    {
            //        stringBuilder.AppendLine(@"Sitemap: " + this._sitemapRepository.GetSitemapUrl(sitemapData));
            //    }
            //}
            return Content(stringBuilder.ToString(), "text/plain");
        }

    }
}
