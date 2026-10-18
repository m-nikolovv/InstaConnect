using InstaConnect.Common.Presentation.Features.Exceptions.Models;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Assertions;

public static class PostProblemDetailsAssertions
{
	extension(ApplicationProblemDetails problemDetails)
	{
		public void ShouldSatisfyUserNotFound(
		AddPostApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				request,
				r => r.UserId);
		}

		public void ShouldSatisfyUserNotFound(
			GetAllPostsForUserApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				request,
				r => r.UserId);
		}

		public void ShouldSatisfyPostNotFound(
			UpdatePostApiRequest request)
		{
			problemDetails.ShouldSatisfyPostNotFound(
				request,
				r => r.Id);
		}

		public void ShouldSatisfyPostNotFound(
			GetPostByIdApiRequest request)
		{
			problemDetails.ShouldSatisfyPostNotFound(
				request,
				r => r.Id);
		}

		public void ShouldSatisfyPostNotFound(
			DeletePostApiRequest request)
		{
			problemDetails.ShouldSatisfyPostNotFound(
				request,
				r => r.Id);
		}

		public void ShouldSatisfyPostForbidden(
			UpdatePostApiRequest request)
		{
			problemDetails.ShouldSatisfyPostForbidden(
				request,
				r => r.Id,
				r => r.UserId);
		}

		public void ShouldSatisfyPostForbidden(
			DeletePostApiRequest request)
		{
			problemDetails.ShouldSatisfyPostForbidden(
				request,
				r => r.Id,
				r => r.UserId);
		}

		internal void ShouldSatisfyPostNotFound<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression)
		{
			problemDetails.ShouldSatisfyNotFound(
				PostExceptionErrorMessages.GetNotFoundMessage(new(idPropertyExpression(request))));
		}

		internal void ShouldSatisfyPostForbidden<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> userIdPropertyExpression)
		{
			problemDetails.ShouldSatisfyForbidden(
				PostExceptionErrorMessages.GetForbiddenMessage(
					new(idPropertyExpression(request)),
					new(userIdPropertyExpression(request))));
		}
	}
}
