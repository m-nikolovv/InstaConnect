using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

namespace InstaConnect.Common.Presentation.Features.Databases.Extensions;

public static class WebApplicationExtensions
{
	extension(WebApplication webApplication)
	{
		public async Task<WebApplication> UseDatabaseInitializerAsync(CancellationToken cancellationToken)
		{
			await webApplication
				.Services
				.CreateScope()
				.ServiceProvider
				.GetRequiredService<IDatabaseInitializer>()
				.InitializeAsync(cancellationToken);

			return webApplication;
		}

		public async Task<WebApplication> UseDatabaseSeederAsync(CancellationToken cancellationToken)
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
