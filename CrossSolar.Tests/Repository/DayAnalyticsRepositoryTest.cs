using System;
using System.Collections.Generic;
using System.Text;
using CrossSolar.Domain;
using CrossSolar.Repository;
using Xunit;

namespace CrossSolar.Tests.Repository
{
    public class DayAnalyticsRepositoryTest
    {
	    [Fact]
	    public void Constructor_WorksFine()
	    {
		    DayAnalyticsRepository dayAnalyticsRepository = new DayAnalyticsRepository(new CrossSolarDbContext());

		    Assert.NotNull(dayAnalyticsRepository);
	    }
	}
}
