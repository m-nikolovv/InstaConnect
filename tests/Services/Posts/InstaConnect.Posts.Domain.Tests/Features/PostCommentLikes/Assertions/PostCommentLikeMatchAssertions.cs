using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Responses;
using InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Events.Features.PostCommentLikes;

namespace InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeMatchAssertions
{
	extension(PostCommentLikeId response)
	{
		public void ShouldSatisfy(AddPostCommentLikeCommand command, PostCommentLike postCommentLike)
		{
			response.ShouldSatisfy(p => p.Matches(command, postCommentLike));
		}
	}

	extension(PostCommentLikeResponse response)
	{
		public void ShouldSatisfy(GetPostCommentLikeByIdQuery query, PostCommentLike postCommentLike)
		{
			response.ShouldSatisfy(p => p.Matches(query, postCommentLike));
		}
	}

	extension(PostCommentLikeCollectionResponse response)
	{
		public void ShouldSatisfy(
		GetAllPostCommentLikesQuery query,
		PostComment postComment,
		ICollection<PostCommentLike> postCommentLikes)
		{
			response.ShouldSatisfy(p => p.Matches(query, postComment, postCommentLikes));
		}

		public void ShouldSatisfy(
			GetAllPostCommentLikesQuery query,
			PostComment postComment,
			ICollection<PostCommentLike> postCommentLikes,
			ISortEnumTermTransformer<PostCommentLike> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(query, postComment, postCommentLikes, termTransformer));
		}

		public void ShouldSatisfy(
		GetAllPostCommentLikesForUserQuery query,
		User user,
		ICollection<PostCommentLike> postCommentLikes)
		{
			response.ShouldSatisfy(p => p.Matches(query, user, postCommentLikes));
		}

		public void ShouldSatisfy(
			GetAllPostCommentLikesForUserQuery query,
			User user,
			ICollection<PostCommentLike> postCommentLikes,
			ISortEnumTermTransformer<PostCommentLike> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(query, user, postCommentLikes, termTransformer));
		}
	}

	extension(PostCommentLike postCommentLike)
	{
		public void ShouldSatisfy(AddPostCommentLikeCommand command)
		{
			postCommentLike.ShouldSatisfy(p => p.Matches(command));
		}
	}

	extension(PostCommentLikeAddedEventRequest r)
	{
		public void ShouldSatisfy(AddPostCommentLikeCommand command, PostCommentLike entity)
		{
			r.ShouldSatisfy(r => r.Matches(command, entity));
		}
	}

	extension(PostCommentLikeDeletedEventRequest r)
	{
		public void ShouldSatisfy(DeletePostCommentLikeCommand command, PostCommentLike entity)
		{
			r.ShouldSatisfy(r => r.Matches(command, entity));
		}
	}
}
