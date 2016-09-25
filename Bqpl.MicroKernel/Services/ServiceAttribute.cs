using System;

namespace Bqpl.MicroKernel
{
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
  public sealed class ServiceAttribute : Attribute
  {
  }
}