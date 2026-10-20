using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Presentation.Features.Chats.Utilities;
using InstaConnect.Chats.Presentation.Features.Users.Abstractions;
using InstaConnect.Chats.Presentation.Features.Users.Utilities;
using InstaConnect.Common.Domain.Features.Requests.Models;
using InstaConnect.Common.Presentation.Features.Controllers.Utilities;
using InstaConnect.Common.Presentation.Features.Requests.Abstractions;

namespace InstaConnect.Chats.Presentation.Features.Chats.Models.Requests;

public record GetAllChatsApiRequest(
	[UserIdFromClaim] string CurrentUserId,
	[FromQuery] string ParticipantTwoName = UserDefaultValues.Name,
	[FromQuery] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
	[FromQuery] ChatsSortTerm SortTerm = ChatDefaultValues.SortTerm,
	[FromQuery] int Page = ChatDefaultValues.Page,
	[FromQuery] int PageSize = ChatDefaultValues.PageSize) : ISortableApiRequest<ChatsSortTerm>, IPaginatableApiRequest, ICurrentUserableApiRequest;
