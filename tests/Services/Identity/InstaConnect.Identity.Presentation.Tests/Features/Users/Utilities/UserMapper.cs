using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Common.Presentation.Features.Requests.Abstractions;
using InstaConnect.Identity.Application.Features.Users.Commands.Add;
using InstaConnect.Identity.Application.Features.Users.Commands.UpdateCurrent;
using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Application.Features.Users.Queries.GetAll;
using InstaConnect.Identity.Application.Features.Users.Queries.GetById;
using InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentById;
using InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentDetailsById;
using InstaConnect.Identity.Application.Features.Users.Queries.GetDetailsById;
using InstaConnect.Identity.Presentation.Features.Users.Abstractions;

namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

public static class UserMapper
{
	extension(User user)
	{
		internal UserIdCommandResponse ToIdCommandResponse(
)
		{
			return new(user.Id.Id);
		}

		internal UserQueryResponse ToFullQueryResponse()
		{
			return new(user.Id.Id,
					   user.FirstName,
					   user.LastName,
					   user.Name.Value,
					   user.ProfileImageUrl?.Value,
					   user.CreatedAtUtc,
					   user.UpdatedAtUtc);
		}

		internal UserDetailsQueryResponse ToFullQueryDetailsResponse()
		{
			return new(user.Id.Id,
					   user.FirstName,
					   user.LastName,
					   user.Name.Value,
					   user.Email.Value,
					   user.ProfileImageUrl?.Value,
					   user.CreatedAtUtc,
					   user.UpdatedAtUtc);
		}

		public AddUserCommandResponse ToResponse(
			AddUserApiRequest request)
		{
			return new(user.ToIdCommandResponse());
		}

		public UpdateCurrentUserCommandResponse ToResponse(
			UpdateCurrentUserApiRequest request)
		{
			return new(user.ToIdCommandResponse());
		}

		public GetUserByIdQueryResponse ToResponse(
			GetUserByIdApiRequest request)
		{
			return new(user.ToFullQueryResponse());
		}

		public GetUserDetailsByIdQueryResponse ToResponse(
			GetUserDetailsByIdApiRequest request)
		{
			return new(user.ToFullQueryDetailsResponse());
		}

		public GetCurrentUserByIdQueryResponse ToResponse(
			GetCurrentUserByIdApiRequest request)
		{
			return new(user.ToFullQueryResponse());
		}

		public GetCurrentUserDetailsByIdQueryResponse ToResponse(
			GetCurrentUserDetailsByIdApiRequest request)
		{
			return new(user.ToFullQueryDetailsResponse());
		}
	}

	extension(ICollection<User> users)
	{
		internal UserCollectionQueryResponse ToFullQueryResponse<TRequest>(
		TRequest request,
		Func<TRequest, User, bool> filter,
		Func<TRequest, User, UserQueryResponse> transform)
		where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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

		public GetAllUsersQueryResponse ToResponse(
			GetAllUsersApiRequest request)
		{
			return new(users.ToFullQueryResponse(request,
												 (request, user) => user.MatchesFilter(request),
												 (request, user) => user.ToFullQueryResponse()));
		}
	}
}
