using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
using InstaConnect.Posts.Domain.Features.Users.Models.Requests;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostImages.Utilities;
using InstaConnect.Posts.Infrastructure.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Infrastructure.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.Posts.Utilities;

public static class PostMapper
{
	extension(Post post)
	{
		internal PostResponse ToFullResponse(CurrentUserQuery query)
		{
			return new(post.Id,
					   post.UserId,
					   post.Title,
					   post.Content,
					   post.User?.ToFullResponse(),
					   post.PostImages.ToFullResponse(),
					   post.PostLikes.Any(pl => pl.Id.UserId.Matches(query.Id)),
					   post.CreatedAtUtc,
					   post.UpdatedAtUtc);
		}

		internal PostResponse ToResponseWithoutUser(CurrentUserQuery query)
		{
			return new(post.Id,
					   post.UserId,
					   post.Title,
					   post.Content,
					   null,
					   post.PostImages.ToFullResponse(),
					   post.PostLikes.Any(pl => pl.Id.UserId.Matches(query.Id)),
					   post.CreatedAtUtc,
					   post.UpdatedAtUtc);
		}
	}

	extension(ICollection<Post> posts)
	{
		public ICollection<PostResponse> ToResponse(
			PostsFilterQuery filterQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			return posts.Filter(paginationQuery, post => post.MatchesFilter(filterQuery), post => post.ToFullResponse(currentUserQuery));
		}

		public ICollection<PostResponse> ToResponse(
			PostsForUserFilterQuery filterQuery,
			PostsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			return posts.Filter(paginationQuery, post => post.MatchesFilter(filterQuery), post => post.ToResponseWithoutUser(currentUserQuery));
		}

		public long ToTotalCountResponse(
			PostsFilterQuery filterQuery)
		{
			return posts.Count(post => post.MatchesFilter(filterQuery));
		}

		public long ToTotalCountResponse(
			PostsForUserFilterQuery filterQuery)
		{
			return posts.Count(post => post.MatchesFilter(filterQuery));
		}
	}
}
