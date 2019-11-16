using System;
using Xunit;
using HC.Core.DataTypes;
using HC.Core.Devices;
using HC.Core.Factories;
using HC.Core.Test.TestEntities;
using FluentAssertions;
using Xunit.Abstractions;

namespace HC.Core.Test.Devices
{
  public class WhenReadingSwitchableLightState
  {

    public const string DeviceId = "testDevice";

    private TestDataProvider _dataProvider;

    private SwitchableLight _testDevice;

    public WhenReadingSwitchableLightState(ITestOutputHelper testOutputHelper)
    {
      _dataProvider = new TestDataProvider();
      _testDevice = new SwitchableLight(DeviceId, new TestLogger(testOutputHelper), _dataProvider, new TestCommandSink(), new DataSourceFactory());
    }

    public OnOffData GetCurrentState()
    {
      return _testDevice.GetOnOffState();
    }

    [Fact]
    public void WithNoData_ResultShouldbeNull()
    {
      var data = GetCurrentState();

      data.Should().BeNull();
    }

    [Fact]
    public void WithNullData_ResultShouldNotBeValid()
    {
      _dataProvider.UpdateData($"{DeviceId}.{SwitchableLight.StateDataSourceId}", new OnOffData());
      var data = GetCurrentState();

      data.IsValid().Should().BeFalse();
    }

    [Fact]
    public void WithValidData_ResultShouldBeCorrect()
    {
      _dataProvider.UpdateData($"{DeviceId}.{SwitchableLight.StateDataSourceId}", OnOffData.OFF);
      var data = GetCurrentState();

      data.Should().Be(OnOffData.OFF);
    }
  }
}