using InstaConnect.Posts.Events.Features.PostCommentLikes;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeMatchAssertions
{
	extension(AddPostCommentLikeCommandResponse response)
	{
		public void ShouldSatisfy(AddPostCommentLikeCommandRequest request, PostCommentLike postCommentLike)
		{
			response.ShouldSatisfy(p => p.Matches(request, postCommentLike));
		}
	}

	extension(GetPostCommentLikeByIdQueryResponse response)
	{
		public void ShouldSatisfy(GetPostCommentLikeByIdQueryRequest request, PostCommentLike postCommentLike)
		{
			response.ShouldSatisfy(p => p.Matches(request, postCommentLike));
		}
	}

	extension(GetAllPostCommentLikesQueryResponse response)
	{
		public void ShouldSatisfy(GetAllPostCommentLikesQueryRequest request, PostComment postComment, ICollection<PostCommentLike> postCommentLikes)
		{
			response.ShouldSatisfy(p => p.Matches(request, postComment, postCommentLikes));
		}

		public void ShouldSatisfy(GetAllPostCommentLikesQueryRequest request, PostComment postComment, ICollection<PostCommentLike> postCommentLikes, ISortEnumTermTransformer<PostCommentLike> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(request, postComment, postCommentLikes, termTransformer));
		}
	}

	extension(GetAllPostCommentLikesForUserQueryResponse response)
	{
		public void ShouldSatisfy(GetAllPostCommentLikesForUserQueryRequest request, User user, ICollection<PostCommentLike> postCommentLikes)
		{
			response.ShouldSatisfy(p => p.Matches(request, user, postCommentLikes));
		}

		public void ShouldSatisfy(GetAllPostCommentLikesForUserQueryRequest request, User user, ICollection<PostCommentLike> postCommentLikes, ISortEnumTermTransformer<PostCommentLike> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(request, user, postCommentLikes, termTransformer));
		}
	}

	extension(PostCommentLike postCommentLike)
	{
		public void ShouldSatisfy(AddPostCommentLikeCommandRequest request)
		{
			postCommentLike.ShouldSatisfy(p => p.Matches(request));
		}
	}

	extension(PostCommentLikeAddedEventRequest r)
	{
		public void ShouldSatisfy(AddPostCommentLikeCommandRequest request, PostCommentLike entity)
		{
			r.ShouldSatisfy(r => r.Matches(request, entity));
		}
	}

	extension(PostCommentLikeDeletedEventRequest r)
	{
		public void ShouldSatisfy(DeletePostCommentLikeCommandRequest request, PostCommentLike entity)
		{
			r.ShouldSatisfy(r => r.Matches(request, entity));
		}
	}
}
