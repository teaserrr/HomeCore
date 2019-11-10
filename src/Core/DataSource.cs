using System.Collections.Generic;
using System.Linq;
using HC.Core.Design;
using HC.Core.DataTypes;

namespace HC.Core
{
	public class DataSource
	{
		private AbstractData currentData;
		private AbstractData previousData;

		public string Id { get; private set; }

		public DataSource(string id, IDataProvider dataProvider) 
		{ 
			Id = id;
			dataProvider.RegisterDataConsumer(id, UpdateData);
		}

		public AbstractData GetCurrentData() => currentData;

		public AbstractData GetPreviousData() => previousData;

		private void UpdateData(AbstractData newData)
		{
			if (Equals(currentData, newData))
				return;
			previousData = currentData;
			currentData = newData;
		}
	}
}