using System;
using System.Collections.Generic;
using System.Linq;
using HC.Core.Design;

namespace HC.Core.Devices
{
  public abstract class AbstractDevice
  {
    private readonly ILog _logger;
    private IList<IDataSource> _dataSources;
    private IList<ICommandSink> _commandSinks;
    private IDataSourceFactory _dataSourceFactory;
    private readonly ICommandSinkFactory _commandSinkFactory;

    public string Id { get; private set; }

    public IEnumerable<IDataSource> DataSources => _dataSources.Skip(0); // creates a new enumerable so it cannot be cast back to a list

    protected AbstractDevice(string id, ILog logger, IDataSourceFactory dataSourceFactory)
    {
      Id = id;
      _logger = logger;
      _dataSourceFactory = dataSourceFactory;
      _dataSources = new List<IDataSource>();
    }

    protected AbstractDevice(string id, ILog logger, IDataSourceFactory dataSourceFactory, ICommandSinkFactory commandSinkFactory)
      : this(id, logger, dataSourceFactory)
    {
      _commandSinkFactory = commandSinkFactory;
      _commandSinks = new List<ICommandSink>();
    }
    
    protected void AddDataSource(string dataId, IDataProvider dataProvider)
    {
      var dataSource = _dataSourceFactory.Create(GetDataSourceId(Id, dataId), dataProvider, _logger);
      _dataSources.Add(dataSource);
    }

    protected IDataSource GetDataSource(string dataId)
    {
      return _dataSources.Single(ds => ds.Id.Equals(GetDataSourceId(Id, dataId)));
    }

    protected void AddCommandSink(string commandId, ICommandConsumer commandConsumer)
    {
      var commandSink = _commandSinkFactory.Create(GetCommandSinkId(Id, commandId), _logger, commandConsumer);
      _commandSinks.Add(commandSink);
    }

    private ICommandSink GetCommandSink(string commandId)
    {
      return _commandSinks.Single(cs => cs.Id.Equals(GetCommandSinkId(Id, commandId)));
    }

    protected void ProcessCommand(string commandId, IData data)
    {
      if (_commandSinks == null)
        throw new InvalidOperationException("Processing commands not supported by this device.");

      GetCommandSink(commandId).ProcessCommand(data);
    }

    protected string GetDataSourceId(string deviceId, string dataSourceId)
    {
      return $"{deviceId}.{dataSourceId}";
    }

    protected string GetCommandSinkId(string deviceId, string commandId)
    {
      return $"{deviceId}.{commandId}";
    }

    public override string ToString()
    {
      return $"Device [Id={Id}]";
    }
  }
}