using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Identity.Application.Features.UserClaims.Commands.Add;
using InstaConnect.Identity.Application.Features.UserClaims.Models;
using InstaConnect.Identity.Application.Features.UserClaims.Queries.GetAll;
using InstaConnect.Identity.Presentation.Features.Users.Abstractions;

namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Utilities;

public static class UserClaimMapper
{
	extension(UserClaim userClaim)
	{
		internal UserClaimIdCommandResponse ToIdCommandResponse(
)
		{
			return new(userClaim.Id.Id.Id, userClaim.Id.Claim);
		}

		internal UserClaimQueryResponse ToFullQueryResponse()
		{
			return new(userClaim.Id.Id.Id,
					   userClaim.Id.Claim,
					   userClaim.User?.ToFullQueryResponse(),
					   userClaim.CreatedAtUtc);
		}

		internal UserClaimQueryResponse ToQueryResponseWithoutUser()
		{
			return new(userClaim.Id.Id.Id,
					   userClaim.Id.Claim,
					   null,
					   userClaim.CreatedAtUtc);
		}

		public AddUserClaimCommandResponse ToResponse(
			AddUserClaimApiRequest request)
		{
			return new(userClaim.ToIdCommandResponse());
		}
	}

	extension(ICollection<UserClaim> userClaims)
	{
		internal UserClaimCollectionQueryResponse ToFullQueryResponse<TRequest>(
			 TRequest request,
			 User user,
			 Func<TRequest, UserClaim, bool> filter,
			 Func<TRequest, UserClaim, UserClaimQueryResponse> transform)
		where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			var paginator = new Paginator();
			var totalCount = userClaims.Count(userClaim => filter(request, userClaim));

			return new(user.ToFullQueryResponse(),
					   userClaims.Filter(request, userClaim => filter(request, userClaim), userClaim => transform(request, userClaim)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		internal UserClaimCollectionQueryResponse ToQueryResponseWithoutUser<TRequest>(
			 TRequest request,
			 Func<TRequest, UserClaim, bool> filter,
			 Func<TRequest, UserClaim, UserClaimQueryResponse> transform)
		where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			var paginator = new Paginator();
			var totalCount = userClaims.Count(userClaim => filter(request, userClaim));

			return new(null,
					   userClaims.Filter(request, userClaim => filter(request, userClaim), userClaim => transform(request, userClaim)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		public GetAllUserClaimsQueryResponse ToResponse(
			GetAllUserClaimsApiRequest request,
			User user)
		{
			return new(userClaims.ToFullQueryResponse(
				request,
				user,
				(request, userClaim) => userClaim.MatchesFilter(request),
				(request, userClaim) => userClaim.ToQueryResponseWithoutUser()));
		}
	}
}
