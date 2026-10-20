using InstaConnect.Chats.Presentation.Features.Chats.Models.Requests;

namespace InstaConnect.Chats.Presentation.Features.Chats.Utilities;

public static class ChatRouteFactory
{
	public static string GetCurrentDefault()
	{
		const string Route = "api/v1/participants/current/chats";

		return Route;
	}

	public static string GetId(string participantTwoId)
	{
		const string Format = "{0}/{1}";

		return Format.FormatCurrentCulture(
			GetCurrentDefault(),
			participantTwoId);
	}

	public static string GetRoute(GetAllChatsApiRequest request)
	{
		const string Format = "{0}?participantTwoName={1}&sortOrder={2}&sortTerm={3}&page={4}&pageSize={5}";

		return Format.FormatCurrentCulture(
			GetCurrentDefault(),
			request.ParticipantTwoName,
			request.SortOrder,
			request.SortTerm,
			request.Page,
			request.PageSize);
	}

	public static string GetRoute(GetChatByIdApiRequest request)
	{
		return GetId(request.ParticipantTwoId);
	}

	public static string GetRoute(AddChatApiRequest request)
	{
		return GetCurrentDefault();
	}
}
