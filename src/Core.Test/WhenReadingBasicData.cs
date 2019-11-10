using System;
using Xunit;
using HC.Core.Design;
using HC.Core.DataTypes;
using HC.Core.Test.TestEntities;
using FluentAssertions;

namespace HC.Core.Test
{
    public class WhenReadingBasicData
    {
        public const string SensorId = "testSensor";

        private TestDataProvider _dataProvider;

        private TestSensor _testSensor;

        public WhenReadingBasicData()
        {
            _dataProvider = new TestDataProvider();
            _testSensor = new TestSensor(SensorId, _dataProvider);
        }

        [Fact]
        public void WithNoData_ResultShouldbeNull()
        {
            var data = _testSensor.GetData();

            data.Should().BeNull();
        }

        [Fact]
        public void WithDataSet_ResultShouldBeCorrect()
        {
            _dataProvider.UpdateData($"{SensorId}.{TestSensor.DataSourceId}", new IntegerData(42));
            var data = _testSensor.GetData();

            data.Should().Be(new IntegerData(42));
        }
    }
}
