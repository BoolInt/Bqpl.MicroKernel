using Bqpl.Contracts;
using System;
using System.Collections.Concurrent;
using System.Reflection;

namespace Bqpl.MicroKernel
{
  [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses")]
  internal class LoadedAssemblyWatcher
  {
    private BlockingCollection<Assembly> LoadedAssemblyCollection { get; } = new BlockingCollection<Assembly>();

    private BlockingCollection<IAssemblyLoadedObserver> ObserverCollection { get; } = new BlockingCollection<IAssemblyLoadedObserver>();

    internal void BeginMonitoring()
    {
      foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        HandleLoadedAssembly(assembly);
      AppDomain.CurrentDomain.AssemblyLoad += CurrentDomain_AssemblyLoad;
    }

    internal void EndMonitoring()
    {
      AppDomain.CurrentDomain.AssemblyLoad -= CurrentDomain_AssemblyLoad;
    }

    internal void Register(IAssemblyLoadedObserver observer)
    {
      Argument.NotNull(nameof(observer), observer);

      ObserverCollection.Add(observer);
      foreach (var assembly in LoadedAssemblyCollection)
        observer.HandleAssemblyLoaded(assembly);
    }

    private void CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
    {
      HandleLoadedAssembly(args.LoadedAssembly);
    }

    private void HandleLoadedAssembly(Assembly loadedAssembly)
    {
      LoadedAssemblyCollection.Add(loadedAssembly);
      foreach (var observer in ObserverCollection)
        observer.HandleAssemblyLoaded(loadedAssembly);
    }
  }
}