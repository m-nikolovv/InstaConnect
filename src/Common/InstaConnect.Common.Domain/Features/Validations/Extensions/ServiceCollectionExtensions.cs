using System.Reflection;

namespace InstaConnect.Common.Domain.Features.Validations.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddValidations(params Assembly[] assemblies)
		{
			ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop;

			serviceCollection.AddValidatorsFromAssemblies(assemblies, ServiceLifetime.Transient);

			return serviceCollection;
		}
	}
}
