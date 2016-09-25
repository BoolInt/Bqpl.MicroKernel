using Bqpl.Contracts;
using System;

namespace Bqpl.MicroKernel
{
  public static class ClassExtensions
  {
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
    public static void ThrowIfNull<TException>(this object instance, string message)
      where TException : Exception
    {
      Ensures.NotNull(instance);

      Verification.ThrowIfNull<TException>(instance, message);
    }
  }
}