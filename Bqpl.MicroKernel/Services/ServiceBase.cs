using Bqpl.Contracts;
using Microsoft.Practices.Unity;
using System;

namespace Bqpl.MicroKernel
{
  public class ServiceBase
  {
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
    private IResolveProvider resolveProvider;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object)")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId = "Bqpl.MicroKernel.Verification.ThrowIfNull<System.InvalidOperationException>(System.Object,System.String)")]
    [Dependency]
    protected internal IResolveProvider ResolveProvider
    {
      get
      {
        Result.NotNull<IResolveProvider>();

        Verification.ThrowIfNull<InvalidOperationException>(resolveProvider, $"Eigenschaft '{nameof(ResolveProvider)}' wurde nicht wie erwartet injiziert.");
        return resolveProvider;
      }
      internal set
      {
        resolveProvider = value;
      }
    }

    protected T Resolve<T>()
    {
      return ResolveProvider.Resolve<T>();
    }
  }
}