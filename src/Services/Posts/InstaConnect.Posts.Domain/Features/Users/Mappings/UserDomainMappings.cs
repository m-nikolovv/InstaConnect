using InstaConnect.Identity.Events.Features.Users;

using Mapster;

namespace InstaConnect.Posts.Domain.Features.Users.Mappings;

internal class UserDomainMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<User, UserEventRequest>()
			.ConstructUsing(src => new(
				src.Id.Id,
				src.Name.Value,
				src.Email.Value,
				src.FirstName,
				src.LastName,
				src.ProfileImageUrl == null ? null : src.ProfileImageUrl.Value,
				src.CreatedAtUtc,
				src.UpdatedAtUtc));
	}
}
