using InstaConnect.Posts.Domain.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Users.Assertions;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeProblemDetailsAssertions
{
	extension(ApplicationProblemDetails problemDetails)
	{
		public void ShouldSatisfyUserNotFound(
		AddPostCommentLikeApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				request,
				r => r.UserId);
		}

		public void ShouldSatisfyUserNotFound(
			GetAllPostCommentLikesForUserApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				request,
				r => r.UserId);
		}

		public void ShouldSatisfyPostNotFound(
			AddPostCommentLikeApiRequest request)
		{
			problemDetails.ShouldSatisfyPostNotFound(
				request,
				r => r.Id);
		}

		public void ShouldSatisfyPostNotFound(
			DeletePostCommentLikeApiRequest request)
		{
			problemDetails.ShouldSatisfyPostNotFound(
				request,
				r => r.Id);
		}

		public void ShouldSatisfyPostNotFound(
			GetPostCommentLikeByIdApiRequest request)
		{
			problemDetails.ShouldSatisfyPostNotFound(
				request,
				r => r.Id);
		}

		public void ShouldSatisfyPostNotFound(
			GetAllPostCommentLikesApiRequest request)
		{
			problemDetails.ShouldSatisfyPostNotFound(
				request,
				r => r.Id);
		}

		public void ShouldSatisfyPostCommentNotFound(
			AddPostCommentLikeApiRequest request)
		{
			problemDetails.ShouldSatisfyPostCommentNotFound(
				request,
				r => r.Id,
				r => r.CommentId);
		}

		public void ShouldSatisfyPostCommentNotFound(
			DeletePostCommentLikeApiRequest request)
		{
			problemDetails.ShouldSatisfyPostCommentNotFound(
				request,
				r => r.Id,
				r => r.CommentId);
		}

		public void ShouldSatisfyPostCommentNotFound(
			GetPostCommentLikeByIdApiRequest request)
		{
			problemDetails.ShouldSatisfyPostCommentNotFound(
				request,
				r => r.Id,
				r => r.CommentId);
		}

		public void ShouldSatisfyPostCommentNotFound(
			GetAllPostCommentLikesApiRequest request)
		{
			problemDetails.ShouldSatisfyPostCommentNotFound(
				request,
				r => r.Id,
				r => r.CommentId);
		}

		public void ShouldSatisfyPostCommentLikeNotFound(
			DeletePostCommentLikeApiRequest request)
		{
			problemDetails.ShouldSatisfyPostCommentLikeNotFound(
				request,
				r => r.Id,
				r => r.CommentId,
				r => r.UserId);
		}

		public void ShouldSatisfyPostCommentLikeNotFound(
			GetPostCommentLikeByIdApiRequest request)
		{
			problemDetails.ShouldSatisfyPostCommentLikeNotFound(
				request,
				r => r.Id,
				r => r.CommentId,
				r => r.UserId);
		}

		public void ShouldSatisfyPostCommentLikeAlreadyExists(
			AddPostCommentLikeApiRequest request)
		{
			problemDetails.ShouldSatisfyPostCommentLikeAlreadyExists(
				request,
				r => r.Id,
				r => r.CommentId,
				r => r.UserId);
		}

		internal void ShouldSatisfyPostCommentLikeNotFound<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> commentIdPropertyExpression,
			Func<TRequest, string> userIdPropertyExpression)
		{
			problemDetails.ShouldSatisfyNotFound(
				PostCommentLikeExceptionErrorMessages.GetNotFoundMessage(
					new(
						new(
							new(idPropertyExpression(request)),
							commentIdPropertyExpression(request)),
						new(userIdPropertyExpression(request)))));
		}

		internal void ShouldSatisfyPostCommentLikeAlreadyExists<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> commentIdPropertyExpression,
			Func<TRequest, string> userIdPropertyExpression)
		{
			problemDetails.ShouldSatisfyBadRequest(
				PostCommentLikeExceptionErrorMessages.GetAlreadyExistsMessage(
					new(
						new(
							new(idPropertyExpression(request)),
							commentIdPropertyExpression(request)),
						new(userIdPropertyExpression(request)))));
		}
	}
}
