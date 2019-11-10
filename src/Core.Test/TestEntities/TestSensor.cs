using System.Collections.Generic;
using System.Linq;
using HC.Core.Design;
using HC.Core.DataTypes;

namespace HC.Core.Test.TestEntities
{
	public class TestSensor
	{
		public const string DataSourceId = "dataSource1";

		private DataSource numberDataSource;

		public string Id { get; private set; }

		public TestSensor(string id, IDataProvider dataProvider)
		{
			Id = id; 
			numberDataSource = new DataSource($"{id}.{DataSourceId}", dataProvider); 
		}

		public IntegerData GetData()
		{
			return numberDataSource.GetCurrentData() as IntegerData;
		}

	}
}