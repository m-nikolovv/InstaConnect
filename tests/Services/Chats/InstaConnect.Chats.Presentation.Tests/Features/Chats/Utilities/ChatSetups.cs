using InstaConnect.Chats.Domain.Features.Chats.Models.Responses;
using InstaConnect.Chats.Domain.Features.Chats.Models.ValueObjects;
using InstaConnect.Chats.Presentation.Features.Chats.Controllers.v1;

namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Utilities;

public static class ChatSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public ChatController GetChatController()
		{
			return serviceProvider.GetRequiredService<ChatController>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public ChatController GetChatController()
		{
			return serviceScope.ServiceProvider.GetChatController();
		}

		internal async Task<Chat?> GetByIdAsync(
		ChatIdApiResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				new ChatId(new(id.ParticipantOneId), new(id.ParticipantTwoId)),
				cancellationToken);
		}

		public async Task<Chat?> GetByIdAsync(
			AddChatApiResponse response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<Chat?> GetByIdAsync(
			ActionResult<AddChatApiResponse> response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.GetValue(),
				cancellationToken);
		}

		public async Task<ChatResponse?> GetChatCacheByIdAsync(
			GetChatByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetChatCacheByIdAsync(request.CurrentUserId, request.ParticipantTwoId, request.CurrentUserId, cancellationToken);
		}

		public async Task SetupAddAsync(
			AddChatApiRequest request,
			User participantOne,
			User participantTwo,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddChatAsync(participantOne, participantTwo, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			GetAllChatsApiRequest request,
			ICollection<User> participantOnes,
			ICollection<User> participantTwos,
			ICollection<Chat> chats,
			ICollection<ChatMessage> chatMessages,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllChatsAsync(participantOnes, participantTwos, chats, chatMessages, cancellationToken);
		}

		public async Task SetupGetByIdAsync(
			GetChatByIdApiRequest request,
			User participantOne,
			User participantTwo,
			Chat chat,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetChatByIdAsync(participantOne, participantTwo, chat, cancellationToken);
		}
	}
}
