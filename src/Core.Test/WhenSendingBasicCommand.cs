using Xunit;
using HC.Core.Test.TestEntities;
using HC.Core.DataTypes;
using FluentAssertions;

namespace HC.Core.Test
{
    public class WhenSendingBasicCommand
    {
        private TestCommandSink _testCommandSink;

        private TestActor _testActor;

        public WhenSendingBasicCommand()
        {
            _testCommandSink = new TestCommandSink();
            _testActor = new TestActor("testActor", _testCommandSink);
        }

        [Fact]
        public void WithBasicCommand_ShouldBeProcessedBySink()
        {
            _testActor.SendCommand(new IntegerData(42));

            _testCommandSink.LastCommand.Should().NotBeNull();
        }

        [Fact]
        public void WithBasicCommand_CommandDataShouldBeCorrect()
        {
            _testActor.SendCommand(new IntegerData(42));

            _testCommandSink.LastCommand.Data.Should().Be(new IntegerData(42));
        }
    }
}