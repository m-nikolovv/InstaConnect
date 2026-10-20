using System.Linq.Expressions;

using InstaConnect.Common.Domain.Features.Exceptions.Utilities;
using InstaConnect.Common.Presentation.Features.Exceptions.Models;
using InstaConnect.Common.Presentation.Tests.Features.Assertions;
using InstaConnect.Common.Presentation.Tests.Features.Utilities;
using InstaConnect.Common.Tests.Features.Assertions;
using InstaConnect.Common.Tests.Features.DataAttributes.Base;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Presentation.Tests.Features.Assertions;

public static class ProblemDetailsAssertions
{
	extension(ApplicationProblemDetails problemDetails)
	{
		internal void ShouldSatisfy(int statusCode, string errorMessage)
		{
			problemDetails.ShouldSatisfy(d => d.Matches(statusCode, errorMessage));
		}

		public void ShouldSatisfyInvalidValidation<TRequest, TProperty>(
			TRequest request,
			Expression<Func<TRequest, TProperty>> propertyExpression,
			IMessageTransformer<TProperty> messageTransformer)
		{
			problemDetails.ShouldSatisfy(d => d.Matches(
				StatusCodes.Status400BadRequest,
				CommonExceptionErrorMessages.GetInvalidValidation(),
				messageTransformer.Transform(propertyExpression, propertyExpression.Compile()(request))));
		}

		public void ShouldSatisfyBadRequest(string errorMessage)
		{
			problemDetails.ShouldSatisfy(StatusCodes.Status400BadRequest, errorMessage);
		}

		public void ShouldSatisfyForbidden(string errorMessage)
		{
			problemDetails.ShouldSatisfy(StatusCodes.Status403Forbidden, errorMessage);
		}

		public void ShouldSatisfyNotFound(string errorMessage)
		{
			problemDetails.ShouldSatisfy(StatusCodes.Status404NotFound, errorMessage);
		}
	}
}
