using NUnit.Framework;

namespace Bqpl.MicroKernel.Test
{
  [TestFixture]
  public class ServiceTest
  {
    private interface ISampleService
    {
    }

    [Test]
    public void Sample()
    {
      var domain = Domain.CreateInstance();
      var sampleService = domain.Resolve<ISampleService>();

      Assert.NotNull(sampleService);
    }

    [Service]
    private class SampleService : ISampleService
    {
    }
  }
}