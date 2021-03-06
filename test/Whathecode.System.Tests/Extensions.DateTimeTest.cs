﻿using System;
using System.Collections.Generic;
using Whathecode.System;
using Xunit;


namespace Whathecode.Tests.System
{
	public partial class Extensions
	{
		public class DateTimeTest
		{
			[Fact]
			public void RoundToStartOfWeekTest()
			{
				// Set up a monday, and subsequent dates in the same, and next week.
				var monday = new DateTime( 2013, 12, 9 );
				var withinWeek = new List<DateTime>
				{
					new DateTime( 2013, 12, 9 ),  // Exactly Monday.
					new DateTime( 2013, 12, 10 ),  // Exactly Tuesday.
					new DateTime( 2013, 12, 11, 12, 34, 56 ),  // Somewhere mid Wednesday.
					new DateTime( 2013, 12, 15 ),  // Exactly Sunday.
					new DateTime( 2013, 12, 15, 23, 59, 59)  // Almost next week.
				};
				var otherWeek = new List<DateTime>
				{
					new DateTime( 2013, 12, 8 ),  // Sunday before.
					new DateTime( 2013, 12, 16, 0, 0, 0, 1 )  // 1ms past Sunday.
				};

				// Check all dates.
				foreach ( DateTime date in withinWeek )
				{
					DateTime startOfWeek = date.Round( DayOfWeek.Monday );
					Assert.Equal( monday, startOfWeek );
				}
				foreach ( DateTime date in otherWeek )
				{
					DateTime startOfWeek = date.Round( DayOfWeek.Monday );
					Assert.NotEqual( monday, startOfWeek );
				}

				// Check whether it works as well when Sunday is the start of the week.
				var sunday = new DateTime( 2013, 12, 8 );
				Assert.Equal( sunday, monday.Round( DayOfWeek.Sunday ) );
			}
		}
	}
}
