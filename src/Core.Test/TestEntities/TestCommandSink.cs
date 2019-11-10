using System;
using HC.Core;
using HC.Core.Design;

namespace HC.Core.Test.TestEntities
{
	public class TestCommandSink : ICommandSink
	{
		public Command LastCommand { get; private set; }
		
		public void ProcessCommand(Command command)
		{
			Console.WriteLine("Processing command: " + command);
			LastCommand = command;
		}
	}
}