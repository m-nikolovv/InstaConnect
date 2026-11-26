using InstaConnect.Posts.Domain.Features.PostLikes.Models.Responses;

namespace InstaConnect.Posts.Domain.Tests.Features.PostLikes.Utilities;

public static class PostLikeMapper
{
	extension(User user)
	{
		public UserResponse ToResponse(
			GetAllPostLikesForUserQuery query)
		{
			return user.ToFullResponse();
		}
	}

	extension(Post post)
	{
		public PostResponse ToResponse(
			GetAllPostLikesQuery query)
		{
			return post.ToFullResponse(query.CurrentUser.Id);
		}
	}


	extension(PostLike postLike)
	{
		public PostLike To(AddPostLikeCommand command)
		{
			return new(
				new(command.Id, command.UserId),
				postLike.CreatedAtUtc);
		}

		public PostLikeId ToResponse(
			AddPostLikeCommand command)
		{
			return postLike.ToId();
		}

		public PostLikeResponse ToResponse(
			GetPostLikeByIdQuery query)
		{
			return postLike.ToFullResponse(query.CurrentUser.Id);
		}
	}

	extension(ICollection<PostLike> postLikes)
	{
		public ICollection<PostLikeResponse> ToResponse(
			GetAllPostLikesQuery query)
		{
			return postLikes.Filter(query.Pagination, postLike => postLike.MatchesFilter(query.Filter), postLike => postLike.ToResponseWithoutPost());
		}

		public ICollection<PostLikeResponse> ToResponse(
			GetAllPostLikesForUserQuery query)
		{
			return postLikes.Filter(query.Pagination, postLike => postLike.MatchesFilter(query.Filter), postLike => postLike.ToResponseWithoutUser(query.CurrentUser.Id));
		}

		public long ToTotalCountResponse(
			GetAllPostLikesQuery query)
		{
			return postLikes.Count(postLike => postLike.MatchesFilter(query.Filter));
		}

		public long ToTotalCountResponse(
			GetAllPostLikesForUserQuery query)
		{
			return postLikes.Count(postLike => postLike.MatchesFilter(query.Filter));
		}
	}
}
