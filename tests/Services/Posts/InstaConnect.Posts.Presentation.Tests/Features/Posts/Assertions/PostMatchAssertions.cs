using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Events.Features.Posts;
using InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Assertions;

public static class PostMatchAssertions
{
	extension(AddPostApiResponse response)
	{
		public void ShouldSatisfy(
		AddPostApiRequest request,
		Post post)
		{
			response.ShouldSatisfy(p => p.Matches(request, post));
		}
	}

	extension(UpdatePostApiResponse response)
	{
		public void ShouldSatisfy(
		UpdatePostApiRequest request,
		Post post)
		{
			response.ShouldSatisfy(p => p.Matches(request, post));
		}
	}

	extension(GetPostByIdApiResponse response)
	{
		public void ShouldSatisfy(
		GetPostByIdApiRequest request,
		Post post)
		{
			response.ShouldSatisfy(p => p.Matches(request, post));
		}
	}

	extension(AnalyzePostByIdApiResponse response)
	{
		public void ShouldSatisfy(
		AnalyzePostByIdApiRequest request,
		Post post)
		{
			response.ShouldSatisfy(p => p.Matches(request, post));
		}
	}

	extension(GetAllPostsApiResponse response)
	{
		public void ShouldSatisfy(
		GetAllPostsApiRequest request,
		ICollection<Post> posts)
		{
			response.ShouldSatisfy(p => p.Matches(request, posts));
		}

		public void ShouldSatisfy(
			GetAllPostsApiRequest request,
			ICollection<Post> posts,
			ISortEnumTermTransformer<Post> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(request, posts, termTransformer));
		}
	}

	extension(GetAllPostsForUserApiResponse response)
	{
		public void ShouldSatisfy(
		GetAllPostsForUserApiRequest request,
		User user,
		ICollection<Post> posts)
		{
			response.ShouldSatisfy(p => p.Matches(request, user, posts));
		}

		public void ShouldSatisfy(
			GetAllPostsForUserApiRequest request,
			User user,
			ICollection<Post> posts,
			ISortEnumTermTransformer<Post> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(request, user, posts, termTransformer));
		}
	}

	extension(ActionResult<AddPostApiResponse> response)
	{
		public void ShouldSatisfy(
		AddPostApiRequest request,
		Post post)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, post));
		}
	}

	extension(ActionResult<UpdatePostApiResponse> response)
	{
		public void ShouldSatisfy(
		UpdatePostApiRequest request,
		Post post)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, post));
		}
	}

	extension(ActionResult<GetPostByIdApiResponse> response)
	{
		public void ShouldSatisfy(
		GetPostByIdApiRequest request,
		Post post)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, post));
		}
	}

	extension(ActionResult<AnalyzePostByIdApiResponse> response)
	{
		public void ShouldSatisfy(
		AnalyzePostByIdApiRequest request,
		Post post)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, post));
		}
	}

	extension(ActionResult<GetAllPostsApiResponse> response)
	{
		public void ShouldSatisfy(
		GetAllPostsApiRequest request,
		ICollection<Post> posts)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, posts));
		}

		public void ShouldSatisfy(
		GetAllPostsApiRequest request,
		ICollection<Post> posts,
		ISortEnumTermTransformer<Post> termTransformer)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, posts, termTransformer));
		}
	}

	extension(ActionResult<GetAllPostsForUserApiResponse> response)
	{
		public void ShouldSatisfy(
		GetAllPostsForUserApiRequest request,
		User user,
		ICollection<Post> posts)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, user, posts));
		}

		public void ShouldSatisfy(
		GetAllPostsForUserApiRequest request,
		User user,
		ICollection<Post> posts,
		ISortEnumTermTransformer<Post> termTransformer)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, user, posts, termTransformer));
		}
	}

	extension(Post post)
	{
		public void ShouldSatisfy(AddPostApiRequest request)
		{
			post.ShouldSatisfy(p => p.Matches(request));
		}

		public void ShouldSatisfy(UpdatePostApiRequest request)
		{
			post.ShouldSatisfy(p => p.Matches(request));
		}
	}

	extension(ICollection<PostImage> postImages)
	{
		public void ShouldSatisfy(AddPostApiRequest request)
		{
			postImages.ShouldSatisfy(p => p.Matches(request));
		}
	}

	extension(PostAddedEventRequest r)
	{
		public void ShouldSatisfy(AddPostApiRequest request, Post entity)
		{
			r.ShouldSatisfy(r => r.Matches(request, entity));
		}
	}

	extension(PostUpdatedEventRequest r)
	{
		public void ShouldSatisfy(UpdatePostApiRequest request, Post entity)
		{
			r.ShouldSatisfy(r => r.Matches(request, entity));
		}
	}

	extension(PostDeletedEventRequest r)
	{
		public void ShouldSatisfy(DeletePostApiRequest request, Post entity)
		{
			r.ShouldSatisfy(r => r.Matches(request, entity));
		}
	}
}
