using InstaConnect.Posts.Domain.Features.PostComments.Models.Entities;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Responses;
using InstaConnect.Posts.Domain.Features.Users.Models.Requests;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentImages.Utilities;
using InstaConnect.Posts.Infrastructure.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Infrastructure.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostComments.Utilities;

public static class PostCommentMapper
{
	extension(PostComment postComment)
	{
		internal PostCommentResponse ToFullResponse(CurrentUserQuery query)
		{
			return new(postComment.Id,
					   postComment.UserId,
					   postComment.Content,
					   postComment.Summary,
					   postComment.User?.ToFullResponse(),
					   postComment.Post?.ToFullResponse(query),
					   postComment.PostCommentImages.ToFullResponse(),
					   postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(query.Id)),
					   postComment.CreatedAtUtc,
					   postComment.UpdatedAtUtc);
		}

		internal PostCommentResponse ToResponseWithoutUser(CurrentUserQuery query)
		{
			return new(postComment.Id,
					   postComment.UserId,
					   postComment.Content,
					   postComment.Summary,
					   null,
					   postComment.Post?.ToFullResponse(query),
					   postComment.PostCommentImages.ToFullResponse(),
					   postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(query.Id)),
					   postComment.CreatedAtUtc,
					   postComment.UpdatedAtUtc);
		}

		internal PostCommentResponse ToResponseWithoutPost(CurrentUserQuery query)
		{
			return new(postComment.Id,
					   postComment.UserId,
					   postComment.Content,
					   postComment.Summary,
					   postComment.User?.ToFullResponse(),
					   null,
					   postComment.PostCommentImages.ToFullResponse(),
					   postComment.PostCommentLikes.Any(pl => pl.Id.UserId.Matches(query.Id)),
					   postComment.CreatedAtUtc,
					   postComment.UpdatedAtUtc);
		}
	}

	extension(ICollection<PostComment> postComments)
	{
		public ICollection<PostCommentResponse> ToResponse(
			PostCommentsFilterQuery filterQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			return postComments.Filter(paginationQuery, postComment => postComment.MatchesFilter(filterQuery), postComment => postComment.ToResponseWithoutPost(currentUserQuery));
		}

		public ICollection<PostCommentResponse> ToResponse(
			PostCommentsForUserFilterQuery filterQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			return postComments.Filter(paginationQuery, postComment => postComment.MatchesFilter(filterQuery), postComment => postComment.ToResponseWithoutUser(currentUserQuery));
		}

		public long ToTotalCountResponse(
			PostCommentsFilterQuery filterQuery)
		{
			return postComments.Count(postComment => postComment.MatchesFilter(filterQuery));
		}

		public long ToTotalCountResponse(
			PostCommentsForUserFilterQuery filterQuery)
		{
			return postComments.Count(postComment => postComment.MatchesFilter(filterQuery));
		}
	}
}
