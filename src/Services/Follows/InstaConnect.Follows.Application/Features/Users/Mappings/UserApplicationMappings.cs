using InstaConnect.Follows.Application.Features.Users.Commands.Add;
using InstaConnect.Follows.Application.Features.Users.Commands.Delete;
using InstaConnect.Follows.Application.Features.Users.Commands.Update;
using InstaConnect.Follows.Domain.Features.Users.Models.Requests;
using InstaConnect.Follows.Domain.Features.Users.Models.Responses;
using InstaConnect.Follows.Domain.Features.Users.Models.ValueObjects;

namespace InstaConnect.Follows.Application.Features.Users.Mappings;

internal class UserApplicationMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<AddUserCommandRequest, AddUserCommand>()
			.ConstructUsing(src => new(
				new(src.Id),
				src.FirstName,
				src.LastName,
				new(src.Name),
				new(src.Email),
				src.ProfileImageUrl == null ? null : new(src.ProfileImageUrl),
				src.CreatedAtUtc,
				src.UpdatedAtUtc));

		config.NewConfig<UserId, AddUserCommandResponse>()
			.ConstructUsing(src => new(src.Adapt<UserIdCommandResponse>(config)));

		config.NewConfig<UpdateUserCommandRequest, UpdateUserCommand>()
			.ConstructUsing(src => new(
				new(src.Id),
				src.FirstName,
				src.LastName,
				new(src.Name),
				new(src.Email),
				src.ProfileImageUrl == null ? null : new(src.ProfileImageUrl),
				src.UpdatedAtUtc));

		config.NewConfig<UserId, UpdateUserCommandResponse>()
			.ConstructUsing(src => new(src.Adapt<UserIdCommandResponse>(config)));

		config.NewConfig<DeleteUserCommandRequest, DeleteUserCommand>()
			.ConstructUsing(src => new(
									   new(src.Id)));

		config.NewConfig<UserId, UserIdCommandResponse>()
			.ConstructUsing(src => new(src.Id));

		config.NewConfig<UserResponse, UserQueryResponse>()
			.ConstructUsing(src => new(
				src.Id.Id,
				src.FirstName,
				src.LastName,
				src.Name.Value,
				src.ProfileImageUrl == null ? null : src.ProfileImageUrl.Value,
				src.CreatedAtUtc,
				src.UpdatedAtUtc));
	}
}
