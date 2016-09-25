using System.Linq;
using System.Reflection;

namespace Bqpl.MicroKernel
{
  internal class ServiceAttributeAssemblyLoadedObserver : IAssemblyLoadedObserver
  {
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
    public ServiceAttributeAssemblyLoadedObserver(IRegisterProvider registerProvider)
    {
      RegisterProvider = registerProvider;
    }

    private IRegisterProvider RegisterProvider { get; }

    public void HandleAssemblyLoaded(Assembly assembly)
    {
      foreach (var type in assembly.GetTypes().Where(x => x.GetCustomAttribute<ServiceAttribute>() != null))
        RegisterProvider.RegisterType(type.GetInterfaces().Single(), type);
    }
  }
}