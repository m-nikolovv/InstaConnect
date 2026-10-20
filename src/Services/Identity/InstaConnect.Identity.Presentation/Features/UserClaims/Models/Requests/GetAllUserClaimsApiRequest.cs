using InstaConnect.Common.Domain.Features.Requests.Models;
using InstaConnect.Common.Presentation.Features.Requests.Abstractions;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Requests;
using InstaConnect.Identity.Presentation.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Presentation.Features.UserClaims.Models.Requests;

public record GetAllUserClaimsApiRequest(
	[FromRoute] string Id,
	[UserIdFromClaim] string CurrentId,
	[FromQuery] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
	[FromQuery] UserClaimsSortTerm SortTerm = UserClaimDefaultValues.SortTerm,
	[FromQuery] int Page = UserClaimDefaultValues.Page,
	[FromQuery] int PageSize = UserClaimDefaultValues.PageSize) : ISortableApiRequest<UserClaimsSortTerm>, IPaginatableApiRequest, ICurrentUserableApiRequest;
