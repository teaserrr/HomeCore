using Xunit;
using FluentAssertions;
using HC.Core.DataTypes;

namespace HC.Core.Test.DataTypes
{
    public class WhenComparingOnOffData
    {
        [Fact]
        void WithOnOffDataAndOnOffData_ShouldBeEqual()
        {
            var data1 = OnOffData.ON;
            var data2 = OnOffData.ON;
            data1.Should().Be(data2);
        }

        [Fact]
        void WithOnOffDataAndDifferentOnOffData_ShouldNotBeEqual()
        {
            var data1 = OnOffData.ON;
            var data2 = OnOffData.OFF;
            data1.Should().NotBe(data2);
        }

        [Fact]
        void WithOnOffDataAnInvalidOnOffData_ShouldNotBeEqual()
        {
            var data1 = OnOffData.OFF;
            var data2 = new OnOffData();
            data1.Should().NotBe(data2);
        }

        [Fact]
        void WithValidOnOffData_ShouldBeValid()
        {
            var data = OnOffData.OFF;
            data.IsValid().Should().BeTrue();
        }

        [Fact]
        void WithUninitializedOnOffData_ShouldNotBeValid()
        {
            var data = new OnOffData();
            data.IsValid().Should().BeFalse();
        }

        [Fact]
        void WithNullIntegerData_ShouldNotBeValid()
        {
            IntegerData data = (long?)null;
            data.IsValid().Should().BeFalse();
        }
    }
}