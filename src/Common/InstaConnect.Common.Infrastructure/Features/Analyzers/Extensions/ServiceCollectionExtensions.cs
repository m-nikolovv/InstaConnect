using InstaConnect.Common.Infrastructure.Features.Analyzers.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Analyzers.Helpers;
using InstaConnect.Common.Infrastructure.Features.Analyzers.Models;

using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using OpenAI;

namespace InstaConnect.Common.Infrastructure.Features.Analyzers.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddAnalyzers(IConfiguration configuration)
		{
			serviceCollection.AddValidatedOptions<OpenAiOptions>(OpenAiOptions.SectionName);
			var options = configuration.GetOptions<OpenAiOptions>(OpenAiOptions.SectionName);

			serviceCollection.AddChatClient(new OpenAIClient(options.ApiKey)
				.GetChatClient(options.Model)
				.AsIChatClient());

			serviceCollection.AddScoped<IAnalyzer, Analyzer>();

			return serviceCollection;
		}
	}
}
