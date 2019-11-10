using System;
using HC.Core.DataTypes;

namespace HC.Core.Design
{
	public interface ICommandSink
	{
		void ProcessCommand(Command command);
	}
}