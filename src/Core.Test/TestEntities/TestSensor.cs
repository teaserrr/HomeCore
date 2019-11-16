using System.Collections.Generic;
using System.Linq;
using HC.Core.Design;
using HC.Core.DataTypes;
using HC.Core.Devices;

namespace HC.Core.Test.TestEntities
{
	public class TestSensor : AbstractDevice
	{
		public const string DataSourceId = "dataSource1";
    
		public TestSensor(string id, ILog logger, IDataProvider dataProvider, IDataSourceFactory dataSourceFactory)
			: base(id, logger, dataSourceFactory)
    {
      AddDataSource(DataSourceId, dataProvider);
    }

		public IntegerData GetData()
    {
      return GetDataSource(DataSourceId).GetCurrentData() as IntegerData;
		}

	}
}