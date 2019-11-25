using System;
using System.Threading;
using HC.Core.Logic;
using HC.Plugins.Http;

namespace HC.PoC.Http
{
  public static class Program
  {
    public static void Main(string[] args)
    {
      var uri = new Uri("https://httpbin.org/delay/5");
      var dataProvider = new HttpDataProvider();
      var logger = new ConsoleLogger();
      var dataSource = new DataSource("testDevice.testData", logger, dataProvider);
      var dataPoller = new HttpDataPoller(uri, 10000, "testDevice.testData", new HttpClientImpl(), dataProvider, logger);

      while (true)
      {
        Thread.Sleep(500);
      }
    }
  }
}
