using InstaConnect.Chats.Application.Features.Common.Extensions;
using InstaConnect.Chats.Domain.Features.Common.Extensions;
using InstaConnect.Chats.Infrastructure.Features.Common.Extensions;
using InstaConnect.Chats.Presentation.Features.Common.Extensions;
using InstaConnect.Common.Infrastructure.Features.Telemetries.Extensions;
using InstaConnect.Common.Presentation.Features.Databases.Extensions;
using InstaConnect.Common.Presentation.Features.Telemetries.Extensions;

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

await app.UseDatabaseInitializerAsync(CancellationToken.None);

await app.StartAsync();

await app.UseDatabaseSeederAsync(CancellationToken.None);

await app.WaitForShutdownAsync();


// Utils for testing
public partial class Program
{
	private Program()
	{
	}
}
