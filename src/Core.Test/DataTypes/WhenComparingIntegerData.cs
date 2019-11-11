using Xunit;
using FluentAssertions;
using HC.Core.DataTypes;

namespace HC.Core.Test.DataTypes
{
    public class WhenComparingIntegerData
    {
        [Fact]
        void WithIntegerDataAndIntegerData_ShouldBeEqual()
        {
            var data1 = new IntegerData(42);
            var data2 = new IntegerData(42);
            data1.Should().Be(data2);
        }

        [Fact]
        void WithIntegerDataAndLong_ShouldBeEqual()
        {
            var data = new IntegerData(42);
            long number = 42;
            data.Should().Be(number);
        }

        [Fact]
        void WithIntegerDataAndNullableLong_ShouldBeEqual()
        {
            var data = new IntegerData(42);
            long? number = 42;
            data.Should().Be(number);
        }

        [Fact]
        void WithIntegerDataAndInt_ShouldBeEqual()
        {
            var data = new IntegerData(42);
            int number = 42;
            data.Should().Be(number);
        }

        [Fact]
        void WithIntegerDataAndDouble_ShouldBeEqual()
        {
            var data = new IntegerData(42);
            double number = 42.0;
            data.Should().Be(number);
        }

        [Fact]
        void WithValidIntegerData_ShouldBeValid()
        {
            var data = new IntegerData(42);
            data.IsValid().Should().BeTrue();
        }

        [Fact]
        void WithUninitializedIntegerData_ShouldNotBeValid()
        {
            var data = new IntegerData();
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