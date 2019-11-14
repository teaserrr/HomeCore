using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using HC.Core.DataTypes;
using HC.Core.Devices;
using HC.Core.Factories;
using HC.Core.Test.TestEntities;
using Xunit;

namespace HC.Core.Test.Devices
{
  public class WhenSendingSwitchCommand
  {
    private TestCommandSink _testCommandSink;

    private SwitchableLight _testActor;

    public WhenSendingSwitchCommand()
    {
      _testCommandSink = new TestCommandSink();
      _testActor = new SwitchableLight("testLight", new TestDataProvider(), _testCommandSink, new DataSourceFactory());
    }

    [Fact]
    public void WithBasicCommand_ShouldBeProcessedBySink()
    {
      _testActor.SendSwitchCommand(OnOffData.ON);

      _testCommandSink.LastCommand.Should().NotBeNull();
    }

    [Fact]
    public void WithBasicCommand_CommandDataShouldBeCorrect()
    {
      _testActor.SendSwitchCommand(OnOffData.ON);

      _testCommandSink.LastCommand.Id.Should().EndWith(SwitchableLight.SwitchCommandId);
      _testCommandSink.LastCommand.Data.Should().Be(OnOffData.ON);
    }
  }
}
