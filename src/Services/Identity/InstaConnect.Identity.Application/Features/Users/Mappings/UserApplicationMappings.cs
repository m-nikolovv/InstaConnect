using InstaConnect.Identity.Application.Features.Users.Commands.Add;
using InstaConnect.Identity.Application.Features.Users.Commands.Delete;
using InstaConnect.Identity.Application.Features.Users.Commands.DeleteCurrent;
using InstaConnect.Identity.Application.Features.Users.Commands.UpdateCurrent;
using InstaConnect.Identity.Application.Features.Users.Queries.GetAll;
using InstaConnect.Identity.Application.Features.Users.Queries.GetById;
using InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentById;
using InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentDetailsById;
using InstaConnect.Identity.Application.Features.Users.Queries.GetDetailsById;

using Mapster;

namespace InstaConnect.Identity.Application.Features.Users.Mappings;

public class UserApplicationMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<GetAllUsersQueryRequest, GetAllUsersQuery>()
			.ConstructUsing(src => new(
									   new(src.FirstName,
										   src.LastName,
										   new(src.Name)),
									   new(
										   src.SortOrder,
										   src.SortTerm),
									   new(
										   src.Page,
										   src.PageSize),
									   new(
										   new(src.CurrentId))));

		config.NewConfig<UserCollectionResponse, GetAllUsersQueryResponse>()
			.ConstructUsing(src => new(src.Adapt<UserCollectionQueryResponse>(config)));

		config.NewConfig<GetUserByIdQueryRequest, GetUserByIdQuery>()
			.ConstructUsing(src => new(
									   new(src.Id),
									   new(
										   new(src.CurrentId))));

		config.NewConfig<UserResponse, GetUserByIdQueryResponse>()
			.ConstructUsing(src => new(src.Adapt<UserQueryResponse>(config)));

		config.NewConfig<GetCurrentUserByIdQueryRequest, GetUserByIdQuery>()
			.ConstructUsing(src => new(
									   new(src.CurrentId),
									   new(
										   new(src.CurrentId))));

		config.NewConfig<UserResponse, GetCurrentUserByIdQueryResponse>()
			.ConstructUsing(src => new(src.Adapt<UserQueryResponse>(config)));

		config.NewConfig<GetUserDetailsByIdQueryRequest, GetUserByIdQuery>()
			.ConstructUsing(src => new(
									   new(src.Id),
									   new(
										   new(src.CurrentId))));

		config.NewConfig<UserResponse, GetUserDetailsByIdQueryResponse>()
			.ConstructUsing(src => new(src.Adapt<UserDetailsQueryResponse>(config)));

		config.NewConfig<GetCurrentUserDetailsByIdQueryRequest, GetUserByIdQuery>()
			.ConstructUsing(src => new(
									   new(src.CurrentId),
									   new(
										   new(src.CurrentId))));

		config.NewConfig<UserResponse, GetCurrentUserDetailsByIdQueryResponse>()
			.ConstructUsing(src => new(src.Adapt<UserDetailsQueryResponse>(config)));

		config.NewConfig<AddUserCommandRequest, AddUserCommand>()
			.ConstructUsing(src => new(
				new(src.Name),
				new(src.Email),
				src.Password,
				src.ConfirmPassword,
				src.FirstName,
				src.LastName,
				src.ProfileImage));

		config.NewConfig<UserId, AddUserCommandResponse>()
			.ConstructUsing(src => new(src.Adapt<UserIdCommandResponse>(config)));

		config.NewConfig<UpdateCurrentUserCommandRequest, UpdateUserCommand>()
			.ConstructUsing(src => new(
				new(src.Id),
				new(src.Email),
				src.FirstName,
				src.LastName,
				new(src.Name),
				src.ProfileImage));

		config.NewConfig<UserId, UpdateCurrentUserCommandResponse>()
			.ConstructUsing(src => new(src.Adapt<UserIdCommandResponse>(config)));

		config.NewConfig<DeleteUserCommandRequest, DeleteUserCommand>()
			.ConstructUsing(src => new(
									   new(src.Id)));

		config.NewConfig<DeleteCurrentUserCommandRequest, DeleteUserCommand>()
			.ConstructUsing(src => new(
									   new(src.CurrentId)));

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

		config.NewConfig<UserResponse, UserDetailsQueryResponse>()
			.ConstructUsing(src => new(
				  src.Id.Id,
				  src.FirstName,
				  src.LastName,
				  src.Name.Value,
				  src.Email.Value,
				  src.ProfileImageUrl == null ? null : src.ProfileImageUrl.Value,
				  src.CreatedAtUtc,
				  src.UpdatedAtUtc));

		config.NewConfig<UserCollectionResponse, UserCollectionQueryResponse>()
			.ConstructUsing(src => new(
				  src.Users.Adapt<ICollection<UserQueryResponse>>(config),
				  src.Page,
				  src.PageSize,
				  src.TotalCount,
				  src.HasNextPage,
				  src.HasPreviousPage));
	}
}
