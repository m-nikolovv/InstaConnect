using InstaConnect.Common.Domain.Features.Common.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Events.Models;

namespace InstaConnect.Follows.Infrastructure.Features.Users.Models.Options;

public record UserEventHandlerOptions(
	IDictionary<string, KafkaConsumerOptions> Consumers) : IApplicationOptions
{
	public const string SectionName = "UserEventHandlerConfiguration";
}
