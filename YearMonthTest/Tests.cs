using System;
using System.Collections.Generic;
using Xunit;
using jclement.YearMonthLib;

namespace jclement.YearMonthTest
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
        public void TestAsDateTime()
        {
            Assert.Equal(new DateTime(2011,2,1), new YearMonth(2011,2).AsDateTime());
        }
        
        [Fact]
        public void TestAsDateTimeUtc()
        {
            Assert.Equal(new DateTime(2011,2,1, 0, 0, 0, DateTimeKind.Utc), new YearMonth(2011,2).AsDateTimeUtc());
            Assert.True(new YearMonth(2011,2).AsDateTimeUtc().Kind == DateTimeKind.Utc);
        }
        
        [Fact]
        public void TestMath()
        {
            Assert.Equal(new DateTime(2012,2,1), new YearMonth(2011,2).AddYears(1).AsDateTime());
            Assert.Equal(new DateTime(2001,2,1), new YearMonth(2011,2).AddYears(-10).AsDateTime());
            Assert.Equal(new DateTime(2011,3,1), new YearMonth(2011,2).AddMonths(1).AsDateTime());
            Assert.Equal(new DateTime(2010,11,1), new YearMonth(2011,2).AddMonths(-3).AsDateTime());
        }

        [Fact]
        public void TestYearMonthAccessors()
        {
            Assert.Equal(2011, new YearMonth(2011,2).Year);
            Assert.Equal(2, new YearMonth(2011,2).Month);
        }
        
        [Fact]
        public void TestComparisons()
        {
            var a = new YearMonth(2011,2);
            var b = new YearMonth(2011,3);
            var c = new YearMonth(2011,2);
            Assert.Equal(a, c);
            Assert.NotEqual(a, b);
            Assert.NotEqual(c, b);
            Assert.True(a<b);
            Assert.True(b>a);
            Assert.True(a<=b);
            Assert.True(b>=a);
            Assert.True(c>=a);
            Assert.True(c<=a);
            Assert.True(a==c);
            Assert.True(a!=b);
        }

        [Fact]
        public void TestStringifying()
        {
            Assert.Equal(new DateTime(2011,2,1).ToString("yyyy MMM"), new YearMonth(2011,2).ToString());
            Assert.Equal(new DateTime(2011,2,1).ToString("MMMM yyyy"), new YearMonth(2011,2).ToString("MMMM yyyy"));
        }

        [Fact]
        public void TestDictionaryKey()
        {
            var y1 = new YearMonth(2011,1);
            var y2 = new YearMonth(2011,1);
            var y3 = new YearMonth(2011,2);
            
            var d1 = new Dictionary<YearMonth, bool>();
            d1.Add(y1, true);
            Assert.True(d1.ContainsKey(y2));
            Assert.False(d1.ContainsKey(y3));
            
            Assert.Equal(new Tuple<YearMonth, string>(y1, "a").GetHashCode(), new Tuple<YearMonth, string>(y2, "a").GetHashCode());
        }
    }
}