using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Presentation.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Presentation.Features.PostComments.Models.Requests;

public record GetAllPostCommentsForUserApiRequest(
	[FromRoute] string UserId,
	[UserIdFromClaim] string CurrentUserId,
	[FromQuery] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
	[FromQuery] PostCommentsForUserSortTerm SortTerm = PostCommentDefaultValues.SortTermForUser,
	[FromQuery] int Page = PostCommentDefaultValues.Page,
	[FromQuery] int PageSize = PostCommentDefaultValues.PageSize) : ISortableApiRequest<PostCommentsForUserSortTerm>, IPaginatableApiRequest, ICurrentUserableApiRequest;
