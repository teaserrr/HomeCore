using System;
using System.Collections.Generic;
using HC.Core.Design;
using HC.Core.DataTypes;

namespace HC.Core.Test.TestEntities
{
	public class TestDataProvider : IDataProvider
	{
		private IDictionary<string, Action<AbstractData>> dataConsumers;

		public TestDataProvider()
		{
			dataConsumers = new Dictionary<string, Action<AbstractData>>();
		}

		public void RegisterDataConsumer(string id, Action<AbstractData> dataConsumer)
		{
			dataConsumers.Add(id, dataConsumer);
		}

		public void UpdateData(string id, AbstractData data)
		{
			dataConsumers[id].Invoke(data);
		}
	}
}