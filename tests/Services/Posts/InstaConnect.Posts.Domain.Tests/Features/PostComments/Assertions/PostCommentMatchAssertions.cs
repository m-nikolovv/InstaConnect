using InstaConnect.Posts.Events.Features.PostComments;

namespace InstaConnect.Posts.Domain.Tests.Features.PostComments.Assertions;

public static class PostCommentMatchAssertions
{
	extension(PostCommentId response)
	{
		public void ShouldSatisfy(AddPostCommentCommand command, PostComment postComment)
		{
			response.ShouldSatisfy(p => p.Matches(command, postComment));
		}

		public void ShouldSatisfy(UpdatePostCommentCommand command, PostComment postComment)
		{
			response.ShouldSatisfy(p => p.Matches(command, postComment));
		}
	}

	extension(PostCommentResponse response)
	{
		public void ShouldSatisfy(GetPostCommentByIdQuery query, PostComment postComment)
		{
			response.ShouldSatisfy(p => p.Matches(query, postComment));
		}
	}

	extension(PostCommentCollectionResponse response)
	{
		public void ShouldSatisfy(
		GetAllPostCommentsQuery query,
		Post post,
		ICollection<PostComment> postComments)
		{
			response.ShouldSatisfy(p => p.Matches(query, post, postComments));
		}

		public void ShouldSatisfy(
			GetAllPostCommentsQuery query,
			Post post,
			ICollection<PostComment> postComments,
			ISortEnumTermTransformer<PostComment> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(query, post, postComments, termTransformer));
		}

		public void ShouldSatisfy(
		GetAllPostCommentsForUserQuery query,
		User user,
		ICollection<PostComment> postComments)
		{
			response.ShouldSatisfy(p => p.Matches(query, user, postComments));
		}

		public void ShouldSatisfy(
			GetAllPostCommentsForUserQuery query,
			User user,
			ICollection<PostComment> postComments,
			ISortEnumTermTransformer<PostComment> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(query, user, postComments, termTransformer));
		}
	}

	extension(PostComment postComment)
	{
		public void ShouldSatisfy(AddPostCommentCommand command)
		{
			postComment.ShouldSatisfy(p => p.Matches(command));
		}

		public void ShouldSatisfy(UpdatePostCommentCommand command)
		{
			postComment.ShouldSatisfy(p => p.Matches(command));
		}
	}

	extension(ICollection<PostCommentImage> postCommentImages)
	{
		public void ShouldSatisfy(AddPostCommentCommand command)
		{
			postCommentImages.ShouldSatisfy(p => p.Matches(command));
		}
	}

	extension(PostCommentAddedEventRequest r)
	{
		public void ShouldSatisfy(AddPostCommentCommand command, PostComment entity)
		{
			r.ShouldSatisfy(r => r.Matches(command, entity));
		}
	}

	extension(PostCommentUpdatedEventRequest r)
	{
		public void ShouldSatisfy(UpdatePostCommentCommand command, PostComment entity)
		{
			r.ShouldSatisfy(r => r.Matches(command, entity));
		}
	}

	extension(PostCommentDeletedEventRequest r)
	{
		public void ShouldSatisfy(DeletePostCommentCommand command, PostComment entity)
		{
			r.ShouldSatisfy(r => r.Matches(command, entity));
		}
	}
}
