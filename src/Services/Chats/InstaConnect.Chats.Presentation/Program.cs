using InstaConnect.Chats.Application.Features.Common.Extensions;
using InstaConnect.Chats.Domain.Features.Common.Extensions;
using InstaConnect.Chats.Infrastructure.Features.Common.Extensions;
using InstaConnect.Chats.Presentation.Features.Common.Extensions;
using InstaConnect.Common.Infrastructure.Features.Telemetries.Extensions;
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

await app
	.UsePresentation()
	.RunPresentationAsync(CancellationToken.None);


// Utils for testing
public partial class Program
{
	private Program()
	{
	}
}
