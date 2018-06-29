using System;
using System.Collections.Generic;
using System.Text;
using CrossSolar.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace CrossSolar.Tests
{
    public class StartupTest
    {

	    [Fact]
	    public void StartUp()
	    {
			// Arrange
			Mock<IConfiguration> mockConfiguration = new Mock<IConfiguration>();

			// Act
			Startup startup = new Startup(mockConfiguration.Object);

			// Assert
			Assert.NotNull(startup);
	    }
	}
}
