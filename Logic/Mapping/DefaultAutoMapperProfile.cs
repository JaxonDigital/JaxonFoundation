using AutoMapper;
using JaxonFoundation.Logic.Models.Pages;
using JaxonFoundation.Logic.Models.Pages.Base;
using JaxonFoundation.Logic.ViewModels.Navigation;


namespace Oxy.Com.Logic.Mapping
{
	public class DefaultAutoMapperProfile : Profile
	{
		public DefaultAutoMapperProfile()
		{
            //// Pages
            CreateMap<HomePage, HomePageViewModel>();
           
        }
	}
}
