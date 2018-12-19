using System;
using Xunit;

namespace ECP.UnitTests
{
    using ECP.API.Business;

    public class UnitTest1
    {
        [Fact]
        public void Okey()
        {
            Assert.True(ConsumptionRequestValidator.Validate(new DateTime(2018, 01, 01), new DateTime(2018, 01, 02), "day"));
        }

        [Fact]
        public void StartDate_Cannot_Be_Less_Than_Two_Years_From_Today()
        {
            Assert.False(ConsumptionRequestValidator.Validate(new DateTime(2014, 01, 01), new DateTime(2018, 01, 02), "day"));
        }

        [Fact]
        public void StartDate_Cannot_Be_Greater_Than_EndDate()
        {
            Assert.False(ConsumptionRequestValidator.Validate(new DateTime(2018, 01, 02), new DateTime(2018, 01, 01), "day"));
        }

        [Fact]
        public void EndDate_Cannot_Be_Greater_Than_Today()
        {
            Assert.False(ConsumptionRequestValidator.Validate(new DateTime(2018, 01, 02), DateTime.Today.AddDays(1), "day"));
        }

        [Theory]
        [InlineData("day")]
        [InlineData("week")]
        [InlineData("month")]
        public void Allow_Correct_Grouping_Method(string grouping)
        {
            Assert.True(ConsumptionRequestValidator.Validate(new DateTime(2018, 01, 01), new DateTime(2018, 01, 02), grouping));
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("monthhh")]
        [InlineData("abc123")]
        public void Reject_Bad_Grouping_Method(string grouping)
        {
            Assert.False(ConsumptionRequestValidator.Validate(new DateTime(2018, 01, 01), new DateTime(2018, 01, 02), grouping));
        }
    }
}
