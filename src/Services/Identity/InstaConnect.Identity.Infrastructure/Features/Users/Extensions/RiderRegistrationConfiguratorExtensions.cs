using InstaConnect.Common.Infrastructure.Features.Events.Extensions;
using InstaConnect.Identity.Events.Features.Users;

using MassTransit;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Extensions;

internal static class RiderRegistrationConfiguratorExtensions
{
	extension(IRiderRegistrationConfigurator riderConfigurator)
	{
		public IRiderRegistrationConfigurator MapUserEventProducer()
		{
			riderConfigurator
				.MapEventProducer<UserAddedEventRequest>(message => message.User.GetKey())
				.MapEventProducer<UserUpdatedEventRequest>(message => message.User.GetKey())
				.MapEventProducer<UserDeletedEventRequest>(message => message.User.GetKey());

			return riderConfigurator;
		}
	}
}
