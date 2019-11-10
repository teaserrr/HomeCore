using System.Collections.Generic;
using System.Linq;
using HC.Core.DataTypes;
using HC.Core.Design;

namespace HC.Core.Test.TestEntities
{
	public class TestActor
	{
		public const string CommandId = "testCommand";

		private ICommandSink commandSink;

		public string Id { get; private set; }

		public TestActor(string id, ICommandSink commandSink)
		{
			Id = id; 
			this.commandSink = commandSink;
		}

		public void SendCommand(IntegerData data)
		{
			var command = new Command($"{Id}.{CommandId}", data);
			commandSink.ProcessCommand(command);
		}
	}
}