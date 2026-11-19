using InstaConnect.Posts.Tests.Features.PostImages.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;

public static class PostMapper
{
	extension(User user)
	{
		public UserResponse ToResponse(
			GetAllPostsForUserQuery query)
		{
			return user.ToFullResponse();
		}
	}

	extension(Post post)
	{
		public Post To(AddPostCommand command)
		{
			return new(post.Id,
					   command.Title,
					   command.Content,
					   new(string.Empty),
					   command.UserId,
					   post.CreatedAtUtc,
					   post.UpdatedAtUtc);
		}

		public PostId ToResponse(
			AddPostCommand command)
		{
			return post.ToId();
		}

		public PostId ToResponse(
			UpdatePostCommand command)
		{
			return post.ToId();
		}

		public PostResponse ToResponse(
			GetPostByIdQuery query)
		{
			return post.ToFullResponse(query.CurrentUser.Id);
		}
	}

	extension(ICollection<Post> posts)
	{
		public ICollection<PostResponse> ToResponse(
			GetAllPostsQuery query)
		{
			return posts.Filter(query.Pagination, post => post.MatchesFilter(query.Filter), post => post.ToFullResponse(query.CurrentUser.Id));
		}

		public ICollection<PostResponse> ToResponse(
			GetAllPostsForUserQuery query)
		{
			return posts.Filter(query.Pagination, post => post.MatchesFilter(query.Filter), post => post.ToResponseWithoutUser(query.CurrentUser.Id));
		}

		public long ToTotalCountResponse(
			GetAllPostsQuery query)
		{
			return posts.Count(post => post.MatchesFilter(query.Filter));
		}

		public long ToTotalCountResponse(
			GetAllPostsForUserQuery query)
		{
			return posts.Count(post => post.MatchesFilter(query.Filter));
		}
	}

	extension(ICollection<PostImage> postImages)
	{
		public ICollection<PostImage> To(AddPostCommand command)
		{
			return [.. postImages.Zip(command.Images, (postImage, formFile) => new PostImage(
				postImage.Id,
				formFile.GetUrl(),
				postImage.CreatedAtUtc))];
		}
	}
}
