using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bqpl.MicroKernel
{
  public class Domain
  {
    private UnityContainer unityContainer;

    private Domain()
    {
    }

    private UnityContainer UnityContainer
    {
      get
      {
        return Lazy.GetOrCreate(ref unityContainer);
      }
    }

    public static Domain CreateInstance()
    {
      var domain = new Domain();
      domain.Initialize();
      return domain;
    }

    public T Resolve<T>()
    {
      return UnityContainer.Resolve<T>();
    }

    private void Initialize()
    {
      UnityContainer.RegisterInstance(UnityContainer);
    }
  }
}