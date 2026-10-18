using InstaConnect.Common.Infrastructure.Features.Summarizers.Models;

using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using OpenAI;

namespace InstaConnect.Common.Infrastructure.Features.Summarizers.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddSummarizers(IConfiguration configuration)
		{
			serviceCollection.AddValidatedOptions<OpenAiOptions>(OpenAiOptions.SectionName);
			var options = configuration.GetOptions<OpenAiOptions>(OpenAiOptions.SectionName);

			serviceCollection.AddChatClient(new OpenAIClient(options.ApiKey)
				.GetChatClient(options.Model)
				.AsIChatClient());

			return serviceCollection;
		}
	}
}
