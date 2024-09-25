using AutoMapper;
using JaxonFoundation.Logic.Models.Pages;

namespace JaxonFoundation.Logic.Mapping
{
	public class DefaultAutoMapperProfile : Profile
	{
		public DefaultAutoMapperProfile()
		{
			// Pages 
			CreateMap<SettingsPage, DefaultAutoMapperProfile>();
		}

	}
}
