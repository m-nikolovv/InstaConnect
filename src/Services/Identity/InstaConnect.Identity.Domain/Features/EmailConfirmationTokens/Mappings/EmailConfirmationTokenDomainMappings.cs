using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Mappings;

internal class EmailConfirmationTokenDomainMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<EmailConfirmationToken, EmailConfirmationTokenAddedEventRequest>()
			.ConstructUsing(src => new(src.Adapt<EmailConfirmationTokenEventRequest>(config)));

		config.NewConfig<EmailConfirmationToken, EmailConfirmationTokenDeletedEventRequest>()
			.ConstructUsing(src => new(src.Adapt<EmailConfirmationTokenEventRequest>(config)));

		config.NewConfig<User, ICollection<EmailConfirmationTokenDeletedEventRequest>>()
			.ConstructUsing(src =>
				src.EmailConfirmationTokens
					.Select(emt => emt
						.AddUser(src)
						.Adapt<EmailConfirmationTokenDeletedEventRequest>(config))
					.ToList());

		config.NewConfig<EmailConfirmationToken, EmailConfirmationTokenEventRequest>()
			.ConstructUsing(src => new(
				src.Id.Id.Id,
				src.Id.Value,
				src.User.Adapt<UserEventRequest>(config)!,
				src.ExpiresAtUtc,
				src.CreatedAtUtc));
	}
}
