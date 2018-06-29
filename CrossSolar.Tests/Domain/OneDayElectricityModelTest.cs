using System;
using System.Collections.Generic;
using System.Text;
using CrossSolar.Domain;
using Xunit;

namespace CrossSolar.Tests.Domain
{
    public class OneDayElectricityModelTest
    {
	    OneDayElectricityModel oneDayElectricityModel = new OneDayElectricityModel();

		public OneDayElectricityModelTest()
	    {
		    oneDayElectricityModel.Sum = 101;
		    oneDayElectricityModel.Average = 101;
		    oneDayElectricityModel.Maximum = 101;
		    oneDayElectricityModel.Minimum = 1;
		    oneDayElectricityModel.DateTime = DateTime.Now;
		}

	    [Fact]
	    public void OneDayElectricityModel_SetsFine()
	    {
			// Act & Assert
			Assert.Equal(oneDayElectricityModel.Sum, 101);
		    Assert.Equal(oneDayElectricityModel.Average, 101);
		    Assert.Equal(oneDayElectricityModel.Maximum, 101);
		    Assert.Equal(oneDayElectricityModel.Minimum, 1);
		}

	    [Fact]
	    public void OneDayElectricityModel_GetFine()
	    {
			// Act & Assert
		    var sum = oneDayElectricityModel.Sum;
		    var average = oneDayElectricityModel.Average;
		    var maximum = oneDayElectricityModel.Maximum;
		    var minimum = oneDayElectricityModel.Minimum;
		    var dateTime = oneDayElectricityModel.DateTime;

			Assert.Equal(101, sum);
		    Assert.Equal(101, average);
		    Assert.Equal(101, maximum);
		    Assert.Equal(1, minimum);
		}

	}
}
