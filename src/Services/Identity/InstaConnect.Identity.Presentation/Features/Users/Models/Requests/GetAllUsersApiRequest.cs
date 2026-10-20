using InstaConnect.Identity.Domain.Features.Users.Models.Requests;
using InstaConnect.Identity.Presentation.Features.Users.Utilities;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public record GetAllUsersApiRequest(
	[UserIdFromClaim] string CurrentId,
	[FromQuery] string FirstName = UserDefaultValues.FirstName,
	[FromQuery] string LastName = UserDefaultValues.LastName,
	[FromQuery] string Name = UserDefaultValues.Name,
	[FromQuery] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
	[FromQuery] UsersSortTerm SortTerm = UserDefaultValues.SortTerm,
	[FromQuery] int Page = UserDefaultValues.Page,
	[FromQuery] int PageSize = UserDefaultValues.PageSize) : ISortableApiRequest<UsersSortTerm>, IPaginatableApiRequest, ICurrentUserableApiRequest;
