using HC.Core.Design;
using HC.Core.DataTypes;
using HC.Core.Logic;

namespace HC.Core.Devices
{
    public class OnOffSwitch : AbstractDevice
    {
		public const string DataSourceId = "dataSource1";

		private DataSource _dataSource;

        public OnOffSwitch(string id, IDataProvider dataProvider) 
            : base(id)
        {
            _dataSource = new DataSource($"{id}.{DataSourceId}", dataProvider);
        }

        public OnOffData GetCurrentState()
        {
            return _dataSource.GetCurrentData() as OnOffData;
        }
    }
}