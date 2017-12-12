using System;

namespace jfry.YearMonthLib
{
    /// <summary>
    /// Very simple immutable class to handle Year/Month data structure.  
    /// </summary>
    public struct YearMonth : IEquatable<YearMonth>, IComparable<YearMonth>
    {

        /// <summary>
        /// Initialize YearMonth with a YearMonth integer value (# of months since year January 0000)
        /// </summary>
        /// <param name="value"></param>
        public YearMonth(int value)
        {
            Value = value;
        }
        
        /// <summary>
        /// Initialize YearMonth object using a date time.  Throws away day and time component.
        /// </summary>
        /// <param name="dateTime">DateTime to initalize YearMonth with</param>
        public YearMonth(DateTime dateTime)
        {
            Value = dateTime.Year * 12 + (dateTime.Month - 1);
        }

        /// <summary>
        /// Initialize YearMonth with a specific Year and Month
        /// </summary>
        /// <param name="year">Year</param>
        /// <param name="month">Month</param>
        /// <exception cref="ArgumentOutOfRangeException">Valid year and month required (year larger than zero, month between 1 and 12)</exception>
        public YearMonth(int year, int month)
        {
            if (year < 0) throw new ArgumentOutOfRangeException(nameof(year));
            if (month < 1 || month > 12) throw new ArgumentOutOfRangeException(nameof(month));
            Value = year * 12 + (month-1);
        }

        /// <summary>
        /// Add a number of months to a YearMonth and return as a new YearMonth
        /// </summary>
        /// <param name="number">Number of months to add</param>
        /// <returns>New modified YearMonth</returns>
        public YearMonth AddMonths(int number)
        {
            return new YearMonth(Value + number);
        }

        /// <summary>
        /// Add a number of years to a YearMonth and return as a new YearMonth
        /// </summary>
        /// <param name="number">Number of years to add</param>
        /// <returns>New modified YearMonth</returns>
        public YearMonth AddYears(int number)
        {
            return new YearMonth(Value + 12*number);
        }

        /// <summary>
        /// Return value as DateTime on first of YearMonth
        /// </summary>
        /// <returns></returns>
        public DateTime AsDateTime()
        {
            return new DateTime(Value/12, 1+Value%12,1);
        }

        /// <summary>
        /// Return YearMonth value as number of months since Jan 0000
        /// </summary>
        public int Value { get; }
        
        /// <summary>
        /// Return year component of YearMonth
        /// </summary>
        public int Year => Value / 12;
        
        /// <summary>
        /// Return month component of YearMonth
        /// </summary>
        public int Month => 1 + Value % 12;

        public bool Equals(YearMonth other)
        {
            return other.Value == Value;
        }

        public int CompareTo(YearMonth other)
        {
            if (Value < other.Value) return -1;
            if (Value > other.Value) return 1;
            return 0;
        }
        
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
        
        /// <summary>
        /// Convert to string using standard format "yyyy MMM"
        /// </summary>
        /// <returns>YearMonth as formatted string</returns>
        public override string ToString()
        {
            return AsDateTime().ToString("yyyy MMM");
        }
        
        /// <summary>
        /// Convert to string using custom format
        /// </summary>
        /// <param name="fmt">DateTime format string</param>
        /// <returns>YearMonth as formatted string</returns>
        public string ToString(string fmt)
        {
            return AsDateTime().ToString(fmt);
        }

        public override bool Equals(object obj)
        {
            if (obj is YearMonth objVal) 
                return Value.Equals(objVal);
            return false;
        }

        public static bool operator > (YearMonth a, YearMonth b)
        {
            return a.Value > b.Value;
        }
        
        public static bool operator < (YearMonth a, YearMonth b)
        {
            return a.Value < b.Value;
        }
        
        public static bool operator >= (YearMonth a, YearMonth b)
        {
            return a.Value >= b.Value;
        }
        
        public static bool operator <= (YearMonth a, YearMonth b)
        {
            return a.Value <= b.Value;
        }
        
        public static bool operator == (YearMonth a, YearMonth b)
        {
            return a.Value == b.Value;
        }
        
        public static bool operator != (YearMonth a, YearMonth b)
        {
            return a.Value != b.Value;
        }
    }
}