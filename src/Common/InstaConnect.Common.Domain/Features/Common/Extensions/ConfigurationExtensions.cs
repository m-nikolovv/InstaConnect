using Microsoft.Extensions.Configuration;

namespace InstaConnect.Common.Domain.Features.Common.Extensions;

public static class ConfigurationExtensions
{
	extension(IConfiguration configuration)
	{
		public TOptions GetOptions<TOptions>(string sectionName)
			where TOptions : class, IApplicationOptions
		{
			return configuration
						.GetSection(sectionName)
						.Get<TOptions>()!;
		}
	}
}
