using System;

namespace HC.Core.Design
{
	public interface IDataProvider
	{
		void RegisterDataConsumer(string id, Action<IData> dataConsumer);
	}
}