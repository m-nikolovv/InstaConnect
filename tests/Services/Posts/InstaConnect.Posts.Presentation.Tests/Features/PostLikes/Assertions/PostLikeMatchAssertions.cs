using InstaConnect.Posts.Events.Features.PostLikes;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Assertions;

public static class PostLikeMatchAssertions
{
	extension(AddPostLikeApiResponse response)
	{
		public void ShouldSatisfy(
		AddPostLikeApiRequest request,
		PostLike postLike)
		{
			response.ShouldSatisfy(p => p.Matches(request, postLike));
		}
	}

	extension(GetPostLikeByIdApiResponse response)
	{
		public void ShouldSatisfy(
		GetPostLikeByIdApiRequest request,
		PostLike postLike)
		{
			response.ShouldSatisfy(p => p.Matches(request, postLike));
		}
	}

	extension(GetAllPostLikesApiResponse response)
	{
		public void ShouldSatisfy(
		GetAllPostLikesApiRequest request,
		Post post,
		ICollection<PostLike> postLikes)
		{
			response.ShouldSatisfy(p => p.Matches(request, post, postLikes));
		}

		public void ShouldSatisfy(
			GetAllPostLikesApiRequest request,
			Post post,
			ICollection<PostLike> postLikes,
			ISortEnumTermTransformer<PostLike> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(request, post, postLikes, termTransformer));
		}
	}

	extension(GetAllPostLikesForUserApiResponse response)
	{
		public void ShouldSatisfy(
		GetAllPostLikesForUserApiRequest request,
		User user,
		ICollection<PostLike> postLikes)
		{
			response.ShouldSatisfy(p => p.Matches(request, user, postLikes));
		}

		public void ShouldSatisfy(
			GetAllPostLikesForUserApiRequest request,
			User user,
			ICollection<PostLike> postLikes,
			ISortEnumTermTransformer<PostLike> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(request, user, postLikes, termTransformer));
		}
	}

	extension(ActionResult<AddPostLikeApiResponse> response)
	{
		public void ShouldSatisfy(
		AddPostLikeApiRequest request,
		PostLike postLike)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, postLike));
		}
	}

	extension(ActionResult<GetPostLikeByIdApiResponse> response)
	{
		public void ShouldSatisfy(
		GetPostLikeByIdApiRequest request,
		PostLike postLike)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, postLike));
		}
	}

	extension(ActionResult<GetAllPostLikesApiResponse> response)
	{
		public void ShouldSatisfy(
		GetAllPostLikesApiRequest request,
		Post post,
		ICollection<PostLike> postLikes)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, post, postLikes));
		}

		public void ShouldSatisfy(
		GetAllPostLikesApiRequest request,
		Post post,
		ICollection<PostLike> postLikes,
		ISortEnumTermTransformer<PostLike> termTransformer)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, post, postLikes, termTransformer));
		}
	}

	extension(ActionResult<GetAllPostLikesForUserApiResponse> response)
	{
		public void ShouldSatisfy(
		GetAllPostLikesForUserApiRequest request,
		User user,
		ICollection<PostLike> postLikes)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, user, postLikes));
		}

		public void ShouldSatisfy(
		GetAllPostLikesForUserApiRequest request,
		User user,
		ICollection<PostLike> postLikes,
		ISortEnumTermTransformer<PostLike> termTransformer)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, user, postLikes, termTransformer));
		}
	}

	extension(PostLike postLike)
	{
		public void ShouldSatisfy(AddPostLikeApiRequest request)
		{
			postLike.ShouldSatisfy(p => p.Matches(request));
		}
	}

	extension(PostLikeAddedEventRequest r)
	{
		public void ShouldSatisfy(AddPostLikeApiRequest request, PostLike entity)
		{
			r.ShouldSatisfy(r => r.Matches(request, entity));
		}
	}

	extension(PostLikeDeletedEventRequest r)
	{
		public void ShouldSatisfy(DeletePostLikeApiRequest request, PostLike entity)
		{
			r.ShouldSatisfy(r => r.Matches(request, entity));
		}
	}
}
