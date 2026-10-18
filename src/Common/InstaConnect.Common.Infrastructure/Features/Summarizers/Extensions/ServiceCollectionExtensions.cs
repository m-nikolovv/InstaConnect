using Anthropic;

using InstaConnect.Common.Infrastructure.Features.Summarizers.Models;

using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Infrastructure.Features.Summarizers.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddSummarizers(IConfiguration configuration)
		{
			serviceCollection.AddValidatedOptions<AnthropicOptions>(AnthropicOptions.SectionName);
			var options = configuration.GetOptions<AnthropicOptions>(AnthropicOptions.SectionName);

			serviceCollection.AddChatClient(new AnthropicClient { ApiKey = options.ApiKey }
				.AsIChatClient(options.Model));

			return serviceCollection;
		}
	}
}
