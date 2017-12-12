using System;
using Xunit;

namespace YearMonthTest
{
    public class Tests
    {
        [Fact]
        public void TestDateConstructor()
        {
            Assert.Equal(2017*12 + 1, new YearMonth.YearMonth(new DateTime(2017,02,01,1,2,3)).Value);
            Assert.Equal(2017*12 + 0, new YearMonth.YearMonth(new DateTime(2017,01,01,1,2,3)).Value);
            Assert.Equal(1990*12 + 11, new YearMonth.YearMonth(new DateTime(1990,12,01,1,2,3)).Value);
        }

        [Fact]
        public void TestStringifying()
        {
            Assert.Equal(new DateTime(2011,2,1).ToString("yyyy MMM"), new YearMonth.YearMonth(2011,2).ToString());
        }
    }
}