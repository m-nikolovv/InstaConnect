using InstaConnect.Chats.Presentation.Features.ChatMessages.Extensions;
using InstaConnect.Chats.Presentation.Features.Chats.Extensions;
using InstaConnect.Chats.Presentation.Features.Users.Extensions;
using InstaConnect.Common.Domain.Features.Mappers.Extensions;
using InstaConnect.Common.Domain.Features.Validations.Extensions;
using InstaConnect.Common.Presentation.Features.Common.Extensions;
using InstaConnect.Common.Presentation.Features.Common.Models;
using InstaConnect.Common.Presentation.Features.Controllers.Extensions;
using InstaConnect.Common.Presentation.Features.Exceptions.Extensions;

namespace InstaConnect.Chats.Presentation.Features.Common.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddPresentation(IConfiguration configuration)
		{
			serviceCollection
				.AddUserServices()
				.AddChatServices()
				.AddChatMessageServices();

			serviceCollection
				.AddValidatedOptions<MainOptions>(MainOptions.SectionName)
				.AddServicesWithMatchingInterfaces(ChatsPresentationReference.Assembly)
				.AddApiControllers()
				.AddMappers(ChatsPresentationReference.Assembly, CommonPresentationReference.Assembly)
				.AddValidations(ChatsPresentationReference.Assembly, CommonPresentationReference.Assembly)
				.AddAuthorizationPolicies()
				.AddCorsPolicies(configuration)
				.AddRateLimiterPolicies()
				.AddExceptions();

			return serviceCollection;
		}
	}
}
