using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Identity.Events.Features.UserClaims;

namespace InstaConnect.Identity.Domain.Features.UserClaims.Mappings;

internal class UserClaimDomainMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<UserClaim, UserClaimAddedEventRequest>()
			.ConstructUsing(src => new(src.Adapt<UserClaimEventRequest>(config)));

		config.NewConfig<UserClaim, UserClaimDeletedEventRequest>()
			.ConstructUsing(src => new(src.Adapt<UserClaimEventRequest>(config)));

		config.NewConfig<UserClaim, UserClaimEventRequest>()
			.ConstructUsing(src => new(
				src.Id.Id.Id,
				src.Id.Claim.GetName(),
				src.User.Adapt<UserEventRequest>(config)!,
				src.CreatedAtUtc));
	}
}
