using InstaConnect.Chats.Application.Features.Chats.Extensions;
using InstaConnect.Common.Application.Features.Common.Extensions;
using InstaConnect.Common.Application.Features.Requests.Extensions;
using InstaConnect.Common.Domain.Features.Mappers.Extensions;

namespace InstaConnect.Chats.Application.Features.Common.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddApplication()
		{
			serviceCollection
				.AddUserServices()
				.AddChatServices()
				.AddChatMessageServices();

			serviceCollection
				.AddRequests(ChatsApplicationReference.Assembly)
				.AddMappers(ChatsApplicationReference.Assembly, CommonApplicationReference.Assembly)
				.AddValidations(ChatsApplicationReference.Assembly);

			return serviceCollection;
		}
	}
}
