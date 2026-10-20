using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Identity.Application.Features.Users.Abstractions;
using InstaConnect.Identity.Application.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Responses;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.ValueObjects;

namespace InstaConnect.Identity.Application.Tests.Features.UserClaims.Utilities;

public static class UserClaimMapper
{
	extension(UserClaim userClaim)
	{
		internal UserClaimResponse ToFullResponse()
		{
			return new(userClaim.Id,
					   userClaim.User?.ToFullResponse(),
					   userClaim.CreatedAtUtc);
		}

		internal UserClaimResponse ToResponseWithoutUser()
		{
			return new(userClaim.Id,
					   null,
					   userClaim.CreatedAtUtc);
		}

		public UserClaimId ToResponse(
			AddUserClaimCommandRequest request)
		{
			return userClaim.ToId();
		}
	}

	extension(ICollection<UserClaim> userClaims)
	{
		internal UserClaimCollectionResponse ToFullResponse<TRequest>(
			 TRequest request,
			 User user,
			 Func<TRequest, UserClaim, bool> filter,
			 Func<TRequest, UserClaim, UserClaimResponse> transform)
		where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			var paginator = new Paginator();
			var totalCount = userClaims.Count(userClaim => filter(request, userClaim));

			return new(user.ToFullResponse(),
					   userClaims.Filter(request, userClaim => filter(request, userClaim), userClaim => transform(request, userClaim)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		internal UserClaimCollectionResponse ToResponseWithoutUser<TRequest>(
			 TRequest request,
			 Func<TRequest, UserClaim, bool> filter,
			 Func<TRequest, UserClaim, UserClaimResponse> transform)
		where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
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

		public UserClaimCollectionResponse ToResponse(
			GetAllUserClaimsQueryRequest request,
			User user)
		{
			return userClaims.ToFullResponse(
				request,
				user,
				(request, userClaim) => userClaim.MatchesFilter(request),
				(request, userClaim) => userClaim.ToResponseWithoutUser());
		}
	}
}
