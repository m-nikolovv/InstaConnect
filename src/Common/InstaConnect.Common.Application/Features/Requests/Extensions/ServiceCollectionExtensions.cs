using System.Reflection;

using InstaConnect.Common.Application.Features.Caches.PipelineBehaviors;
using InstaConnect.Common.Application.Features.Databases.PipelineBehaviors;
using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Common.Application.Features.Requests.Helpers;
using InstaConnect.Common.Application.Features.Validations.PipelineBehaviors;

namespace InstaConnect.Common.Application.Features.Requests.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddRequests(params Assembly[] assemblies)
		{
			serviceCollection.AddMediatR(
				cf =>
				{
					cf.RegisterServicesFromAssemblies(assemblies);

					cf.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
					cf.AddOpenBehavior(typeof(CachePipelineBehavior<,>));
					cf.AddOpenBehavior(typeof(UnitOfWorkPipelineBehavior<,>));
				});

			serviceCollection.AddScoped<IApplicationSender, ApplicationSender>();

			return serviceCollection;
		}
	}
}
