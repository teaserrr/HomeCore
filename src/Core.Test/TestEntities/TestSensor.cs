using System.Collections.Generic;
using System.Linq;
using HC.Core.Design;
using HC.Core.DataTypes;
using HC.Core.Devices;

namespace HC.Core.Test.TestEntities
{
	public class TestSensor : AbstractDevice
	{
		public const string DataId = "testData";
    
		public TestSensor(string id, ILog logger, IDataProvider dataProvider, IDataSourceFactory dataSourceFactory)
			: base(id, logger, dataSourceFactory)
    {
      AddDataSource(DataId, dataProvider);
    }

		public IntegerData GetData()
    {
      return GetDataSource(DataId).GetCurrentData() as IntegerData;
		}

	}
}