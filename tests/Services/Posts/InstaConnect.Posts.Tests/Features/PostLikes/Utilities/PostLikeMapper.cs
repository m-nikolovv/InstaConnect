using InstaConnect.Posts.Domain.Features.PostLikes.Models.Responses;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

public static class PostLikeMapper
{
	extension(PostLike postLike)
	{
		public PostLikeId ToId()
		{
			return postLike.Id;
		}

		public PostLikeResponse ToFullResponse(UserId currentUserId)
		{
			return postLike.ToFullResponse(currentUserId.Id);
		}

		public PostLikeResponse ToFullResponse(string currentUserId)
		{
			return new(postLike.Id,
					   postLike.User?.ToFullResponse(),
					   postLike.Post?.ToFullResponse(currentUserId),
					   postLike.CreatedAtUtc);
		}

		public PostLikeResponse ToResponseWithoutPost()
		{
			return new(postLike.Id,
					   postLike.User?.ToFullResponse(),
					   null,
					   postLike.CreatedAtUtc);
		}

		public PostLikeResponse ToResponseWithoutUser(UserId currentUserId)
		{
			return postLike.ToResponseWithoutUser(currentUserId.Id);
		}

		public PostLikeResponse ToResponseWithoutUser(string currentUserId)
		{
			return new(postLike.Id,
					   null,
					   postLike.Post?.ToFullResponse(currentUserId),
					   postLike.CreatedAtUtc);
		}
	}

	extension(ICollection<PostLike> postLikes)
	{
		public ICollection<PostLikeResponse> ToFullResponse(UserId currentUserId)
		{
			return postLikes.ToFullResponse(currentUserId.Id);
		}

		public ICollection<PostLikeResponse> ToFullResponse(string currentUserId)
		{
			return [.. postLikes.Select(postLike => postLike.ToFullResponse(currentUserId))];
		}
	}
}
