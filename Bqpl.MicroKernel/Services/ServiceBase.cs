using Microsoft.Practices.Unity;

namespace Bqpl.MicroKernel
{
  public class ServiceBase
  {
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
    [Dependency]
    protected internal IResolveProvider ResolveProvider { get; internal set; }

    protected T Resolve<T>()
    {
      return ResolveProvider.Resolve<T>();
    }
  }
}