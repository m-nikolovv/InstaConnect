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
	}
}
