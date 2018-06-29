using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using CrossSolar.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace CrossSolar.Tests.Exceptions
{
    public class HttpStatusCodeExceptionMiddlewareTests
    {
	    [Fact]
	    public void HttpStatusCodeExceptionMiddleware_WorksFine()
	    {
		    var exception = Record.Exception(() =>
		    {
			    HttpStatusCodeExceptionMiddleware httpStatusCodeExceptionMiddleware =
				    new HttpStatusCodeExceptionMiddleware(new RequestDelegate(
					    delegate(HttpContext context) { return Task.FromResult(1); }), new LoggerFactory());
		    });

			Assert.Null(exception);
	    }

	    [Fact]
	    public async Task Invoke_WorksFine()
	    {
			HttpStatusCodeExceptionMiddleware httpStatusCodeExceptionMiddleware =
				new HttpStatusCodeExceptionMiddleware(new RequestDelegate(
					delegate (HttpContext context) { return Task.FromResult(1); }), new LoggerFactory());

			var actual = httpStatusCodeExceptionMiddleware.Invoke(context: new DefaultHttpContext());

		    await Assert.IsAssignableFrom<Task>(actual);
	    }

	    [Fact]
	    public async Task Invoke_ThrowsException_WorksFine()
	    {
			// Arrange
		    HttpStatusCodeExceptionMiddleware httpStatusCodeExceptionMiddleware =
			    new HttpStatusCodeExceptionMiddleware(new RequestDelegate(
				    delegate (HttpContext context) { throw new HttpStatusCodeException(404); }), new LoggerFactory());
			Mock<HttpContext> httpContext = new Mock<HttpContext>();
			Mock<HttpResponse> httpResponse = new Mock<HttpResponse>();
		    httpResponse.Setup(a => a.HasStarted).Returns(true);
			httpContext.Setup(a => a.Response).Returns(httpResponse.Object);

			// Act
		    var actual = Record.ExceptionAsync(() => httpStatusCodeExceptionMiddleware.Invoke(httpContext.Object));

		    // Assert
			Assert.NotNull(actual.Result);
	    }


	    [Fact]
	    public async Task Invoke_ThrowsException_HandlesWorksFine()
	    {
		    // Arrange
		    HttpStatusCodeExceptionMiddleware httpStatusCodeExceptionMiddleware =
			    new HttpStatusCodeExceptionMiddleware(new RequestDelegate(
				    delegate (HttpContext context) { throw new HttpStatusCodeException(404); }), new LoggerFactory());
		    Mock<HttpContext> httpContext = new Mock<HttpContext>();
		    Mock<HttpResponse> httpResponse = new Mock<HttpResponse>();
			
		    httpResponse.Setup(a => a.HasStarted).Returns(false);
		    httpResponse.Setup(a => a.StatusCode).Returns(201);
		    httpResponse.Setup(a => a.ContentType).Returns("json");
			httpContext.Setup(a => a.Response).Returns(httpResponse.Object);

		    // Act
		    var actual = Record.ExceptionAsync(() => httpStatusCodeExceptionMiddleware.Invoke(httpContext.Object));

		    // Assert
		    Assert.NotNull(actual.Result);
	    }

	}
}
