using InstaConnect.Common.Infrastructure.Features.Telemetries.Extensions;
using InstaConnect.Common.Presentation.Features.Databases.Extensions;
using InstaConnect.Common.Presentation.Features.Telemetries.Extensions;
using InstaConnect.Posts.Application.Features.Common.Extensions;
using InstaConnect.Posts.Domain.Features.Common.Extensions;
using InstaConnect.Posts.Infrastructure.Features.Common.Extensions;
using InstaConnect.Posts.Presentation.Features.Common.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
	.AddDomain()
	.AddApplication()
	.AddInfrastructure(builder.Configuration, builder.Environment)
	.AddPresentation(builder.Configuration);

builder.Host.UseTelemetries();

builder.Logging.AddTelemetries(builder.Configuration, builder.Environment);

var app = builder.Build();

app.UsePresentation();

await app.StartAsync();

await app.UseDatabaseInitializerAsync(CancellationToken.None);

await app.WaitForShutdownAsync();


// Utils for testing
public partial class Program
{
	private Program()
	{
	}
}
