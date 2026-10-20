using InstaConnect.Identity.Application.Features.Users.Commands.Add;
using InstaConnect.Identity.Application.Features.Users.Commands.Delete;
using InstaConnect.Identity.Application.Features.Users.Commands.DeleteCurrent;
using InstaConnect.Identity.Application.Features.Users.Commands.UpdateCurrent;
using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Application.Features.Users.Queries.GetAll;
using InstaConnect.Identity.Application.Features.Users.Queries.GetById;
using InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentById;
using InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentDetailsById;
using InstaConnect.Identity.Application.Features.Users.Queries.GetDetailsById;
using InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

namespace InstaConnect.Identity.Presentation.Features.Users.Mappings;

internal class UserPresentationMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<GetAllUsersApiRequest, GetAllUsersQueryRequest>()
			.ConstructUsing(src => new(
				src.FirstName,
				src.LastName,
				src.Name,
				src.CurrentId,
				src.SortOrder,
				src.SortTerm,
				src.Page,
				src.PageSize));

		config.NewConfig<GetAllUsersQueryResponse, GetAllUsersApiResponse>()
			.ConstructUsing(src => new(src.Response.Adapt<UserCollectionApiResponse>(config)));

		config.NewConfig<GetUserByIdApiRequest, GetUserByIdQueryRequest>()
			.ConstructUsing(src => new(src.Id, src.CurrentId));

		config.NewConfig<GetUserByIdQueryResponse, GetUserByIdApiResponse>()
			.ConstructUsing(src => new(src.Response.Adapt<UserApiResponse>(config)));

		config.NewConfig<GetCurrentUserByIdApiRequest, GetCurrentUserByIdQueryRequest>()
			.ConstructUsing(src => new(src.CurrentId));

		config.NewConfig<GetCurrentUserByIdQueryResponse, GetCurrentUserByIdApiResponse>()
			.ConstructUsing(src => new(src.Response.Adapt<UserApiResponse>(config)));

		config.NewConfig<GetUserDetailsByIdApiRequest, GetUserDetailsByIdQueryRequest>()
			.ConstructUsing(src => new(src.Id, src.CurrentId));

		config.NewConfig<GetUserDetailsByIdQueryResponse, GetUserDetailsByIdApiResponse>()
			.ConstructUsing(src => new(src.Response.Adapt<UserDetailsApiResponse>(config)));

		config.NewConfig<GetCurrentUserDetailsByIdQueryResponse, GetCurrentUserDetailsByIdApiResponse>()
			.ConstructUsing(src => new(src.Response.Adapt<UserDetailsApiResponse>(config)));

		config.NewConfig<AddUserApiRequest, AddUserCommandRequest>()
			.ConstructUsing(src => new(
				src.Form.Name,
				src.Form.Email,
				src.Form.Password,
				src.Form.ConfirmPassword,
				src.Form.FirstName,
				src.Form.LastName,
				src.Form.ProfileImage));

		config.NewConfig<AddUserCommandResponse, AddUserApiResponse>()
			.ConstructUsing(src => new(src.Response.Adapt<UserIdApiResponse>(config)));

		config.NewConfig<UpdateCurrentUserApiRequest, UpdateCurrentUserCommandRequest>()
			.ConstructUsing(src => new(
				src.Id,
				src.Form.Email,
				src.Form.FirstName,
				src.Form.LastName,
				src.Form.Name,
				src.Form.ProfileImage));

		config.NewConfig<UpdateCurrentUserCommandResponse, UpdateCurrentUserApiResponse>()
			.ConstructUsing(src => new(src.Response.Adapt<UserIdApiResponse>(config)));

		config.NewConfig<DeleteUserApiRequest, DeleteUserCommandRequest>()
			.ConstructUsing(src => new(src.Id));

		config.NewConfig<DeleteCurrentUserApiRequest, DeleteCurrentUserCommandRequest>()
			.ConstructUsing(src => new(src.CurrentId));

		config.NewConfig<UserIdCommandResponse, UserIdApiResponse>()
			.ConstructUsing(src => new(src.Id));

		config.NewConfig<UserQueryResponse, UserApiResponse>()
			.ConstructUsing(src => new(
				  src.Id,
				  src.FirstName,
				  src.LastName,
				  src.Name,
				  src.ProfileImageUrl,
				  src.CreatedAtUtc,
				  src.UpdatedAtUtc));

		config.NewConfig<UserCollectionQueryResponse, UserCollectionApiResponse>()
			.ConstructUsing(src => new(
				  src.Users.Adapt<ICollection<UserApiResponse>>(config),
				  src.Page,
				  src.PageSize,
				  src.TotalCount,
				  src.HasNextPage,
				  src.HasPreviousPage));
	}
}
