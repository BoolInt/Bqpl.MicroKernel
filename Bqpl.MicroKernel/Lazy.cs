using Bqpl.Contracts;
using System;

namespace Bqpl.MicroKernel
{
  public static class Lazy
  {
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference", MessageId = "0#")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object)")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId = "Bqpl.MicroKernel.ClassExtensions.ThrowIfNull<System.InvalidOperationException>(System.Object,System.String)")]
    public static T GetOrCreate<T>(ref T instance, Func<T> createFunction)
      where T : class
    {
      Argument.NotNull(nameof(createFunction), createFunction);
      Result.NotNull<T>();

      if (instance == null)
      {
        instance = createFunction();
        instance.ThrowIfNull<InvalidOperationException>($"Die Funktion '{nameof(createFunction)}' darf nicht 'null' zurückgeben.");
      }
      return instance;
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference", MessageId = "0#")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object)")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId = "Bqpl.MicroKernel.ClassExtensions.ThrowIfNull<System.InvalidOperationException>(System.Object,System.String)")]
    public static T GetOrCreate<T>(ref T? instance, Func<T> createFunction)
      where T : struct
    {
      Argument.NotNull(nameof(createFunction), createFunction);
      //Result.NotNull<T>();

      if (instance == null)
      {
        instance = createFunction();
        instance.ThrowIfNull<InvalidOperationException>($"Die Funktion '{nameof(createFunction)}' darf nicht 'null' zurückgeben.");
      }
      return instance.Value;
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference", MessageId = "0#")]
    public static T GetOrCreate<T>(ref T instance)
      where T : class, new()
    {
      Result.NotNull<T>();

      return GetOrCreate(ref instance, () => new T());
    }
  }
}