using InstaConnect.Common.Infrastructure.Features.Seeders.Abstractions;

namespace InstaConnect.Common.Presentation.Features.Seeders.Extensions;

public static class WebApplicationExtensions
{
	extension(WebApplication webApplication)
	{
		public async Task<WebApplication> UseSeedersAsync(CancellationToken cancellationToken)
		{
			await webApplication
				.Services
				.CreateScope()
				.ServiceProvider
				.GetRequiredService<IDatabaseSeeder>()
				.SeedAsync(cancellationToken);

			return webApplication;
		}
	}
}
