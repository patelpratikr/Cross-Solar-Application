using System;
using System.Collections.Generic;
using System.Text;
using CrossSolar.Domain;
using CrossSolar.Repository;
using Xunit;

namespace CrossSolar.Tests.Repository
{
    public class PanelRepositoryTests
    {
	    [Fact]
	    public void Constructor_WorksFine()
	    {
			PanelRepository panelRepository = new PanelRepository(new CrossSolarDbContext());

			Assert.NotNull(panelRepository);
	    }
    }
}
