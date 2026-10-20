using InstaConnect.Posts.Domain.Features.PostLikes.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Users.Assertions;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Assertions;

public static class PostLikeProblemDetailsAssertions
{
	extension(ApplicationProblemDetails problemDetails)
	{
		public void ShouldSatisfyUserNotFound(
		AddPostLikeApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				request,
				r => r.UserId);
		}

		public void ShouldSatisfyUserNotFound(
			GetAllPostLikesForUserApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				request,
				r => r.UserId);
		}

		public void ShouldSatisfyPostNotFound(
			AddPostLikeApiRequest request)
		{
			problemDetails.ShouldSatisfyPostNotFound(
				request,
				r => r.Id);
		}

		public void ShouldSatisfyPostNotFound(
			DeletePostLikeApiRequest request)
		{
			problemDetails.ShouldSatisfyPostNotFound(
				request,
				r => r.Id);
		}

		public void ShouldSatisfyPostNotFound(
			GetPostLikeByIdApiRequest request)
		{
			problemDetails.ShouldSatisfyPostNotFound(
				request,
				r => r.Id);
		}

		public void ShouldSatisfyPostNotFound(
			GetAllPostLikesApiRequest request)
		{
			problemDetails.ShouldSatisfyPostNotFound(
				request,
				r => r.Id);
		}

		public void ShouldSatisfyPostLikeNotFound(
			DeletePostLikeApiRequest request)
		{
			problemDetails.ShouldSatisfyPostLikeNotFound(
				request,
				r => r.Id,
				r => r.UserId);
		}

		public void ShouldSatisfyPostLikeNotFound(
			GetPostLikeByIdApiRequest request)
		{
			problemDetails.ShouldSatisfyPostLikeNotFound(
				request,
				r => r.Id,
				r => r.UserId);
		}

		public void ShouldSatisfyPostLikeAlreadyExists(
			AddPostLikeApiRequest request)
		{
			problemDetails.ShouldSatisfyPostLikeAlreadyExists(
				request,
				r => r.Id,
				r => r.UserId);
		}

		internal void ShouldSatisfyPostLikeNotFound<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> userIdPropertyExpression)
		{
			problemDetails.ShouldSatisfyNotFound(
				PostLikeExceptionErrorMessages.GetNotFoundMessage(
					new(
						new(idPropertyExpression(request)),
						new(userIdPropertyExpression(request)))));
		}

		internal void ShouldSatisfyPostLikeAlreadyExists<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> userIdPropertyExpression)
		{
			problemDetails.ShouldSatisfyBadRequest(
				PostLikeExceptionErrorMessages.GetAlreadyExistsMessage(
					new(
						new(idPropertyExpression(request)),
						new(userIdPropertyExpression(request)))));
		}
	}
}
