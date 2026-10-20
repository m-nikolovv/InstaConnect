using InstaConnect.Posts.Events.Features.PostLikes;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Assertions;

public static class PostLikeMatchAssertions
{
	extension(AddPostLikeCommandResponse response)
	{
		public void ShouldSatisfy(
		AddPostLikeCommandRequest request,
		PostLike postLike)
		{
			response.ShouldSatisfy(p => p.Matches(request, postLike));
		}
	}

	extension(GetPostLikeByIdQueryResponse response)
	{
		public void ShouldSatisfy(
		GetPostLikeByIdQueryRequest request,
		PostLike postLike)
		{
			response.ShouldSatisfy(p => p.Matches(request, postLike));
		}
	}

	extension(GetAllPostLikesQueryResponse response)
	{
		public void ShouldSatisfy(
		GetAllPostLikesQueryRequest request,
		Post post,
		ICollection<PostLike> postLikes)
		{
			response.ShouldSatisfy(p => p.Matches(request, post, postLikes));
		}

		public void ShouldSatisfy(
			GetAllPostLikesQueryRequest request,
			Post post,
			ICollection<PostLike> postLikes,
			ISortEnumTermTransformer<PostLike> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(request, post, postLikes, termTransformer));
		}
	}

	extension(GetAllPostLikesForUserQueryResponse response)
	{
		public void ShouldSatisfy(
		GetAllPostLikesForUserQueryRequest request,
		User user,
		ICollection<PostLike> postLikes)
		{
			response.ShouldSatisfy(p => p.Matches(request, user, postLikes));
		}

		public void ShouldSatisfy(
			GetAllPostLikesForUserQueryRequest request,
			User user,
			ICollection<PostLike> postLikes,
			ISortEnumTermTransformer<PostLike> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(request, user, postLikes, termTransformer));
		}
	}

	extension(PostLike postLike)
	{
		public void ShouldSatisfy(AddPostLikeCommandRequest request)
		{
			postLike.ShouldSatisfy(p => p.Matches(request));
		}
	}

	extension(PostLikeAddedEventRequest r)
	{
		public void ShouldSatisfy(AddPostLikeCommandRequest request, PostLike entity)
		{
			r.ShouldSatisfy(r => r.Matches(request, entity));
		}
	}

	extension(PostLikeDeletedEventRequest r)
	{
		public void ShouldSatisfy(DeletePostLikeCommandRequest request, PostLike entity)
		{
			r.ShouldSatisfy(r => r.Matches(request, entity));
		}
	}
}
