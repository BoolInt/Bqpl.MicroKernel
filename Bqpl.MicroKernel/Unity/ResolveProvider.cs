using Microsoft.Practices.Unity;

namespace Bqpl.MicroKernel
{
  [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses")]
  internal class ResolveProvider : IResolveProvider
  {
    public ResolveProvider(IUnityContainer unityContainer)
    {
      UnityContainer = unityContainer;
    }

    private IUnityContainer UnityContainer { get; }

    public T Resolve<T>()
    {
      return UnityContainer.Resolve<T>();
    }
  }
}