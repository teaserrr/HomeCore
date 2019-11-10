using System;
using HC.Core.DataTypes;

namespace HC.Core.Design
{
	public interface IDataProvider
	{
		void RegisterDataConsumer(string id, Action<AbstractData> dataConsumer);
	}
}