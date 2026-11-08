using InstaConnect.Common.Infrastructure.Features.Telemetries.Extensions;
using InstaConnect.Common.Presentation.Features.Telemetries.Extensions;
using InstaConnect.Follows.Application.Features.Common.Extensions;
using InstaConnect.Follows.Domain.Features.Common.Extensions;
using InstaConnect.Follows.Infrastructure.Features.Common.Extensions;
using InstaConnect.Follows.Presentation.Features.Common.Extensions;

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
