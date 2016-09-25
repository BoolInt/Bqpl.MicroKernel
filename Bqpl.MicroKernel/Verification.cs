using Bqpl.Exceptions.Generic;
using System;

namespace Bqpl.MicroKernel
{
  public static class Verification
  {
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
    public static void ThrowIfNull<TException>(object instance, string message)
      where TException : Exception
    {
      if (instance == null)
        throw ExceptionActivator.Create<TException>(message);
    }
  }
}