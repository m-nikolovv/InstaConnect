using InstaConnect.Common.Application.Features.Common.Extensions;
using InstaConnect.Common.Application.Features.Requests.Extensions;
using InstaConnect.Common.Domain.Features.Mappers.Extensions;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Extensions;

namespace InstaConnect.Posts.Application.Features.Common.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddApplication()
		{
			serviceCollection
				.AddUserServices()
				.AddPostServices()
				.AddPostLikeServices()
				.AddPostCommentServices()
				.AddPostCommentLikeServices();

			serviceCollection
				.AddRequests(PostsApplicationReference.Assembly)
				.AddMappers(PostsApplicationReference.Assembly, CommonApplicationReference.Assembly)
				.AddValidations(PostsApplicationReference.Assembly);

			return serviceCollection;
		}
	}
}
