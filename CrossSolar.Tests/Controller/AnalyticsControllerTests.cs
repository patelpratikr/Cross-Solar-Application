using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CrossSolar.Controllers;
using CrossSolar.Domain;
using CrossSolar.Models;
using CrossSolar.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;


namespace CrossSolar.Tests.Controller
{
    public class AnalyticsControllerTests
    {
	    private readonly Mock<IAnalyticsRepository> _analyticsReporsitoryMock = new Mock<IAnalyticsRepository>();
	    private readonly Mock<IPanelRepository> _panelRepositoryMock = new Mock<IPanelRepository>();
	    private readonly AnalyticsController _analyticsController;
	    

		public AnalyticsControllerTests()
	    {
		    _analyticsController = new AnalyticsController(_analyticsReporsitoryMock.Object, _panelRepositoryMock.Object);
		}

		
	    [Fact]
	    public async Task Post_ShouldInsertOneHourElectricity()
	    {
		    var actionResult = await _analyticsController.Post("123", new OneHourElectricityModel());

		    Assert.IsType<CreatedResult>(actionResult);
	    }
	}
}
