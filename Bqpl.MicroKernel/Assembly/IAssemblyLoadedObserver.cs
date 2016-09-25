using System.Reflection;

namespace Bqpl.MicroKernel
{
  internal interface IAssemblyLoadedObserver
  {
    void HandleAssemblyLoaded(Assembly assembly);
  }
}