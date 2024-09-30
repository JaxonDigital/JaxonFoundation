using AutoMapper;
using EPiServer.Framework;

namespace Oxy.Com.Logic.Mapping
{
	public static class AutoMapperInit
	{
		public static void Initialize()
		{
			var config = new MapperConfiguration(cfg => {
				cfg.AddProfile<DefaultAutoMapperProfile>();
			});

			var mapper = config.CreateMapper();
		}
	}
}