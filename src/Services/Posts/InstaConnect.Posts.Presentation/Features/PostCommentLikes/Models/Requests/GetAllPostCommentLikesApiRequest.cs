using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Presentation.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Requests;

public record GetAllPostCommentLikesApiRequest(
	[FromRoute] string Id,
	[FromRoute] string CommentId,
	[UserIdFromClaim] string CurrentUserId,
	[FromQuery] string UserName = UserDefaultValues.Name,
	[FromQuery] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
	[FromQuery] PostCommentLikesSortTerm SortTerm = PostCommentLikeDefaultValues.SortTerm,
	[FromQuery] int Page = PostCommentLikeDefaultValues.Page,
	[FromQuery] int PageSize = PostCommentLikeDefaultValues.PageSize) : ISortableApiRequest<PostCommentLikesSortTerm>, IPaginatableApiRequest, ICurrentUserableApiRequest;
