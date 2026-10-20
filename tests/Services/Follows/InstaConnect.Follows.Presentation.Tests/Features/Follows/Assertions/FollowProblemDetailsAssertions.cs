using InstaConnect.Common.Presentation.Tests.Features.Assertions;
using InstaConnect.Follows.Domain.Features.Follows.Utilities;
using InstaConnect.Follows.Presentation.Tests.Features.Users.Assertions;

namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Assertions;

public static class FollowProblemDetailsAssertions
{
	extension(ApplicationProblemDetails problemDetails)
	{
		public void ShouldSatisfyFollowingNotFound(
		AddFollowApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				request,
				r => r.Body.FollowingId);
		}

		public void ShouldSatisfyFollowingNotFound(
			GetAllFollowsForFollowingApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				request,
				r => r.FollowingId);
		}

		public void ShouldSatisfyFollowerNotFound(
			AddFollowApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				request,
				r => r.FollowerId);
		}

		public void ShouldSatisfyFollowerNotFound(
			DeleteFollowApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				request,
				r => r.FollowerId);
		}

		public void ShouldSatisfyFollowerNotFound(
			GetFollowByIdApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				request,
				r => r.FollowerId);
		}

		public void ShouldSatisfyFollowerNotFound(
			GetAllFollowsApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				request,
				r => r.FollowerId);
		}

		public void ShouldSatisfyFollowNotFound(
			DeleteFollowApiRequest request)
		{
			problemDetails.ShouldSatisfyFollowNotFound(
				request,
				r => r.FollowerId,
				r => r.FollowingId);
		}

		public void ShouldSatisfyFollowNotFound(
			GetFollowByIdApiRequest request)
		{
			problemDetails.ShouldSatisfyFollowNotFound(
				request,
				r => r.FollowerId,
				r => r.FollowingId);
		}

		public void ShouldSatisfyFollowAlreadyExists(
			AddFollowApiRequest request)
		{
			problemDetails.ShouldSatisfyFollowAlreadyExists(
				request,
				r => r.FollowerId,
				r => r.Body.FollowingId);
		}

		internal void ShouldSatisfyFollowNotFound<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> userIdPropertyExpression)
		{
			problemDetails.ShouldSatisfyNotFound(
				FollowExceptionErrorMessages.GetNotFoundMessage(
					new(
						new(idPropertyExpression(request)),
						new(userIdPropertyExpression(request)))));
		}

		internal void ShouldSatisfyFollowAlreadyExists<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> userIdPropertyExpression)
		{
			problemDetails.ShouldSatisfyBadRequest(
				FollowExceptionErrorMessages.GetAlreadyExistsMessage(
					new(
						new(idPropertyExpression(request)),
						new(userIdPropertyExpression(request)))));
		}
	}
}
