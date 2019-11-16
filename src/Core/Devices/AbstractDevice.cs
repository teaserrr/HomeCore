using System;
using System.Collections.Generic;
using System.Linq;
using HC.Core.Design;

namespace HC.Core.Devices
{
  public abstract class AbstractDevice
  {
    private readonly ICommandSink _commandSink;
    private readonly ILog _logger;
    private IList<IDataSource> _dataSources;
    private IDataSourceFactory _dataSourceFactory;

    public string Id { get; private set; }

    public IEnumerable<IDataSource> DataSources => _dataSources.Skip(0); // creates a new enumerable so it cannot be cast back to a list

    protected AbstractDevice(string id, ILog logger, IDataSourceFactory dataSourceFactory)
    {
      Id = id;
      _logger = logger;
      _dataSourceFactory = dataSourceFactory;
      _dataSources = new List<IDataSource>();
    }

    protected AbstractDevice(string id, ILog logger, ICommandSink commandSink, IDataSourceFactory dataSourceFactory)
      : this(id, logger, dataSourceFactory)
    {
      _commandSink = commandSink;
    }
    
    protected void AddDataSource(string dataSourceId, IDataProvider dataProvider)
    {
      var dataSource = _dataSourceFactory.Create(GetDataSourceId(Id, dataSourceId), dataProvider, _logger);
      _dataSources.Add(dataSource);
    }

    protected IDataSource GetDataSource(string dataSourceId)
    {
      return _dataSources.Single(ds => ds.Id.Equals(GetDataSourceId(Id, dataSourceId)));
    }

    protected void ProcessCommand(Command command)
    {
      if (_commandSink == null)
        throw new InvalidOperationException("Cannot process commands when commandSink is not set");

      _logger.Notice($"{this} Processing command {command}");
      _commandSink.ProcessCommand(command);
    }

    protected string GetDataSourceId(string deviceId, string dataSourceId)
    {
      return $"{deviceId}.{dataSourceId}";
    }

    public override string ToString()
    {
      return $"Device [Id={Id}]";
    }
  }
}