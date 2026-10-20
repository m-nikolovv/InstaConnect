using InstaConnect.Follows.Application.Features.Users.Models;
using InstaConnect.Follows.Presentation.Features.Users.Models.Responses;

namespace InstaConnect.Follows.Presentation.Features.Users.Mappings;

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
