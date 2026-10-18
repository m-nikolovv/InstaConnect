using InstaConnect.Chats.Domain.Features.ChatMessageImages.Extensions;
using InstaConnect.Chats.Domain.Features.ChatMessages.Extensions;
using InstaConnect.Chats.Domain.Features.Chats.Extensions;
using InstaConnect.Chats.Domain.Features.Users.Extensions;
using InstaConnect.Common.Domain.Features.Mappers.Extensions;
using InstaConnect.Common.Domain.Features.Validations.Extensions;

namespace InstaConnect.Chats.Domain.Features.Common.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddDomain()
		{
			serviceCollection
				.AddUserServices()
				.AddChatServices()
				.AddChatMessageServices()
				.AddChatMessageImageServices();

			serviceCollection
				.AddMappers(ChatsDomainReference.Assembly, CommonDomainReference.Assembly)
				.AddValidations(ChatsDomainReference.Assembly, CommonDomainReference.Assembly)
				.AddServicesWithMatchingInterfaces(ChatsDomainReference.Assembly);

			return serviceCollection;
		}
	}
}
