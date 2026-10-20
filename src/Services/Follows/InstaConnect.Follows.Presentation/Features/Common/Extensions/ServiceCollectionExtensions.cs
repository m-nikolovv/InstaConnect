using InstaConnect.Common.Domain.Features.Mappers.Extensions;
using InstaConnect.Common.Domain.Features.Validations.Extensions;
using InstaConnect.Common.Presentation.Features.Common.Extensions;
using InstaConnect.Common.Presentation.Features.Common.Models;
using InstaConnect.Common.Presentation.Features.Controllers.Extensions;
using InstaConnect.Common.Presentation.Features.Exceptions.Extensions;
using InstaConnect.Follows.Presentation.Features.Follows.Extensions;
using InstaConnect.Follows.Presentation.Features.Users.Extensions;

namespace InstaConnect.Follows.Presentation.Features.Common.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddPresentation(IConfiguration configuration)
		{
			serviceCollection
				.AddUserServices()
				.AddFollowServices();

			serviceCollection
				.AddValidatedOptions<MainOptions>(MainOptions.SectionName)
				.AddServicesWithMatchingInterfaces(FollowsPresentationReference.Assembly)
				.AddApiControllers()
				.AddMappers(FollowsPresentationReference.Assembly, CommonPresentationReference.Assembly)
				.AddValidations(FollowsPresentationReference.Assembly, CommonPresentationReference.Assembly)
				.AddAuthorizationPolicies()
				.AddCorsPolicies(configuration)
				.AddRateLimiterPolicies()
				.AddExceptions();

			return serviceCollection;
		}
	}
}
