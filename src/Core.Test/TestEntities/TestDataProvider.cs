using System;
using System.Collections.Generic;
using HC.Core.Design;
using HC.Core.DataTypes;

namespace HC.Core.Test.TestEntities
{
	public class TestDataProvider : IDataProvider
	{
		private IDictionary<string, Action<IData>> dataConsumers;

		public TestDataProvider()
		{
			dataConsumers = new Dictionary<string, Action<IData>>();
		}

		public void RegisterDataConsumer(string id, Action<IData> dataConsumer)
		{
			dataConsumers.Add(id, dataConsumer);
		}

		public void UpdateData(string id, IData data)
		{
			dataConsumers[id].Invoke(data);
		}
	}
}