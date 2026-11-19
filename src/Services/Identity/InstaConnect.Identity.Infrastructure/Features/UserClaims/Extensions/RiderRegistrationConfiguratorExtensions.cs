using InstaConnect.Common.Infrastructure.Features.Events.Extensions;
using InstaConnect.Identity.Events.Features.UserClaims;

using MassTransit;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Extensions;

internal static class RiderRegistrationConfiguratorExtensions
{
	extension(IRiderRegistrationConfigurator riderConfigurator)
	{
		public IRiderRegistrationConfigurator MapUserClaimEventProducer()
		{
			riderConfigurator
				.MapEventProducer<UserClaimAddedEventRequest>(message => message.UserClaim.GetKey())
				.MapEventProducer<UserClaimDeletedEventRequest>(message => message.UserClaim.GetKey());

			return riderConfigurator;
		}
	}
}
