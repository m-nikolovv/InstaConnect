using InstaConnect.Posts.Application.Features.Users.Models;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Models.Requests;

namespace InstaConnect.Posts.Application.Tests.Features.Users.Utilities;

public static class UserEquals
{
	extension(AddUserCommandResponse response)
	{
		public bool Matches(
		AddUserCommandRequest request,
		User user)
		{
			return response.Response.Matches(request.Id);
		}
	}

	extension(UpdateUserCommandResponse response)
	{
		public bool Matches(
		UpdateUserCommandRequest request,
		User user)
		{
			return response.Response.Matches(request.Id);
		}
	}

	extension(User user)
	{
		public bool Matches(AddUserCommandRequest request)
		{
			return user.Id.Matches(request.Id) &&
				   user.FirstName == request.FirstName &&
				   user.LastName == request.LastName &&
				   user.Name.Matches(request.Name) &&
				   user.Email.Matches(request.Email) &&
				   user.ProfileImageUrl.Matches(request.ProfileImageUrl) &&
				   user.CreatedAtUtc == request.CreatedAtUtc &&
				   user.UpdatedAtUtc == request.UpdatedAtUtc;
		}

		public bool Matches(UpdateUserCommandRequest request)
		{
			return user.Id.Matches(request.Id) &&
				   user.FirstName == request.FirstName &&
				   user.LastName == request.LastName &&
				   user.Name.Matches(request.Name) &&
				   user.Email.Matches(request.Email) &&
				   user.ProfileImageUrl.Matches(request.ProfileImageUrl) &&
				   user.CreatedAtUtc != default &&
				   user.UpdatedAtUtc == request.UpdatedAtUtc;
		}
	}

	extension(AddUserCommand command)
	{
		public bool Matches(AddUserCommandRequest request)
		{
			return command.Id.Matches(request.Id) &&
				   command.Email.Matches(request.Email) &&
				   command.Name.Matches(request.Name) &&
				   command.FirstName == request.FirstName &&
				   command.LastName == request.LastName &&
				   command.ProfileImageUrl.Matches(request.ProfileImageUrl) &&
				   command.CreatedAtUtc == request.CreatedAtUtc &&
				   command.UpdatedAtUtc == request.UpdatedAtUtc;
		}
	}

	extension(UpdateUserCommand command)
	{
		public bool Matches(UpdateUserCommandRequest request)
		{
			return command.Id.Matches(request.Id) &&
				   command.Email.Matches(request.Email) &&
				   command.Name.Matches(request.Name) &&
				   command.FirstName == request.FirstName &&
				   command.LastName == request.LastName &&
				   command.ProfileImageUrl.Matches(request.ProfileImageUrl) &&
				   command.UpdatedAtUtc == request.UpdatedAtUtc;
		}
	}

	extension(DeleteUserCommand command)
	{
		public bool Matches(DeleteUserCommandRequest request)
		{
			return command.Id.Matches(request.Id);
		}
	}

	extension(UserIdCommandResponse response)
	{
		public bool Matches(UserId id)
		{
			return id.Matches(response.Id);
		}

		public bool Matches(string id)
		{
			return id.EqualsOrdinalIgnoreCase(response.Id);
		}
	}

	extension(UserQueryResponse? response)
	{
		public bool MatchesFull(User? user)
		{
			return response != null &&
				   user != null &&
				   user.Id.Matches(response.Id) &&
				   user.FirstName == response.FirstName &&
				   user.LastName == response.LastName &&
				   user.Name.Matches(response.Name) &&
				   user.ProfileImageUrl.Matches(response.ProfileImageUrl) &&
				   user.CreatedAtUtc == response.CreatedAtUtc &&
				   user.UpdatedAtUtc == response.UpdatedAtUtc;
		}
	}

	extension<TQuery>(TQuery query) where TQuery : ICurrentUserableQuery
	{
		public bool MatchesCurrentUserable<TQueryRequest>(
		TQueryRequest request)
		where TQueryRequest : ICurrentUserableQueryRequest
		{
			return query.CurrentUser.Id.Matches(request.CurrentUserId);
		}
	}
}
