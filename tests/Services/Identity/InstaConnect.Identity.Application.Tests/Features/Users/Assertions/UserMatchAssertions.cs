using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;

namespace InstaConnect.Identity.Application.Tests.Features.Users.Assertions;

public static class UserMatchAssertions
{
	extension(AddUserCommandResponse response)
	{
		public void ShouldSatisfy(AddUserCommandRequest request, User user)
		{
			response.ShouldSatisfy(p => p.Matches(request, user));
		}
	}

	extension(UpdateCurrentUserCommandResponse response)
	{
		public void ShouldSatisfy(UpdateCurrentUserCommandRequest request, User user)
		{
			response.ShouldSatisfy(p => p.Matches(request, user));
		}
	}

	extension(GetUserByIdQueryResponse response)
	{
		public void ShouldSatisfy(GetUserByIdQueryRequest request, User user)
		{
			response.ShouldSatisfy(p => p.Matches(request, user));
		}
	}

	extension(GetCurrentUserByIdQueryResponse response)
	{
		public void ShouldSatisfy(GetCurrentUserByIdQueryRequest request, User user)
		{
			response.ShouldSatisfy(p => p.Matches(request, user));
		}
	}

	extension(GetUserDetailsByIdQueryResponse response)
	{
		public void ShouldSatisfy(GetUserDetailsByIdQueryRequest request, User user)
		{
			response.ShouldSatisfy(p => p.Matches(request, user));
		}
	}

	extension(GetCurrentUserDetailsByIdQueryResponse response)
	{
		public void ShouldSatisfy(GetCurrentUserDetailsByIdQueryRequest request, User user)
		{
			response.ShouldSatisfy(p => p.Matches(request, user));
		}
	}

	extension(GetAllUsersQueryResponse response)
	{
		public void ShouldSatisfy(
		GetAllUsersQueryRequest request,
		ICollection<User> users)
		{
			response.ShouldSatisfy(p => p.Matches(request, users));
		}

		public void ShouldSatisfy(
			GetAllUsersQueryRequest request,
			ICollection<User> users,
			ISortEnumTermTransformer<User> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(request, users, termTransformer));
		}
	}

	extension(User user)
	{
		public void ShouldSatisfy(AddUserCommandRequest request, IPasswordHasher passwordHasher)
		{
			user.ShouldSatisfy(p => p.Matches(request, passwordHasher));
		}

		public void ShouldSatisfy(UpdateCurrentUserCommandRequest request)
		{
			user.ShouldSatisfy(p => p.Matches(request));
		}
	}

	extension(ICollection<EmailConfirmationToken> emailConfirmationTokens)
	{
		public void ShouldSatisfy(AddUserCommandRequest request)
		{
			emailConfirmationTokens.ShouldSatisfy(p => p.Matches(request));
		}

		public void ShouldSatisfy(UpdateCurrentUserCommandRequest request)
		{
			emailConfirmationTokens.ShouldSatisfy(p => p.Matches(request));
		}
	}

	extension(UserAddedEventRequest r)
	{
		public void ShouldSatisfy(AddUserCommandRequest request, User entity)
		{
			r.ShouldSatisfy(r => r.Matches(request, entity));
		}
	}

	extension(UserUpdatedEventRequest r)
	{
		public void ShouldSatisfy(UpdateCurrentUserCommandRequest request, User entity)
		{
			r.ShouldSatisfy(r => r.Matches(request, entity));
		}
	}

	extension(UserDeletedEventRequest r)
	{
		public void ShouldSatisfy(DeleteUserCommandRequest request, User entity)
		{
			r.ShouldSatisfy(r => r.Matches(request, entity));
		}

		public void ShouldSatisfy(DeleteCurrentUserCommandRequest request, User entity)
		{
			r.ShouldSatisfy(r => r.Matches(request, entity));
		}
	}

	extension(ICollection<EmailConfirmationTokenAddedEventRequest> r)
	{
		public void ShouldSatisfy(AddUserCommandRequest request, ICollection<EmailConfirmationToken> entities)
		{
			r.ShouldSatisfy(r => r.Matches(request, entities));
		}
	}

	extension(ICollection<EmailConfirmationTokenDeletedEventRequest> r)
	{
		public void ShouldSatisfy(UpdateCurrentUserCommandRequest request, ICollection<EmailConfirmationToken> entities)
		{
			r.ShouldSatisfy(r => r.Matches(request, entities));
		}
	}
}
