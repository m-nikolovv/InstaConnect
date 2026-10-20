namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Assertions;

public static class PostMatchAssertions
{
	extension(PostId response)
	{
		public void ShouldSatisfy(AddPostCommand command, Post post)
		{
			response.ShouldSatisfy(p => p.Matches(command, post));
		}

		public void ShouldSatisfy(UpdatePostCommand command, Post post)
		{
			response.ShouldSatisfy(p => p.Matches(command, post));
		}
	}

	extension(PostResponse response)
	{
		public void ShouldSatisfy(GetPostByIdQuery query, Post post)
		{
			response.ShouldSatisfy(p => p.Matches(query, post));
		}
	}

	extension(PostCollectionResponse response)
	{
		public void ShouldSatisfy(
		GetAllPostsQuery query,
		ICollection<Post> posts)
		{
			response.ShouldSatisfy(p => p.Matches(query, posts));
		}

		public void ShouldSatisfy(
			GetAllPostsQuery query,
			ICollection<Post> posts,
			ISortEnumTermTransformer<Post> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(query, posts, termTransformer));
		}

		public void ShouldSatisfy(
		GetAllPostsForUserQuery query,
		User user,
		ICollection<Post> posts)
		{
			response.ShouldSatisfy(p => p.Matches(query, user, posts));
		}

		public void ShouldSatisfy(
			GetAllPostsForUserQuery query,
			User user,
			ICollection<Post> posts,
			ISortEnumTermTransformer<Post> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(query, user, posts, termTransformer));
		}
	}

	extension(Post p)
	{
		public void ShouldSatisfy(AddPostCommand command)
		{
			p.ShouldSatisfy(p => p.Matches(command));
		}

		public void ShouldSatisfy(UpdatePostCommand command)
		{
			p.ShouldSatisfy(p => p.Matches(command));
		}
	}

	extension(ICollection<PostImage> postImages)
	{
		public void ShouldSatisfy(AddPostCommand command)
		{
			postImages.ShouldSatisfy(p => p.Matches(command));
		}
	}

	extension(PostAddedEventRequest r)
	{
		public void ShouldSatisfy(AddPostCommand command, Post entity)
		{
			r.ShouldSatisfy(r => r.Matches(command, entity));
		}
	}

	extension(PostUpdatedEventRequest r)
	{
		public void ShouldSatisfy(UpdatePostCommand command, Post entity)
		{
			r.ShouldSatisfy(r => r.Matches(command, entity));
		}
	}

	extension(PostDeletedEventRequest r)
	{
		public void ShouldSatisfy(DeletePostCommand command, Post entity)
		{
			r.ShouldSatisfy(r => r.Matches(command, entity));
		}
	}
}
