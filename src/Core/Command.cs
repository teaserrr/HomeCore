using System.Collections.Generic;
using HC.Core.DataTypes;

namespace HC.Core
{
	public class Command
	{
		public string Id { get; private set; }

		public AbstractData Data { get; private set; }

		public Command(string id, AbstractData data) 
		{
			Id = id;
			Data = data;
		}

		public override string ToString()
		{
			return $"Command Id={Id} Data={Data}";
		}
	}
}