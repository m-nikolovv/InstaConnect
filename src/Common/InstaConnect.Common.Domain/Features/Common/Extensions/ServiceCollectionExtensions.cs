using System.Reflection;

using InstaConnect.Common.Domain.Features.Common.Helpers;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

using Scrutor;

namespace InstaConnect.Common.Domain.Features.Common.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddServicesWithMatchingInterfaces(params Assembly[] assemblies)
		{
			serviceCollection
				.Scan(selector => selector
					.FromAssemblies(assemblies)
					.AddClasses(false)
					.UsingRegistrationStrategy(RegistrationStrategy.Skip)
					.AsMatchingInterface()
					.WithScopedLifetime());

			return serviceCollection;
		}

		public IServiceCollection AddImplementationsOf<TInterface>(params Assembly[] assemblies)
			where TInterface : class
		{
			serviceCollection
				.Scan(selector => selector
					.FromAssemblies(assemblies)
					.AddClasses(classes => classes.AssignableTo<TInterface>(), false)
					.As<TInterface>()
					.WithTransientLifetime());

			return serviceCollection;
		}

		public IServiceCollection AddValidatedOptions<TOptions>(string sectionName)
			where TOptions : class, IApplicationOptions
		{
			serviceCollection
				.AddOptions<TOptions>()
				.ValidateFluentValidation(sectionName)
				.ValidateOnStart();

			serviceCollection.AddSingleton(sp => sp.GetRequiredService<IOptions<TOptions>>().Value);

			serviceCollection.AddTransient<IOptionsFactory<TOptions>>(serviceProvider => new ConfigurationOptionsFactory<TOptions>(
				sectionName,
				serviceProvider.GetRequiredService<IConfiguration>(),
				serviceProvider.GetServices<IConfigureOptions<TOptions>>(),
				serviceProvider.GetServices<IPostConfigureOptions<TOptions>>(),
				serviceProvider.GetServices<IValidateOptions<TOptions>>()));

			return serviceCollection;
		}
	}
}
