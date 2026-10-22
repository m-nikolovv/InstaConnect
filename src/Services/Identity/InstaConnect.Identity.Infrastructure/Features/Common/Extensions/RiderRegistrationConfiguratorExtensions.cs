using InstaConnect.Common.Infrastructure.Features.Events.Extensions;
using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;
using InstaConnect.Identity.Events.Features.ForgotPasswordTokens;
using InstaConnect.Identity.Events.Features.UserClaims;
using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.UserClaims.Extensions;

using MassTransit;

namespace InstaConnect.Identity.Infrastructure.Features.Common.Extensions;

public static class RiderRegistrationConfiguratorExtensions
{
	extension(IRiderRegistrationConfigurator riderConfigurator)
	{
		public IRiderRegistrationConfigurator MapUserEventProducer()
		{
			riderConfigurator
				.MapEventProducer<UserAddedEventRequest>(context => context.Message.User.GetKey())
				.MapEventProducer<UserUpdatedEventRequest>(context => context.Message.User.GetKey())
				.MapEventProducer<UserDeletedEventRequest>(context => context.Message.User.GetKey());

			return riderConfigurator;
		}

		public IRiderRegistrationConfigurator MapUserClaimEventProducer()
		{
			riderConfigurator
				.MapEventProducer<UserClaimAddedEventRequest>(context => context.Message.UserClaim.GetKey())
				.MapEventProducer<UserClaimDeletedEventRequest>(context => context.Message.UserClaim.GetKey());

			return riderConfigurator;
		}

		public IRiderRegistrationConfigurator MapEmailConfirmationTokenEventProducer()
		{
			riderConfigurator
				.MapEventProducer<EmailConfirmationTokenAddedEventRequest>(context => context.Message.EmailConfirmationToken.GetKey())
				.MapEventProducer<EmailConfirmationTokenDeletedEventRequest>(context => context.Message.EmailConfirmationToken.GetKey());

			return riderConfigurator;
		}

		public IRiderRegistrationConfigurator MapForgotPasswordTokenEventProducer()
		{
			riderConfigurator
				.MapEventProducer<ForgotPasswordTokenAddedEventRequest>(context => context.Message.ForgotPasswordToken.GetKey())
				.MapEventProducer<ForgotPasswordTokenDeletedEventRequest>(context => context.Message.ForgotPasswordToken.GetKey());

			return riderConfigurator;
		}
	}
}
