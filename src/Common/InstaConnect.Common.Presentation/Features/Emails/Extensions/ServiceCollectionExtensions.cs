using System.Reflection;

using InstaConnect.Common.Presentation.Features.Emails.Abstractions;
using InstaConnect.Common.Presentation.Features.Emails.Helpers;

using RazorLight;

namespace InstaConnect.Common.Presentation.Features.Emails.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddEmailRenderers(Assembly templateAssembly, string rootNamespace)
		{
			serviceCollection.AddSingleton<IRazorLightEngine>(_ =>
				new RazorLightEngineBuilder()
					.UseEmbeddedResourcesProject(templateAssembly, rootNamespace)
					.UseMemoryCachingProvider()
					.Build());

			serviceCollection.AddScoped<IRazorEmailRenderer, RazorEmailRenderer>();

			return serviceCollection;
		}
	}
}
