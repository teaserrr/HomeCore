using HC.Core.Design;
using HC.Core.DataTypes;
using HC.Core.Logic;

namespace HC.Core.Devices
{
    public class OnOffSwitch : AbstractDevice
    {
		public const string DataSourceId = "dataSource1";

		private IDataSource _dataSource;

        public OnOffSwitch(string id, IDataProvider dataProvider, IDataSourceFactory dataSourceFactory) 
            : base(id)
        {
            _dataSource = dataSourceFactory.Create(id, DataSourceId, dataProvider);
        }

        public OnOffData GetCurrentState()
        {
            return _dataSource.GetCurrentData() as OnOffData;
        }
    }
}