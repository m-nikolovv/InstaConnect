using InstaConnect.Common.Domain.Features.Mappers.Extensions;
using InstaConnect.Common.Domain.Features.Validations.Extensions;
using InstaConnect.Posts.Domain.Features.PostCommentImages.Extensions;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Domain.Features.PostComments.Extensions;
using InstaConnect.Posts.Domain.Features.PostImages.Extensions;
using InstaConnect.Posts.Domain.Features.PostLikes.Extensions;
using InstaConnect.Posts.Domain.Features.Posts.Extensions;
using InstaConnect.Posts.Domain.Features.Users.Extensions;

namespace InstaConnect.Posts.Domain.Features.Common.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddDomain()
		{
			serviceCollection
				.AddUserServices()
				.AddPostServices()
				.AddPostLikeServices()
				.AddPostImageServices()
				.AddPostCommentImageServices()
				.AddPostCommentServices()
				.AddPostCommentLikeServices();

			serviceCollection
				.AddMappers(PostsDomainReference.Assembly, CommonDomainReference.Assembly)
				.AddValidations(PostsDomainReference.Assembly, CommonDomainReference.Assembly)
				.AddServicesWithMatchingInterfaces(PostsDomainReference.Assembly);

			return serviceCollection;
		}
	}
}
