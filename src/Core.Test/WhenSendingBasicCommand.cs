using Xunit;
using HC.Core.Test.TestEntities;
using HC.Core.DataTypes;
using FluentAssertions;
using Xunit.Abstractions;
using HC.Core.Factories;

namespace HC.Core.Test
{
  public class WhenSendingBasicCommand
  {
    private TestCommandConsumer _testCommandConsumer;

    private TestActor _testActor;

    public WhenSendingBasicCommand(ITestOutputHelper testOutputHelper)
    {
      _testCommandConsumer = new TestCommandConsumer();
      _testActor = new TestActor("testActor", new TestLogger(testOutputHelper), new CommandSinkFactory(), _testCommandConsumer);
    }

    [Fact]
    public void WithBasicCommand_ShouldBeProcessedBySink()
    {
      _testActor.SendCommand(new IntegerData(42));

      _testCommandConsumer.LastCommand.Should().NotBeNull();
    }

    [Fact]
    public void WithBasicCommand_CommandDataShouldBeCorrect()
    {
      _testActor.SendCommand(new IntegerData(42));

      _testCommandConsumer.LastCommand.Data.Should().Be(new IntegerData(42));
    }
  }
}