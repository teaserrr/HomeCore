using System;
using Xunit;
using HC.Core.DataTypes;
using HC.Core.Devices;
using HC.Core.Factories;
using HC.Core.Test.TestEntities;
using FluentAssertions;

namespace HC.Core.Test.Devices
{
  public class WhenReadingOnOffSwitch
  {

    public const string SensorId = "testSensor";

    private TestDataProvider _dataProvider;

    private OnOffSwitch _testSensor;

    public WhenReadingOnOffSwitch()
    {
      _dataProvider = new TestDataProvider();
      _testSensor = new OnOffSwitch(SensorId, _dataProvider, new DataSourceFactory());
    }

    public OnOffData GetCurrentState()
    {
      return _testSensor.GetOnOffState();
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
      _dataProvider.UpdateData($"{SensorId}.{OnOffSwitch.DataSourceId}", new OnOffData());
      var data = GetCurrentState();

      data.IsValid().Should().BeFalse();
    }

    [Fact]
    public void WithValidData_ResultShouldBeCorrect()
    {
      _dataProvider.UpdateData($"{SensorId}.{OnOffSwitch.DataSourceId}", OnOffData.OFF);
      var data = GetCurrentState();

      data.Should().Be(OnOffData.OFF);
    }
  }
}