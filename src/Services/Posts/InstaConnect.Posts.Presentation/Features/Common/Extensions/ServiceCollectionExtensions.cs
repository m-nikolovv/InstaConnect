using InstaConnect.Common.Domain.Features.Mappers.Extensions;
using InstaConnect.Common.Domain.Features.Validations.Extensions;
using InstaConnect.Common.Presentation.Features.Common.Extensions;
using InstaConnect.Common.Presentation.Features.Common.Models;
using InstaConnect.Common.Presentation.Features.Controllers.Extensions;
using InstaConnect.Common.Presentation.Features.Exceptions.Extensions;
using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Presentation.Features.PostComments.Extensions;
using InstaConnect.Posts.Presentation.Features.PostLikes.Extensions;
using InstaConnect.Posts.Presentation.Features.Posts.Extensions;
using InstaConnect.Posts.Presentation.Features.Users.Extensions;

namespace InstaConnect.Posts.Presentation.Features.Common.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddPresentation(IConfiguration configuration)
		{
			serviceCollection
				.AddUserServices()
				.AddPostServices()
				.AddPostLikeServices()
				.AddPostCommentServices()
				.AddPostCommentLikeServices();

			serviceCollection
				.AddValidatedOptions<MainOptions>(MainOptions.SectionName)
				.AddServicesWithMatchingInterfaces(PostsPresentationReference.Assembly)
				.AddApiControllers()
				.AddMappers(PostsPresentationReference.Assembly, CommonPresentationReference.Assembly)
				.AddValidations(PostsPresentationReference.Assembly, CommonPresentationReference.Assembly)
				.AddAuthorizationPolicies()
				.AddCorsPolicies(configuration)
				.AddRateLimiterPolicies()
				.AddExceptions();

			return serviceCollection;
		}
	}
}
