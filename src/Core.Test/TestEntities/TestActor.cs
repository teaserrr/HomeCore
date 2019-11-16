using HC.Core.DataTypes;
using HC.Core.Design;
using HC.Core.Devices;

namespace HC.Core.Test.TestEntities
{
	public class TestActor : AbstractDevice
	{
		public const string CommandId = "testCommand";
    
		public TestActor(string id, ILog logger, ICommandSinkFactory commandSinkFactory, ICommandConsumer commandConsumer)
      : base(id, logger, null, commandSinkFactory)
		{
      AddCommandSink(CommandId, commandConsumer);
		}

		public void SendCommand(IntegerData data)
		{
      ProcessCommand(CommandId, data);
		}
	}
}