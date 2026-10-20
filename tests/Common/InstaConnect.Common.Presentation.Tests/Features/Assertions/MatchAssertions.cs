using System.Linq.Expressions;
using System.Net;

using FluentAssertions;

using InstaConnect.Common.Presentation.Tests.Features.Extensions;
using InstaConnect.Common.Presentation.Tests.Features.Utilities;
using InstaConnect.Common.Tests.Features.Assertions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Common.Presentation.Tests.Features.Assertions;

public static class MatchAssertions
{
	extension(HttpStatusCode statusCode)
	{
		public void ShouldBeOk()
		{
			statusCode.ShouldBe(HttpStatusCode.OK);
		}

		public void ShouldBeBadRequest()
		{
			statusCode.ShouldBe(HttpStatusCode.BadRequest);
		}

		public void ShouldBeNoContent()
		{
			statusCode.ShouldBe(HttpStatusCode.NoContent);
		}

		public void ShouldBeNotFound()
		{
			statusCode.ShouldBe(HttpStatusCode.NotFound);
		}

		public void ShouldBeUnauthorized()
		{
			statusCode.ShouldBe(HttpStatusCode.Unauthorized);
		}

		public void ShouldBeForbidden()
		{
			statusCode.ShouldBe(HttpStatusCode.Forbidden);
		}
	}

	extension<T>(ActionResult<T> actionResult)
		where T : class
	{
		public void ShouldBeActionResultAndSatisfy(Expression<Func<T, bool>> predicate)
		{
			actionResult
				.GetValue()
				.Should()
				.Match(predicate);
		}

		internal void ShouldBeActionResultWithStatusCode(int statusCode)
		{
			actionResult
				.Result
				.Should()
				.Match<ObjectResult>(m => m.Matches(statusCode));
		}

		public void ShouldBeActionResultWithOkStatusCode()
		{
			actionResult.ShouldBeActionResultWithStatusCode(StatusCodes.Status200OK);
		}
	}

	extension(ActionResult actionResult)
	{
		internal void ShouldBeActionResultWithStatusCode(int statusCode)
		{
			actionResult
				.Should()
				.Match<StatusCodeResult>(m => m.Matches(statusCode));
		}

		public void ShouldBeActionResultWithNoContentStatusCode()
		{
			actionResult.ShouldBeActionResultWithStatusCode(StatusCodes.Status204NoContent);
		}

		public void ShouldBeActionResultWithNotFoundStatusCode()
		{
			actionResult.ShouldBeActionResultWithStatusCode(StatusCodes.Status404NotFound);
		}

		public void ShouldBeActionResultWithBadRequestStatusCode()
		{
			actionResult.ShouldBeActionResultWithStatusCode(StatusCodes.Status400BadRequest);
		}

		public void ShouldBeActionResultWithUnathorizedStatusCode()
		{
			actionResult.ShouldBeActionResultWithStatusCode(StatusCodes.Status401Unauthorized);
		}

		public void ShouldBeActionResultWithForbiddenStatusCode()
		{
			actionResult.ShouldBeActionResultWithStatusCode(StatusCodes.Status403Forbidden);
		}
	}
}
