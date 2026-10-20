using InstaConnect.Identity.Application.Features.UserClaims.Commands.Add;
using InstaConnect.Identity.Application.Features.UserClaims.Commands.Delete;
using InstaConnect.Identity.Application.Features.UserClaims.Models;
using InstaConnect.Identity.Application.Features.UserClaims.Queries.GetAll;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Responses;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.ValueObjects;

namespace InstaConnect.Identity.Application.Features.UserClaims.Mappings;

public class UserClaimApplicationMappings : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<GetAllUserClaimsQueryRequest, GetAllUserClaimsQuery>()
			.ConstructUsing(src => new(
									   new(
										   new(src.Id)),
									   new(
										   src.SortOrder,
										   src.SortTerm),
									   new(
										   src.Page,
										   src.PageSize),
									   new(
										   new(src.CurrentId))));

		config.NewConfig<UserClaimCollectionResponse, GetAllUserClaimsQueryResponse>()
			.ConstructUsing(src => new(src.Adapt<UserClaimCollectionQueryResponse>(config)));

		config.NewConfig<UserClaimCollectionResponse, UserClaimCollectionQueryResponse>()
			.ConstructUsing(src => new(
				  src.User.Adapt<UserQueryResponse>(config),
				  src.UserClaims.Adapt<ICollection<UserClaimQueryResponse>>(config),
				  src.Page,
				  src.PageSize,
				  src.TotalCount,
				  src.HasNextPage,
				  src.HasPreviousPage));

		config.NewConfig<AddUserClaimCommandRequest, AddUserClaimCommand>()
			.ConstructUsing(src => new(
				new(src.Id),
				src.Claim));

		config.NewConfig<UserClaimId, AddUserClaimCommandResponse>()
			.ConstructUsing(src => new(src.Adapt<UserClaimIdCommandResponse>(config)));

		config.NewConfig<DeleteUserClaimCommandRequest, DeleteUserClaimCommand>()
			.ConstructUsing(src => new(
									   new(
										   new(src.Id),
										   src.Claim)));

		config.NewConfig<UserClaimId, UserClaimIdCommandResponse>()
			.ConstructUsing(src => new(src.Id.Id, src.Claim));

		config.NewConfig<UserClaimResponse, UserClaimQueryResponse>()
			.ConstructUsing(src => new(
					src.Id.Id.Id,
					src.Id.Claim,
					src.User.Adapt<UserQueryResponse>(),
					src.CreatedAtUtc));
	}
}
