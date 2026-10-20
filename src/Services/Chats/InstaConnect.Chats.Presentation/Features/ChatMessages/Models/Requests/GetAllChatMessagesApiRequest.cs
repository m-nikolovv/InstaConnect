using InstaConnect.Chats.Presentation.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Presentation.Features.Users.Abstractions;

namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Requests;

public record GetAllChatMessagesApiRequest(
	[UserIdFromClaim] string CurrentUserId,
	[FromRoute] string ParticipantTwoId,
	[FromQuery] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
	[FromQuery] ChatMessagesSortTerm SortTerm = ChatMessageDefaultValues.SortTerm,
	[FromQuery] int Page = ChatMessageDefaultValues.Page,
	[FromQuery] int PageSize = ChatMessageDefaultValues.PageSize) : ISortableApiRequest<ChatMessagesSortTerm>, IPaginatableApiRequest, ICurrentUserableApiRequest;
