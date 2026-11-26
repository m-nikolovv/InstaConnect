using InstaConnect.Common.Infrastructure.Features.Events.Extensions;
using InstaConnect.Identity.Events.Features.ForgotPasswordTokens;

using MassTransit;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;

internal static class RiderRegistrationConfiguratorExtensions
{
	extension(IRiderRegistrationConfigurator riderConfigurator)
	{
		public IRiderRegistrationConfigurator MapForgotPasswordTokenEventProducer()
		{
			riderConfigurator
				.MapEventProducer<ForgotPasswordTokenAddedEventRequest>(message => message.ForgotPasswordToken.GetKey())
				.MapEventProducer<ForgotPasswordTokenDeletedEventRequest>(message => message.ForgotPasswordToken.GetKey());

			return riderConfigurator;
		}
	}
}
