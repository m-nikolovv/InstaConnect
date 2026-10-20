using InstaConnect.Posts.Events.Features.PostCommentLikes;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeMatchAssertions
{
	extension(AddPostCommentLikeApiResponse response)
	{
		public void ShouldSatisfy(
		AddPostCommentLikeApiRequest request,
		PostCommentLike postCommentLike)
		{
			response.ShouldSatisfy(p => p.Matches(request, postCommentLike));
		}
	}

	extension(GetPostCommentLikeByIdApiResponse response)
	{
		public void ShouldSatisfy(
		GetPostCommentLikeByIdApiRequest request,
		PostCommentLike postCommentLike)
		{
			response.ShouldSatisfy(p => p.Matches(request, postCommentLike));
		}
	}

	extension(GetAllPostCommentLikesApiResponse response)
	{
		public void ShouldSatisfy(
		GetAllPostCommentLikesApiRequest request,
		PostComment postComment,
		ICollection<PostCommentLike> postCommentLikes)
		{
			response.ShouldSatisfy(p => p.Matches(request, postComment, postCommentLikes));
		}

		public void ShouldSatisfy(
			GetAllPostCommentLikesApiRequest request,
			PostComment postComment,
			ICollection<PostCommentLike> postCommentLikes,
			ISortEnumTermTransformer<PostCommentLike> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(request, postComment, postCommentLikes, termTransformer));
		}
	}

	extension(GetAllPostCommentLikesForUserApiResponse response)
	{
		public void ShouldSatisfy(
		GetAllPostCommentLikesForUserApiRequest request,
		User user,
		ICollection<PostCommentLike> postCommentLikes)
		{
			response.ShouldSatisfy(p => p.Matches(request, user, postCommentLikes));
		}

		public void ShouldSatisfy(
			GetAllPostCommentLikesForUserApiRequest request,
			User user,
			ICollection<PostCommentLike> postCommentLikes,
			ISortEnumTermTransformer<PostCommentLike> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(request, user, postCommentLikes, termTransformer));
		}
	}

	extension(ActionResult<AddPostCommentLikeApiResponse> response)
	{
		public void ShouldSatisfy(
		AddPostCommentLikeApiRequest request,
		PostCommentLike postCommentLike)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, postCommentLike));
		}
	}

	extension(ActionResult<GetPostCommentLikeByIdApiResponse> response)
	{
		public void ShouldSatisfy(
		GetPostCommentLikeByIdApiRequest request,
		PostCommentLike postCommentLike)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, postCommentLike));
		}
	}

	extension(ActionResult<GetAllPostCommentLikesApiResponse> response)
	{
		public void ShouldSatisfy(
		GetAllPostCommentLikesApiRequest request,
		PostComment postComment,
		ICollection<PostCommentLike> postCommentLikes)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, postComment, postCommentLikes));
		}

		public void ShouldSatisfy(
		GetAllPostCommentLikesApiRequest request,
		PostComment postComment,
		ICollection<PostCommentLike> postCommentLikes,
		ISortEnumTermTransformer<PostCommentLike> termTransformer)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, postComment, postCommentLikes, termTransformer));
		}
	}

	extension(ActionResult<GetAllPostCommentLikesForUserApiResponse> response)
	{
		public void ShouldSatisfy(
		GetAllPostCommentLikesForUserApiRequest request,
		User user,
		ICollection<PostCommentLike> postCommentLikes)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, user, postCommentLikes));
		}

		public void ShouldSatisfy(
		GetAllPostCommentLikesForUserApiRequest request,
		User user,
		ICollection<PostCommentLike> postCommentLikes,
		ISortEnumTermTransformer<PostCommentLike> termTransformer)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, user, postCommentLikes, termTransformer));
		}
	}

	extension(PostCommentLike postCommentLike)
	{
		public void ShouldSatisfy(AddPostCommentLikeApiRequest request)
		{
			postCommentLike.ShouldSatisfy(p => p.Matches(request));
		}
	}

	extension(PostCommentLikeAddedEventRequest r)
	{
		public void ShouldSatisfy(AddPostCommentLikeApiRequest request, PostCommentLike entity)
		{
			r.ShouldSatisfy(r => r.Matches(request, entity));
		}
	}

	extension(PostCommentLikeDeletedEventRequest r)
	{
		public void ShouldSatisfy(DeletePostCommentLikeApiRequest request, PostCommentLike entity)
		{
			r.ShouldSatisfy(r => r.Matches(request, entity));
		}
	}
}
