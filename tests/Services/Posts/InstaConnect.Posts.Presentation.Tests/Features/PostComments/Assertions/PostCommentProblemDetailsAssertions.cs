using InstaConnect.Posts.Domain.Features.PostComments.Utilities;
using InstaConnect.Posts.Presentation.Tests.Features.Users.Assertions;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Assertions;

public static class PostCommentProblemDetailsAssertions
{
	extension(ApplicationProblemDetails problemDetails)
	{
		public void ShouldSatisfyUserNotFound(
		AddPostCommentApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				request,
				r => r.UserId);
		}

		public void ShouldSatisfyUserNotFound(
			GetAllPostCommentsForUserApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				request,
				r => r.UserId);
		}

		public void ShouldSatisfyPostNotFound(
			AddPostCommentApiRequest request)
		{
			problemDetails.ShouldSatisfyPostNotFound(
				request,
				r => r.Id);
		}

		public void ShouldSatisfyPostNotFound(
			UpdatePostCommentApiRequest request)
		{
			problemDetails.ShouldSatisfyPostNotFound(
				request,
				r => r.Id);
		}

		public void ShouldSatisfyPostNotFound(
			DeletePostCommentApiRequest request)
		{
			problemDetails.ShouldSatisfyPostNotFound(
				request,
				r => r.Id);
		}

		public void ShouldSatisfyPostNotFound(
			GetPostCommentByIdApiRequest request)
		{
			problemDetails.ShouldSatisfyPostNotFound(
				request,
				r => r.Id);
		}

		public void ShouldSatisfyPostNotFound(
			GetAllPostCommentsApiRequest request)
		{
			problemDetails.ShouldSatisfyPostNotFound(
				request,
				r => r.Id);
		}

		public void ShouldSatisfyPostCommentNotFound(
			UpdatePostCommentApiRequest request)
		{
			problemDetails.ShouldSatisfyPostCommentNotFound(
				request,
				r => r.Id,
				r => r.CommentId);
		}

		public void ShouldSatisfyPostCommentNotFound(
			DeletePostCommentApiRequest request)
		{
			problemDetails.ShouldSatisfyPostCommentNotFound(
				request,
				r => r.Id,
				r => r.CommentId);
		}

		public void ShouldSatisfyPostCommentNotFound(
			GetPostCommentByIdApiRequest request)
		{
			problemDetails.ShouldSatisfyPostCommentNotFound(
				request,
				r => r.Id,
				r => r.CommentId);
		}

		public void ShouldSatisfyPostCommentForbidden(
			DeletePostCommentApiRequest request)
		{
			problemDetails.ShouldSatisfyPostCommentForbidden(
				request,
				r => r.Id,
				r => r.CommentId,
				r => r.UserId);
		}

		public void ShouldSatisfyPostCommentForbidden(
			UpdatePostCommentApiRequest request)
		{
			problemDetails.ShouldSatisfyPostCommentForbidden(
				request,
				r => r.Id,
				r => r.CommentId,
				r => r.UserId);
		}

		internal void ShouldSatisfyPostCommentNotFound<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> commentIdPropertyExpression)
		{
			problemDetails.ShouldSatisfyNotFound(
				PostCommentExceptionErrorMessages.GetNotFoundMessage(
					new(
						new(idPropertyExpression(request)),
						new(commentIdPropertyExpression(request)))));
		}

		internal void ShouldSatisfyPostCommentForbidden<TRequest>(
			TRequest request,
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> commentIdPropertyExpression,
			Func<TRequest, string> userIdPropertyExpression)
		{
			problemDetails.ShouldSatisfyForbidden(
				PostCommentExceptionErrorMessages.GetForbiddenMessage(
					new(
						new(idPropertyExpression(request)),
						new(commentIdPropertyExpression(request))),
					new(userIdPropertyExpression(request))));
		}
	}
}
