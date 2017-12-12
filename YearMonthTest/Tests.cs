using System;
using Xunit;
using YearMonthLib;

namespace YearMonthTest
{
    public class Tests
    {
        [Fact]
        public void TestDateConstructor()
        {
            // Default constructor initializes to EPOCH
            Assert.Equal(0, new YearMonth().Value);
            
            // DateTime based constructor
            Assert.Equal(2017*12 + 1, new YearMonth(new DateTime(2017,02,01,1,2,3)).Value);
            Assert.Equal(2017*12 + 0, new YearMonth(new DateTime(2017,01,01,1,2,3)).Value);
            Assert.Equal(1990*12 + 11, new YearMonth(new DateTime(1990,12,01,1,2,3)).Value);
            
            // Year/Month constructor
            Assert.Equal(1970*12+5, new YearMonth(1970,6).Value);
            
            // EPOCH based constructor
            Assert.Equal(20001, new YearMonth(20001).Value);
        }

        [Fact]
        public void TestStringifying()
        {
            Assert.Equal(new DateTime(2011,2,1).ToString("yyyy MMM"), new YearMonth(2011,2).ToString());
        }
    }
}