using InstaConnect.Common.Infrastructure.Features.Events.Extensions;
using InstaConnect.Common.Infrastructure.Features.Events.Utilities;
using InstaConnect.Identity.Events.Features.Users;

using MassTransit;

namespace InstaConnect.Posts.Tests.Features.Users.Extensions;

public static class RiderRegistrationConfiguratorExtensions
{
	extension(IRiderRegistrationConfigurator riderConfigurator)
	{
		public IRiderRegistrationConfigurator MapUserEventProducer()
		{
			riderConfigurator
				.MapEventProducer<UserAddedEventRequest>(context => CommonEventKeySelectorMessages.GetKey(context.Message.User.Id))
				.MapEventProducer<UserUpdatedEventRequest>(context => CommonEventKeySelectorMessages.GetKey(context.Message.User.Id))
				.MapEventProducer<UserDeletedEventRequest>(context => CommonEventKeySelectorMessages.GetKey(context.Message.User.Id));

			return riderConfigurator;
		}
	}
}
