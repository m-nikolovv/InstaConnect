using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Identity.Application.Features.Users.Abstractions;
using InstaConnect.Identity.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Identity.Application.Tests.Features.Users.Utilities;

public static class UserMapper
{
	extension(User user)
	{
		public UserResponse ToFullResponse()
		{
			return new(user.Id,
					   user.FirstName,
					   user.LastName,
					   user.Email,
					   user.Name,
					   user.ProfileImageUrl,
					   user.CreatedAtUtc,
					   user.UpdatedAtUtc);
		}

		public UserId ToResponse(
			AddUserCommandRequest request)
		{
			return user.ToId();
		}

		public UserId ToResponse(
			UpdateCurrentUserCommandRequest request)
		{
			return user.ToId();
		}

		public UserResponse ToResponse(
			GetUserByIdQueryRequest request)
		{
			return user.ToFullResponse();
		}

		public UserResponse ToResponse(
			GetCurrentUserByIdQueryRequest request)
		{
			return user.ToFullResponse();
		}

		public UserResponse ToResponse(
			GetUserDetailsByIdQueryRequest request)
		{
			return user.ToFullResponse();
		}

		public UserResponse ToResponse(
			GetCurrentUserDetailsByIdQueryRequest request)
		{
			return user.ToFullResponse();
		}
	}

	extension(ICollection<User> users)
	{
		internal UserCollectionResponse ToFullResponse<TRequest>(
		TRequest request,
		Func<TRequest, User, bool> filter,
		Func<TRequest, User, UserResponse> transform)
		where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			var paginator = new Paginator();
			var totalCount = users.Count(user => filter(request, user));

			return new(users.Filter(request, user => filter(request, user), user => transform(request, user)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		public UserCollectionResponse ToResponse(
			GetAllUsersQueryRequest request)
		{
			return users.ToFullResponse(
				request,
				(request, user) => user.MatchesFilter(request),
				(request, user) => user.ToFullResponse());
		}
	}
}
