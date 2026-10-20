using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Requests;

public record GetAllPostCommentLikesForUserApiRequest(
	[FromRoute] string UserId,
	[UserIdFromClaim] string CurrentUserId,
	[FromQuery] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
	[FromQuery] PostCommentLikesForUserSortTerm SortTerm = PostCommentLikeDefaultValues.SortTermForUser,
	[FromQuery] int Page = PostCommentLikeDefaultValues.Page,
	[FromQuery] int PageSize = PostCommentLikeDefaultValues.PageSize) : ISortableApiRequest<PostCommentLikesForUserSortTerm>, IPaginatableApiRequest, ICurrentUserableApiRequest;
