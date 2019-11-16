using HC.Core.Design;

namespace HC.Core.Logic
{
  public class DataSource : IDataSource
	{
		private IData _currentData;
		private IData _previousData;

    private readonly ILog _logger;

    public event DataUpdatedHandler DataUpdated;

    public string Id { get; private set; }

		public DataSource(string id, ILog logger, IDataProvider dataProvider) 
		{ 
			Id = id;
      _logger = logger;
      dataProvider.RegisterDataConsumer(id, UpdateData);
		}

		public IData GetCurrentData() => _currentData;

		public IData GetPreviousData() => _previousData;

		private void UpdateData(IData newData)
		{
			if (Equals(_currentData, newData))
				return;

      _previousData = _currentData;
			_currentData = newData;

      _logger.Notice($"{this} data updated from {_previousData} to {_currentData}");
      OnDataUpdated(newData);
    }

    private void OnDataUpdated(IData data)
    {
      DataUpdated?.Invoke(this, data);
    }

    public override string ToString()
    {
      return $"DataSource [Id={Id}]";
    }
  }
}