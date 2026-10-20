using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Presentation.Features.PostLikes.Utilities;
using InstaConnect.Posts.Presentation.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Features.PostLikes.Models.Requests;

public record GetAllPostLikesApiRequest(
	[FromRoute] string Id,
	[UserIdFromClaim] string CurrentUserId,
	[FromQuery] string UserName = UserDefaultValues.Name,
	[FromQuery] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
	[FromQuery] PostLikesSortTerm SortTerm = PostLikeDefaultValues.SortTerm,
	[FromQuery] int Page = PostLikeDefaultValues.Page,
	[FromQuery] int PageSize = PostLikeDefaultValues.PageSize) : ISortableApiRequest<PostLikesSortTerm>, IPaginatableApiRequest, ICurrentUserableApiRequest;
