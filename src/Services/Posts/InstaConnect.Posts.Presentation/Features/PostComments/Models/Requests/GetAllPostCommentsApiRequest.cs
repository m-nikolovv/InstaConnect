using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Presentation.Features.PostComments.Utilities;
using InstaConnect.Posts.Presentation.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Features.PostComments.Models.Requests;

public record GetAllPostCommentsApiRequest(
	[FromRoute] string Id,
	[UserIdFromClaim] string CurrentUserId,
	[FromQuery] string UserName = UserDefaultValues.Name,
	[FromQuery] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
	[FromQuery] PostCommentsSortTerm SortTerm = PostCommentDefaultValues.SortTerm,
	[FromQuery] int Page = PostCommentDefaultValues.Page,
	[FromQuery] int PageSize = PostCommentDefaultValues.PageSize) : ISortableApiRequest<PostCommentsSortTerm>, IPaginatableApiRequest, ICurrentUserableApiRequest;
