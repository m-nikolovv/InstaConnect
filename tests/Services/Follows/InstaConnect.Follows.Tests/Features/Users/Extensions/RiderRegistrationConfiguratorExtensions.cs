using InstaConnect.Common.Infrastructure.Features.Events.Extensions;
using InstaConnect.Common.Infrastructure.Features.Events.Utilities;
using InstaConnect.Identity.Events.Features.Users;

using MassTransit;

namespace InstaConnect.Follows.Tests.Features.Users.Extensions;

public static class RiderRegistrationConfiguratorExtensions
{
	extension(IRiderRegistrationConfigurator riderConfigurator)
	{
		public IRiderRegistrationConfigurator MapUserEventProducer()
		{
			riderConfigurator
				.MapEventProducer<UserAddedEventRequest>(message => CommonEventKeySelectorMessages.GetKey(message.User.Id))
				.MapEventProducer<UserUpdatedEventRequest>(message => CommonEventKeySelectorMessages.GetKey(message.User.Id))
				.MapEventProducer<UserDeletedEventRequest>(message => CommonEventKeySelectorMessages.GetKey(message.User.Id));

			return riderConfigurator;
		}
	}
}
