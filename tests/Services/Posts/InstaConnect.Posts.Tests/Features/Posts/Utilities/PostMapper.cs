using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;

namespace InstaConnect.Posts.Tests.Features.Posts.Utilities;

public static class PostMapper
{
	extension(Post post)
	{
		public PostId ToId()
		{
			return post.Id;
		}

		public PostResponse ToFullResponse(UserId currentUserId)
		{
			return post.ToFullResponse(currentUserId.Id);
		}

		public PostResponse ToFullResponse(string currentUserId)
		{
			return new(post.Id,
					   post.UserId,
					   post.Title,
					   post.Content,
					   post.Summary,
					   post.User?.ToFullResponse(),
					   post.PostImages.ToFullResponse(),
					   post.PostLikes.Any(pl => pl.Id.UserId.Matches(currentUserId)),
					   post.PostLikes.Count,
					   post.PostComments.Count,
					   post.CreatedAtUtc,
					   post.UpdatedAtUtc);
		}

		public PostResponse ToResponseWithoutUser(UserId currentUserId)
		{
			return post.ToResponseWithoutUser(currentUserId.Id);
		}

		public PostResponse ToResponseWithoutUser(string currentUserId)
		{
			return new(post.Id,
					   post.UserId,
					   post.Title,
					   post.Content,
					   post.Summary,
					   null,
					   post.PostImages.ToFullResponse(),
					   post.PostLikes.Any(pl => pl.Id.UserId.Matches(currentUserId)),
					   post.PostLikes.Count,
					   post.PostComments.Count,
					   post.CreatedAtUtc,
					   post.UpdatedAtUtc);
		}
	}

	extension(ICollection<Post> posts)
	{
		public ICollection<PostResponse> ToFullResponse(UserId currentUserId)
		{
			return posts.ToFullResponse(currentUserId.Id);
		}

		public ICollection<PostResponse> ToFullResponse(string currentUserId)
		{
			return [.. posts.Select(post => post.ToFullResponse(currentUserId))];
		}
	}
}
