//using EPiServer.Framework;
//using EPiServer.ServiceLocation;
//using EPiServer.Shell.ViewComposition;
//using JaxonFoundation.Logic.Models.Pages;

//namespace JaxonFoundation.Logic.InitializationModules
//{
//    [InitializableModule]
//    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
//    public class RestrictRoot : IInitializableModule
//    {
//        Injected<IContentTypeRepository> _contentTypeRepository;
//        public void Initialize(EPiServer.Framework.Initialization.InitializationEngine context)
//        {
//            var sysRoot = _contentTypeRepository.Service.Load("SysRoot") as PageType;
//            var homePage = _contentTypeRepository.Service.Load(typeof(HomePage));
//            var settingsPage = _contentTypeRepository.Service.Load(typeof(SettingsPage));
//            var setting = new AvailableSetting { Availability = Availability.Specific };
//            setting.AllowedContentTypeNames.Add(homePage.Name);
//            ServiceLocator.Current.GetInstance<IAvailableSettingsRepository>().RegisterSetting(sysRoot, setting);
//        }
//        public void Preload(string[] parameters)
//        {

//        }

//        public void Uninitialize(EPiServer.Framework.Initialization.InitializationEngine context)
//        {

//        }
//    }
//}
