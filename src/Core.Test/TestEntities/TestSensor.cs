using System.Collections.Generic;
using System.Linq;
using HC.Core.Design;
using HC.Core.DataTypes;
using HC.Core.Devices;
using HC.Core.Logic;

namespace HC.Core.Test.TestEntities
{
	public class TestSensor : AbstractDevice
	{
		public const string DataSourceId = "dataSource1";

		private DataSource numberDataSource;

		public TestSensor(string id, IDataProvider dataProvider)
			: base(id)
		{
			numberDataSource = new DataSource($"{id}.{DataSourceId}", dataProvider); 
		}

		public IntegerData GetData()
		{
			return numberDataSource.GetCurrentData() as IntegerData;
		}

	}
}