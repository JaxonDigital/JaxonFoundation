using AutoMapper;

namespace JaxonFoundation.Logic.Mapping
{
	public class AutoMapperInit
	{
		public static void Initialize()
		{
			MapperConfiguration config = new MapperConfiguration(cfg => {
				cfg.AddProfile<DefaultAutoMapperProfile>();
			});

			IMapper mapper = config.CreateMapper();
		}
	}
}
