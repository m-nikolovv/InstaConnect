using InstaConnect.Common.Domain.Features.Requests.Models;
using InstaConnect.Common.Presentation.Features.Controllers.Utilities;
using InstaConnect.Common.Presentation.Features.Requests.Abstractions;
using InstaConnect.Follows.Presentation.Features.Follows.Utilities;
using InstaConnect.Follows.Presentation.Features.Users.Abstractions;
using InstaConnect.Follows.Presentation.Features.Users.Utilities;

namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;

public record GetAllFollowsForFollowingApiRequest(
	[FromRoute] string FollowingId,
	[UserIdFromClaim] string CurrentUserId,
	[FromQuery] string FollowerName = UserDefaultValues.Name,
	[FromQuery] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
	[FromQuery] FollowsForFollowingSortTerm SortTerm = FollowDefaultValues.ByFollowingSortTerm,
	[FromQuery] int Page = FollowDefaultValues.Page,
	[FromQuery] int PageSize = FollowDefaultValues.PageSize) : ISortableApiRequest<FollowsForFollowingSortTerm>, IPaginatableApiRequest, ICurrentUserableApiRequest;
