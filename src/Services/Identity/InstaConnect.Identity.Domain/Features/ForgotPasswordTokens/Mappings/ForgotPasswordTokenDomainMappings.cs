using InstaConnect.Identity.Events.Features.ForgotPasswordTokens;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Mappings;

internal class ForgotPasswordTokenDomainMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<ForgotPasswordToken, ForgotPasswordTokenAddedEventRequest>()
			.ConstructUsing(src => new(src.Adapt<ForgotPasswordTokenEventRequest>(config)));

		config.NewConfig<ForgotPasswordToken, ForgotPasswordTokenDeletedEventRequest>()
			.ConstructUsing(src => new(src.Adapt<ForgotPasswordTokenEventRequest>(config)));

		config.NewConfig<User, ICollection<ForgotPasswordTokenDeletedEventRequest>>()
			.ConstructUsing(src =>
				src.ForgotPasswordTokens
					.Select(emt => emt
						.AddUser(src)
						.Adapt<ForgotPasswordTokenDeletedEventRequest>(config))
					.ToList());

		config.NewConfig<ForgotPasswordToken, ForgotPasswordTokenEventRequest>()
			.ConstructUsing(src => new(
				src.Id.Id.Id,
				src.Id.Value,
				src.User.Adapt<UserEventRequest>(config)!,
				src.ExpiresAtUtc,
				src.CreatedAtUtc));
	}
}
