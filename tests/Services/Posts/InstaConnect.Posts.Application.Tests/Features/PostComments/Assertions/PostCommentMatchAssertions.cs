using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Events.Features.PostComments;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Assertions;

public static class PostCommentMatchAssertions
{
	extension(AddPostCommentCommandResponse response)
	{
		public void ShouldSatisfy(AddPostCommentCommandRequest request, PostComment postComment)
		{
			response.ShouldSatisfy(p => p.Matches(request, postComment));
		}
	}

	extension(UpdatePostCommentCommandResponse response)
	{
		public void ShouldSatisfy(UpdatePostCommentCommandRequest request, PostComment postComment)
		{
			response.ShouldSatisfy(p => p.Matches(request, postComment));
		}
	}

	extension(GetPostCommentByIdQueryResponse response)
	{
		public void ShouldSatisfy(GetPostCommentByIdQueryRequest request, PostComment postComment)
		{
			response.ShouldSatisfy(p => p.Matches(request, postComment));
		}
	}

	extension(GetAllPostCommentsQueryResponse response)
	{
		public void ShouldSatisfy(GetAllPostCommentsQueryRequest request, Post post, ICollection<PostComment> postComments)
		{
			response.ShouldSatisfy(p => p.Matches(request, post, postComments));
		}

		public void ShouldSatisfy(GetAllPostCommentsQueryRequest request, Post post, ICollection<PostComment> postComments, ISortEnumTermTransformer<PostComment> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(request, post, postComments, termTransformer));
		}
	}

	extension(GetAllPostCommentsForUserQueryResponse response)
	{
		public void ShouldSatisfy(GetAllPostCommentsForUserQueryRequest request, User user, ICollection<PostComment> postComments)
		{
			response.ShouldSatisfy(p => p.Matches(request, user, postComments));
		}

		public void ShouldSatisfy(GetAllPostCommentsForUserQueryRequest request, User user, ICollection<PostComment> postComments, ISortEnumTermTransformer<PostComment> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(request, user, postComments, termTransformer));
		}
	}

	extension(PostComment postComment)
	{
		public void ShouldSatisfy(AddPostCommentCommandRequest request)
		{
			postComment.ShouldSatisfy(p => p.Matches(request));
		}

		public void ShouldSatisfy(UpdatePostCommentCommandRequest request)
		{
			postComment.ShouldSatisfy(p => p.Matches(request));
		}
	}

	extension(ICollection<PostCommentImage> postCommentImages)
	{
		public void ShouldSatisfy(AddPostCommentCommandRequest request)
		{
			postCommentImages.ShouldSatisfy(p => p.Matches(request));
		}
	}

	extension(PostCommentAddedEventRequest r)
	{
		public void ShouldSatisfy(AddPostCommentCommandRequest request, PostComment entity)
		{
			r.ShouldSatisfy(r => r.Matches(request, entity));
		}
	}

	extension(PostCommentUpdatedEventRequest r)
	{
		public void ShouldSatisfy(UpdatePostCommentCommandRequest request, PostComment entity)
		{
			r.ShouldSatisfy(r => r.Matches(request, entity));
		}
	}

	extension(PostCommentDeletedEventRequest r)
	{
		public void ShouldSatisfy(DeletePostCommentCommandRequest request, PostComment entity)
		{
			r.ShouldSatisfy(r => r.Matches(request, entity));
		}
	}
}
