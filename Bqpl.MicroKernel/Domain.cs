using Microsoft.Practices.Unity;

namespace Bqpl.MicroKernel
{
  public class Domain
  {
    private LoadedAssemblyWatcher loadedAssemblyWatcher;
    private UnityContainer unityContainer;

    private Domain()
    {
    }

    private LoadedAssemblyWatcher LoadedAssemblyWatcher
    {
      get
      {
        return Lazy.GetOrCreate(ref loadedAssemblyWatcher);
      }
    }

    private UnityContainer UnityContainer
    {
      get
      {
        return Lazy.GetOrCreate(ref unityContainer);
      }
    }

    public static Domain CreateInstance()
    {
      var domain = new Domain();
      domain.Initialize();
      return domain;
    }

    public T Resolve<T>()
    {
      return UnityContainer.Resolve<T>();
    }

    private void Initialize()
    {
      UnityContainer.RegisterInstance<IUnityContainer>(UnityContainer);

      UnityContainer.RegisterType<IResolveProvider, ResolveProvider>();
      UnityContainer.RegisterType<IRegisterProvider, RegisterProvider>();

      LoadedAssemblyWatcher.BeginMonitoring();

      LoadedAssemblyWatcher.Register(Resolve<ServiceAttributeAssemblyLoadedObserver>());
    }
  }
}