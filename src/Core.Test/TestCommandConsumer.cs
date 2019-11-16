using HC.Core.Design;

namespace HC.Core.Test
{
  class TestCommandConsumer : ICommandConsumer
  {
    public Command LastCommand { get; private set; }

    public void Consume(Command command)
    {
      LastCommand = command;
    }
  }
}
