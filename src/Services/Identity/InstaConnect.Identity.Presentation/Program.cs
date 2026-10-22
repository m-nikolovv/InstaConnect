using InstaConnect.Common.Infrastructure.Features.Telemetries.Extensions;
using InstaConnect.Common.Presentation.Features.Seeders.Extensions;
using InstaConnect.Common.Presentation.Features.Telemetries.Extensions;
using InstaConnect.Identity.Application.Features.Common.Extensions;
using InstaConnect.Identity.Domain.Features.Common.Extensions;
using InstaConnect.Identity.Infrastructure.Features.Common.Extensions;
using InstaConnect.Identity.Presentation.Features.Common.Extensions;

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

await app.UseSeedersAsync(CancellationToken.None);

await app.WaitForShutdownAsync();


// Utils for testing
public partial class Program
{
	private Program()
	{
	}
}
