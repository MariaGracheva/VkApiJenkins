using NUnit.Extension.DependencyInjection;
using NUnit.Extension.DependencyInjection.Abstractions;
using NUnit.Extension.DependencyInjection.Unity;
using Unity;
using VkApi.Pages;

[assembly: NUnitTypeInjectionFactory(typeof(UnityInjectionFactory))]
[assembly: NUnitTypeDiscoverer(typeof(IocRegistrarTypeDiscoverer))]
namespace VkApi.DI
{
    public class IOC : RegistrarBase<IUnityContainer>
    {
        protected override void RegisterInternal(IUnityContainer container)
        {
            container.RegisterType<MainPage>()
                .RegisterType<EnterPasswordPage>()
                .RegisterType<NewsPage>()
                .RegisterType<ProfilePage>();
        }
    }
}