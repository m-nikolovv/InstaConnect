using InstaConnect.Common.Infrastructure.Features.Events.Extensions;
using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;

using MassTransit;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Extensions;

internal static class RiderRegistrationConfiguratorExtensions
{
	extension(IRiderRegistrationConfigurator riderConfigurator)
	{
		public IRiderRegistrationConfigurator MapEmailConfirmationTokenEventProducer()
		{
			riderConfigurator
				.MapEventProducer<EmailConfirmationTokenAddedEventRequest>(message => message.EmailConfirmationToken.GetKey())
				.MapEventProducer<EmailConfirmationTokenDeletedEventRequest>(message => message.EmailConfirmationToken.GetKey());

			return riderConfigurator;
		}
	}
}
