using System;
using System.Threading.Tasks;
using HC.Core.DataTypes;
using HC.Core.Design;

namespace HC.Plugins.Http
{
  internal class HttpDataPoller
  {
    private readonly Uri _uri;

    private readonly int _pollInterval;

    private readonly HttpClientImpl _httpClient;

    private readonly HttpDataProvider _dataProvider;

    private readonly ILog _logger;

    public string DataSourceId { get; private set; }

    public HttpDataPoller(Uri uri, int pollInterval, string dataSourceId, HttpClientImpl httpClient, HttpDataProvider dataProvider, ILog logger)
    {
      _uri = uri;
      _pollInterval = pollInterval;
      DataSourceId = dataSourceId;
      _httpClient = httpClient;
      _dataProvider = dataProvider;
      _logger = logger;
      PollData();
    }

    protected async Task PollData()
    {
      while (true)
      {
        _logger.Verbose($"{this} GET { _uri}");
        var result = await _httpClient.Get(_uri);
        _logger.Debug($"{this} received {result.Length} character(s)");

        _dataProvider.UpdateData(DataSourceId, new StringData(result));

        await Task.Delay(_pollInterval);
      }
    }

    public override string ToString()
    {
      return $"HttpDataPoller [DataSourceId={DataSourceId}]";
    }
  }
}
