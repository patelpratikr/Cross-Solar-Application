using System;
using System.Collections.Generic;
using System.Text;
using CrossSolar.Exceptions;
using Newtonsoft.Json.Linq;
using Xunit;

namespace CrossSolar.Tests.Exceptions
{
    public class HttpStatusCodeExceptionTests
    {
	    [Fact]
	    public void HttpStatusCodeException_WorksFine()
	    {
			// Arrange
		    HttpStatusCodeException httpStatusCodeException = new HttpStatusCodeException(201);

			// Act & Assert
			Assert.NotNull(httpStatusCodeException);
		}

	    [Fact]
	    public void HttpStatusCodeException_TwoParameters_WorksFine()
	    {
		    // Arrange
		    HttpStatusCodeException httpStatusCodeException = new HttpStatusCodeException(201, "Created");

		    // Act & Assert
		    Assert.NotNull(httpStatusCodeException);
			Assert.Equal(httpStatusCodeException.Message, "Created");
	    }

	    [Fact]
	    public void HttpStatusCodeException_TwoParametersException_WorksFine()
	    {
		    // Arrange
		    HttpStatusCodeException httpStatusCodeException = new HttpStatusCodeException(201, new Exception("Exception"));

		    // Act & Assert
		    Assert.NotNull(httpStatusCodeException);
		    Assert.Equal(httpStatusCodeException.Message, "System.Exception: Exception");
	    }

	    [Fact]
	    public void HttpStatusCodeException_TwoParametersJobject_WorksFine()
	    {
		    // Arrange
		    HttpStatusCodeException httpStatusCodeException = new HttpStatusCodeException(201, new JObject());

		    // Act & Assert
		    Assert.NotNull(httpStatusCodeException);
		    Assert.Equal(httpStatusCodeException.ContentType, "application/json");
	    }

	    [Fact]
	    public void HttpStatusCodeException_StatusCodeSet_WorksFine()
	    {
		    // Arrange
		    HttpStatusCodeException httpStatusCodeException = new HttpStatusCodeException(404, new JObject());
		    httpStatusCodeException.StatusCode = 201;

		    // Act & Assert
		    Assert.NotNull(httpStatusCodeException);
		    Assert.Equal(httpStatusCodeException.StatusCode, 201);
	    }
	}
}
