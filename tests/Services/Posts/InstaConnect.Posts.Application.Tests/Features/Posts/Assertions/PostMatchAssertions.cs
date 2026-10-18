using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Application.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Events.Features.Posts;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Assertions;

public static class PostMatchAssertions
{
	extension(AddPostCommandResponse response)
	{
		public void ShouldSatisfy(AddPostCommandRequest request, Post post)
		{
			response.ShouldSatisfy(p => p.Matches(request, post));
		}
	}

	extension(UpdatePostCommandResponse response)
	{
		public void ShouldSatisfy(UpdatePostCommandRequest request, Post post)
		{
			response.ShouldSatisfy(p => p.Matches(request, post));
		}
	}

	extension(GetPostByIdQueryResponse response)
	{
		public void ShouldSatisfy(GetPostByIdQueryRequest request, Post post)
		{
			response.ShouldSatisfy(p => p.Matches(request, post));
		}
	}

	extension(AnalyzePostByIdQueryResponse response)
	{
		public void ShouldSatisfy(AnalyzePostByIdQueryRequest request, Post post)
		{
			response.ShouldSatisfy(p => p.Matches(request, post));
		}
	}

	extension(GetAllPostsQueryResponse response)
	{
		public void ShouldSatisfy(
		GetAllPostsQueryRequest request,
		ICollection<Post> posts)
		{
			response.ShouldSatisfy(p => p.Matches(request, posts));
		}

		public void ShouldSatisfy(
			GetAllPostsQueryRequest request,
			ICollection<Post> posts,
			ISortEnumTermTransformer<Post> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(request, posts, termTransformer));
		}
	}

	extension(GetAllPostsForUserQueryResponse response)
	{
		public void ShouldSatisfy(
		GetAllPostsForUserQueryRequest request,
		User user,
		ICollection<Post> posts)
		{
			response.ShouldSatisfy(p => p.Matches(request, user, posts));
		}

		public void ShouldSatisfy(
			GetAllPostsForUserQueryRequest request,
			User user,
			ICollection<Post> posts,
			ISortEnumTermTransformer<Post> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(request, user, posts, termTransformer));
		}
	}

	extension(Post post)
	{
		public void ShouldSatisfy(AddPostCommandRequest request)
		{
			post.ShouldSatisfy(p => p.Matches(request));
		}

		public void ShouldSatisfy(UpdatePostCommandRequest request)
		{
			post.ShouldSatisfy(p => p.Matches(request));
		}
	}

	extension(ICollection<PostImage> postImages)
	{
		public void ShouldSatisfy(AddPostCommandRequest request)
		{
			postImages.ShouldSatisfy(p => p.Matches(request));
		}
	}

	extension(PostAddedEventRequest r)
	{
		public void ShouldSatisfy(AddPostCommandRequest request, Post entity)
		{
			r.ShouldSatisfy(r => r.Matches(request, entity));
		}
	}

	extension(PostUpdatedEventRequest r)
	{
		public void ShouldSatisfy(UpdatePostCommandRequest request, Post entity)
		{
			r.ShouldSatisfy(r => r.Matches(request, entity));
		}
	}

	extension(PostDeletedEventRequest r)
	{
		public void ShouldSatisfy(DeletePostCommandRequest request, Post entity)
		{
			r.ShouldSatisfy(r => r.Matches(request, entity));
		}
	}
}
