using InstaConnect.Follows.Presentation.Features.Follows.Utilities;
using InstaConnect.Follows.Presentation.Features.Users.Abstractions;
using InstaConnect.Follows.Presentation.Features.Users.Utilities;

namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;

public record GetAllFollowsApiRequest(
	[FromRoute] string FollowerId,
	[UserIdFromClaim] string CurrentUserId,
	[FromQuery] string FollowingName = UserDefaultValues.Name,
	[FromQuery] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
	[FromQuery] FollowsSortTerm SortTerm = FollowDefaultValues.ByFollowerSortTerm,
	[FromQuery] int Page = FollowDefaultValues.Page,
	[FromQuery] int PageSize = FollowDefaultValues.PageSize) : ISortableApiRequest<FollowsSortTerm>, IPaginatableApiRequest, ICurrentUserableApiRequest;
