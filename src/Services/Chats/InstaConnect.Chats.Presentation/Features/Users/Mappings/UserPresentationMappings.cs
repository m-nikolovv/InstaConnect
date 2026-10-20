using InstaConnect.Chats.Application.Features.Users.Models;

namespace InstaConnect.Chats.Presentation.Features.Users.Mappings;

internal class UserPresentationMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<UserQueryResponse, UserApiResponse>()
			.ConstructUsing(src => new(
				src.Id,
				src.FirstName,
				src.LastName,
				src.Name,
				src.ProfileImageUrl,
				src.CreatedAtUtc,
				src.UpdatedAtUtc));
	}
}
