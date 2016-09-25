using Bqpl.Contracts;
using Microsoft.Practices.Unity;
using System;

namespace Bqpl.MicroKernel
{
  [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses")]
  internal class RegisterProvider : IRegisterProvider
  {
    public RegisterProvider(IUnityContainer unityContainer)
    {
      UnityContainer = unityContainer;
    }

    private IUnityContainer UnityContainer { get; }

    public void RegisterInstance(object instance)
    {
      Argument.NotNull(nameof(instance), instance);

      UnityContainer.RegisterInstance(instance.GetType(), instance);
    }

    public void RegisterType<TInterface, TImplementation>()
          where TImplementation : TInterface
    {
      UnityContainer.RegisterType<TInterface, TImplementation>();
    }

    public void RegisterType(Type interfaceType, Type implementationType)
    {
      Argument.NotNull(nameof(interfaceType), interfaceType);
      Argument.NotNull(nameof(implementationType), implementationType);

      UnityContainer.RegisterType(interfaceType, implementationType);
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Objekte verwerfen, bevor Bereich verloren geht")]
    public void RegisterTypeContainerControlled(Type interfaceType, Type implementationType)
    {
      Argument.NotNull(nameof(interfaceType), interfaceType);
      Argument.NotNull(nameof(implementationType), implementationType);

      UnityContainer.RegisterType(interfaceType, implementationType, new ContainerControlledLifetimeManager());
    }
  }
}