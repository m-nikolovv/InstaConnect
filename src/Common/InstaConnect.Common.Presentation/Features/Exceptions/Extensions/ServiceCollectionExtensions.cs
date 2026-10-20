using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Presentation.Features.Common.Extensions;
using InstaConnect.Common.Presentation.Features.Exceptions.Helpers;

namespace InstaConnect.Common.Presentation.Features.Exceptions.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddExceptions()
		{
			serviceCollection.AddSingleton<IApplicationProblemDetailsFactory, ApplicationProblemDetailsFactory>()
							 .AddSingleton<IApplicationProblemDetailsService, ApplicationProblemDetailsService>()
							 .AddImplementationsOf<IBaseExceptionStatus>(CommonPresentationReference.Assembly);

			serviceCollection.AddProblemDetails();

			serviceCollection.AddExceptionHandler<InvalidValidationExceptionHandler>()
							 .AddExceptionHandler<BaseExceptionHandler>()
							 .AddExceptionHandler<ExceptionHandler>();

			return serviceCollection;
		}
	}
}
