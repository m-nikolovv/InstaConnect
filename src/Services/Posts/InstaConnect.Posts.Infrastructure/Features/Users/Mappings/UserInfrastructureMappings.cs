using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Posts.Application.Features.Users.Commands.Add;
using InstaConnect.Posts.Application.Features.Users.Commands.Delete;
using InstaConnect.Posts.Application.Features.Users.Commands.Update;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Mappings;

internal class UserInfrastructureMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<UserAddedEventRequest, AddUserCommandRequest>()
			.ConstructUsing(src => new(
				src.User.Id,
				src.User.FirstName,
				src.User.LastName,
				src.User.Name,
				src.User.Email,
				src.User.ProfileImageUrl,
				src.User.CreatedAtUtc,
				src.User.UpdatedAtUtc));

		config.NewConfig<UserUpdatedEventRequest, UpdateUserCommandRequest>()
			.ConstructUsing(src => new(
				src.User.Id,
				src.User.FirstName,
				src.User.LastName,
				src.User.Name,
				src.User.Email,
				src.User.ProfileImageUrl,
				src.User.UpdatedAtUtc));

		config.NewConfig<UserDeletedEventRequest, DeleteUserCommandRequest>()
			.ConstructUsing(src => new(src.User.Id));
	}
}
