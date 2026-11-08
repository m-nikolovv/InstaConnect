using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

using Microsoft.Extensions.Hosting;

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

		public async Task InitializeAndRunAsync(CancellationToken cancellationToken)
		{
			await webApplication.UseDatabaseInitializerAsync(cancellationToken);

			await webApplication.StartAsync(cancellationToken);

			await webApplication.UseDatabaseSeederAsync(cancellationToken);

			await webApplication.WaitForShutdownAsync(cancellationToken);
		}
	}
}
