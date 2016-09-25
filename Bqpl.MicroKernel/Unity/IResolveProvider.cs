namespace Bqpl.MicroKernel
{
  public interface IResolveProvider
  {
    T Resolve<T>();
  }
}