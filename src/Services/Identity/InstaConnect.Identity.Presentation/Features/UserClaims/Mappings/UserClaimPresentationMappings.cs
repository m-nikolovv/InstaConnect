using InstaConnect.Identity.Application.Features.UserClaims.Commands.Add;
using InstaConnect.Identity.Application.Features.UserClaims.Commands.Delete;
using InstaConnect.Identity.Application.Features.UserClaims.Models;
using InstaConnect.Identity.Application.Features.UserClaims.Queries.GetAll;
using InstaConnect.Identity.Presentation.Features.UserClaims.Models.Requests;
using InstaConnect.Identity.Presentation.Features.UserClaims.Models.Responses;

namespace InstaConnect.Identity.Presentation.Features.UserClaims.Mappings;

internal class UserClaimPresentationMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<GetAllUserClaimsApiRequest, GetAllUserClaimsQueryRequest>()
			.ConstructUsing(src => new(
				src.Id,
				src.CurrentId,
				src.SortOrder,
				src.SortTerm,
				src.Page,
				src.PageSize));

		config.NewConfig<GetAllUserClaimsQueryResponse, GetAllUserClaimsApiResponse>()
			.ConstructUsing(src => new(src.Response.Adapt<UserClaimCollectionApiResponse>(config)));

		config.NewConfig<AddUserClaimApiRequest, AddUserClaimCommandRequest>()
			.ConstructUsing(src => new(
				src.Id,
				src.Body.Claim));

		config.NewConfig<AddUserClaimCommandResponse, AddUserClaimApiResponse>()
			.ConstructUsing(src => new(src.Response.Adapt<UserClaimIdApiResponse>(config)));

		config.NewConfig<DeleteUserClaimApiRequest, DeleteUserClaimCommandRequest>()
			.ConstructUsing(src => new(src.Id, src.Claim));

		config.NewConfig<UserClaimIdCommandResponse, UserClaimIdApiResponse>()
			.ConstructUsing(src => new(src.Id, src.Claim));

		config.NewConfig<UserClaimQueryResponse, UserClaimApiResponse>()
			.ConstructUsing(src => new(
				  src.Id,
				  src.Claim,
				  src.User.Adapt<UserApiResponse>(config),
				  src.CreatedAtUtc));

		config.NewConfig<UserClaimCollectionQueryResponse, UserClaimCollectionApiResponse>()
			.ConstructUsing(src => new(
				  src.User.Adapt<UserApiResponse>(config),
				  src.UserClaims.Adapt<ICollection<UserClaimApiResponse>>(config),
				  src.Page,
				  src.PageSize,
				  src.TotalCount,
				  src.HasNextPage,
				  src.HasPreviousPage));
	}
}
