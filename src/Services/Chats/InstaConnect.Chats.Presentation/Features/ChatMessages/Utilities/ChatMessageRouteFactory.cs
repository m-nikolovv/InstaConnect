using InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Requests;
using InstaConnect.Common.Domain.Features.Common.Extensions;

namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Utilities;

public static class ChatMessageRouteFactory
{
	public static string GetCurrentDefault(string participantTwoId)
	{
		const string Format = "api/v1/participants/current/chats/{0}/messages";

		return Format.FormatCurrentCulture(participantTwoId);
	}

	public static string GetId(string participantTwoId, string messageId)
	{
		const string Format = "{0}/{1}";

		return Format.FormatCurrentCulture(
			GetCurrentDefault(participantTwoId),
			messageId);
	}

	public static string GetRoute(GetAllChatMessagesApiRequest request)
	{
		const string Format = "{0}?sortOrder={1}&sortTerm={2}&page={3}&pageSize={4}";

		return Format.FormatCurrentCulture(
			GetCurrentDefault(request.ParticipantTwoId),
			request.SortOrder,
			request.SortTerm,
			request.Page,
			request.PageSize);
	}

	public static string GetRoute(GetChatMessageByIdApiRequest request)
	{
		return GetId(request.ParticipantTwoId, request.MessageId);
	}

	public static string GetRoute(AddChatMessageApiRequest request)
	{
		return GetCurrentDefault(request.ParticipantTwoId);
	}

	public static string GetRoute(UpdateChatMessageApiRequest request)
	{
		return GetId(request.ParticipantTwoId, request.MessageId);
	}

	public static string GetRoute(DeleteChatMessageApiRequest request)
	{
		return GetId(request.ParticipantTwoId, request.MessageId);
	}
}
