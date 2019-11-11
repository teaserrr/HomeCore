using System.Collections.Generic;
using System.Linq;
using System;
using HC.Core.Design;
using HC.Core.DataTypes;

namespace HC.Core.Logic
{
	public class DataSource : IDataSource
	{
		private IData currentData;
		private IData previousData;

		public string Id { get; private set; }

		public DataSource(string id, IDataProvider dataProvider) 
		{ 
			Id = id;
			dataProvider.RegisterDataConsumer(id, UpdateData);
		}

		public IData GetCurrentData() => currentData;

		public IData GetPreviousData() => previousData;

		private void UpdateData(IData newData)
		{
			if (Equals(currentData, newData))
				return;
			previousData = currentData;
			currentData = newData;
		}
	}
}