using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CrossSolar.Domain;
using CrossSolar.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Moq;
using Xunit;

namespace CrossSolar.Tests.Repository
{
    public class GenericRepositoryTest
    {
	    [Fact]
	    public void GetAsync_WorksFine()
	    {
			// Arrange
			Mock<CrossSolarDbContext> mock = new Mock<CrossSolarDbContext>();
			mock.Setup(a => a.FindAsync(null)).Returns(Task.FromResult<object>(new Panel()));

			// Act
			GenericRepository<Panel> genericRepository = new PanelRepository(mock.Object);
			var actual = genericRepository.GetAsync("123");

		    Assert.IsAssignableFrom<Task<Panel>>(actual);
		}

	    [Fact]
	    public void Query_WorksFine()
	    {
		    // Arrange
		    Mock<CrossSolarDbContext> mock = new Mock<CrossSolarDbContext>();
			Mock<DbSet<Panel>> mockDbSet = new Mock<DbSet<Panel>>();
			
		    mock.Setup(a => a.Set<Panel>()).Returns(() => mockDbSet.Object);

			// Act
			GenericRepository<Panel> genericRepository = new PanelRepository(mock.Object);
		    var actual = genericRepository.Query();

			// Assert
		    Assert.IsAssignableFrom<IQueryable<Panel>>(actual);
	    }

	    [Fact]
	    public void InsertAsync_WorksFine()
	    {
		    // Arrange
		    Mock<CrossSolarDbContext> mock = new Mock<CrossSolarDbContext>();
		    Mock<DbSet<Panel>> mockDbSet = new Mock<DbSet<Panel>>();

		    mock.Setup(a => a.Set<Panel>()).Returns(() => mockDbSet.Object);
		    mock.Setup(a => a.SaveChangesAsync(true, CancellationToken.None)).Returns(Task.FromResult(1));

			// Act
			GenericRepository<Panel> genericRepository = new PanelRepository(mock.Object);
		    var actual = Record.ExceptionAsync(() => genericRepository.InsertAsync(new Panel()));

		    Assert.Null(actual.Result);
	    }
	}
}
