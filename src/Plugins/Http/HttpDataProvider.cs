using System;
using System.Collections.Generic;
using HC.Core.Design;

namespace HC.Plugins.Http
{
	public class HttpDataProvider : IDataProvider
	{
		private IDictionary<string, Action<IData>> _dataConsumers;

		public HttpDataProvider()
		{
			_dataConsumers = new Dictionary<string, Action<IData>>();
		}

		public void RegisterDataConsumer(string id, Action<IData> dataConsumer)
		{
			_dataConsumers.Add(id, dataConsumer);
		}

		internal void UpdateData(string id, IData data)
		{
			_dataConsumers[id].Invoke(data);
		}
	}
}