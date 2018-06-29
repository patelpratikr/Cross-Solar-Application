using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using CrossSolar.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Migrations;
using Moq;
using Xunit;

namespace CrossSolar.Tests.Migrations
{
    public class CreateCrossSolarDbTests
    {
	    [Fact]
	    public void Up_WorksFine()
	    {
			// Arrange
		    CreateCrossSolarDb createCrossSolarDb = new CreateCrossSolarDb();
			Mock<MigrationBuilder> mockMigrationBuilder = new Mock<MigrationBuilder>("");
			var methodInfo = createCrossSolarDb.GetType().GetMethod("Up", BindingFlags.NonPublic | BindingFlags.Instance);

			// Act & Assert
		    Record.Exception(() =>
			    {
				    methodInfo.Invoke(createCrossSolarDb, new object[] {mockMigrationBuilder.Object});
			    });
	    }

	    [Fact]
	    public void Down_WorksFine()
	    {
		    // Arrange
		    CreateCrossSolarDb createCrossSolarDb = new CreateCrossSolarDb();
		    Mock<MigrationBuilder> mockMigrationBuilder = new Mock<MigrationBuilder>("");
		    var methodInfo = createCrossSolarDb.GetType().GetMethod("Down", BindingFlags.NonPublic | BindingFlags.Instance);

		    // Act & Assert
		    Record.Exception(() =>
		    {
			    methodInfo.Invoke(createCrossSolarDb, new object[] { mockMigrationBuilder.Object });
		    });
	    }

	    [Fact]
	    public void BuildTargetModel_WorksFine()
	    {
		    // Arrange
		    CreateCrossSolarDb createCrossSolarDb = new CreateCrossSolarDb();
		    ConventionSet mockConventionSet = new ConventionSet();
			ModelBuilder mockModelbuilder = new ModelBuilder(mockConventionSet);
			
			var methodInfo = createCrossSolarDb.GetType().GetMethod("BuildTargetModel", BindingFlags.NonPublic | BindingFlags.Instance);

		    // Act & Assert
		    Record.Exception(() =>
		    {
			    methodInfo.Invoke(createCrossSolarDb, new object[] { mockModelbuilder });
		    });
	    }

	    [Fact]
	    public void BuildModel_WorksFine()
	    {
			// Arrange
		    CrossSolarDbContextModelSnapshot createCrossSolarDb = new CrossSolarDbContextModelSnapshot();
		    ConventionSet mockConventionSet = new ConventionSet();
		    ModelBuilder mockModelbuilder = new ModelBuilder(mockConventionSet);

		    var methodInfo = createCrossSolarDb.GetType().GetMethod("BuildModel", BindingFlags.NonPublic | BindingFlags.Instance);

		    // Act & Assert
		    Record.Exception(() =>
		    {
			    methodInfo.Invoke(createCrossSolarDb, new object[] { mockModelbuilder });
		    });
	    }
	}
}
