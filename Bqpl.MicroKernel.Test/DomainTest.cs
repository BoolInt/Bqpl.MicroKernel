using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bqpl.MicroKernel.Test
{
  [TestFixture]
  public class DomainTest
  {
    [Test]
    public void DomainsNotSame()
    {
      var domain = Domain.CreateInstance();
      var domain2 = Domain.CreateInstance();
      Assert.AreNotSame(domain, domain2);
    }

    [Test]
    public void Sample()
    {
      var domain = Domain.CreateInstance();
      Assert.NotNull(domain);
    }
  }
}