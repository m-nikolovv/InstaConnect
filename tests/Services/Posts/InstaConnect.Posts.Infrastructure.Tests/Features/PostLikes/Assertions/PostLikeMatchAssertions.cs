using InstaConnect.Posts.Domain.Features.PostLikes.Models.Responses;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Assertions;

public static class PostLikeMatchAssertions
{
	extension(PostLike response)
	{
		public void ShouldSatisfy(PostLikeId id, PostLike postLike)
		{
			response.ShouldSatisfy(p => p.Matches(id, postLike));
		}
	}

	extension(PostLikeResponse response)
	{
		public void ShouldSatisfy(PostLikeId id, CurrentUserQuery currentUserQuery, PostLike postLike)
		{
			response.ShouldSatisfy(p => p.Matches(id, currentUserQuery, postLike));
		}
	}

	extension(ICollection<PostLikeResponse> response)
	{
		public void ShouldSatisfy(
			PostLikesFilterQuery filterQuery,
			PostLikesSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			Post post,
			ICollection<PostLike> postLikes)
		{
			response.ShouldSatisfy(p => p.Matches(filterQuery, sortingQuery, paginationQuery, currentUserQuery, post, postLikes));
		}

		public void ShouldSatisfy(
			PostLikesFilterQuery filterQuery,
			PostLikesSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			Post post,
			ICollection<PostLike> postLikes,
			ISortEnumTermTransformer<PostLike> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(filterQuery, sortingQuery, paginationQuery, currentUserQuery, post, postLikes, termTransformer));
		}

		public void ShouldSatisfy(
			PostLikesForUserFilterQuery filterQuery,
			PostLikesForUserSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			User user,
			ICollection<PostLike> postLikes)
		{
			response.ShouldSatisfy(p => p.Matches(filterQuery, sortingQuery, paginationQuery, currentUserQuery, user, postLikes));
		}

		public void ShouldSatisfy(
			PostLikesForUserFilterQuery filterQuery,
			PostLikesForUserSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			User user,
			ICollection<PostLike> postLikes,
			ISortEnumTermTransformer<PostLike> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(filterQuery, sortingQuery, paginationQuery, currentUserQuery, user, postLikes, termTransformer));
		}
	}

	extension(long response)
	{
		public void ShouldSatisfy(
			PostLikesFilterQuery filterQuery,
			ICollection<PostLike> postLikes)
		{
			response.ShouldSatisfy(p => p.Matches(filterQuery, postLikes));
		}

		public void ShouldSatisfy(
			PostLikesForUserFilterQuery filterQuery,
			ICollection<PostLike> postLikes)
		{
			response.ShouldSatisfy(p => p.Matches(filterQuery, postLikes));
		}
	}

	extension(bool response)
	{
		public void ShouldSatisfy(PostLikeId id, PostLike? postLike)
		{
			response.ShouldSatisfy(p => p.Matches(id, postLike));
		}
	}
}
