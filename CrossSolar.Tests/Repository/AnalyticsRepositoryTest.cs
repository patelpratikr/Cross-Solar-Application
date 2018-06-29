using System;
using System.Collections.Generic;
using System.Text;
using CrossSolar.Domain;
using CrossSolar.Repository;
using Xunit;

namespace CrossSolar.Tests.Repository
{
    public class AnalyticsRepositoryTest
    {
	    [Fact]
	    public void Constructor_WorksFine()
	    {
		    AnalyticsRepository analyticsRepository = new AnalyticsRepository(new CrossSolarDbContext());

		    Assert.NotNull(analyticsRepository);
		}
    }
}
