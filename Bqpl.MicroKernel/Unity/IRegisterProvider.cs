using System;

namespace Bqpl.MicroKernel
{
  public interface IRegisterProvider
  {
    void RegisterInstance(object instance);

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
    void RegisterType<TInterface, TImplementation>()
      where TImplementation : TInterface;

    void RegisterType(Type interfaceType, Type implementationType);

    void RegisterTypeContainerControlled(Type interfaceType, Type implementationType);
  }
}