# YearMonth

<p><b>Build Status</b>: <a href="https://travis-ci.org/jclement/YearMonth"><img src="https://travis-ci.org/jclement/YearMonth.svg?branch=master" /></a></p>

A very simple .NET struct to represent a Year/Month because I keep needing one.

```cs
var yrNow = new YearMonth(DateTime.Now());
var yrOld = new YearMonth(2001,2);
var yrLessOld = yrOld.AddYears(10);
Assert.Equal(2011, yrLessOld.Year);
Assert.Equal(2, yrLessOld.Month);
Assert.True(yrOld < yrLessOld);
```