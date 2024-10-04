using JaxonFoundation.Logic.Constants;
using JaxonFoundation.Logic.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace JaxonFoundation.Logic.Models.Pages.Base
{
	public partial class BasePage
	{
		[CultureSpecific]
		[Display(Name = "Hero", Description = "", GroupName = PageTabs.PageContent, Order = 10)]
		[AllowedTypes(new[] { typeof(IHeroBlock) })]
		public virtual ContentArea Hero { get; set; }

		[CultureSpecific]
		[Display(Name = "Main Content", Description = "", GroupName = PageTabs.PageContent, Order = 20)]
        
        public virtual ContentArea MainContent { get; set; }

		[Ignore]
		public bool HasHero => Hero != null && !Hero.IsEmpty;

		[Ignore]
		public bool HasMainContent => MainContent != null && !MainContent.IsEmpty;
	}
}
