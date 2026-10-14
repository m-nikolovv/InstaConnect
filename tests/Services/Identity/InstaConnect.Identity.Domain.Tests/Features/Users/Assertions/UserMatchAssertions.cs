using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Identity.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;
using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Identity.Domain.Tests.Features.Users.Assertions;

public static class UserMatchAssertions
{
	extension(UserId response)
	{
		public void ShouldSatisfy(AddUserCommand command, User user)
		{
			response.ShouldSatisfy(p => p.Matches(command, user));
		}

		public void ShouldSatisfy(UpdateUserCommand command, User user)
		{
			response.ShouldSatisfy(p => p.Matches(command, user));
		}
	}

	extension(UserResponse response)
	{
		public void ShouldSatisfy(GetUserByIdQuery query, User user)
		{
			response.ShouldSatisfy(p => p.Matches(query, user));
		}
	}

	extension(UserCollectionResponse response)
	{
		public void ShouldSatisfy(
			GetAllUsersQuery query,
			ICollection<User> users)
		{
			response.ShouldSatisfy(p => p.Matches(query, users));
		}

		public void ShouldSatisfy(
			GetAllUsersQuery query,
			ICollection<User> users,
			ISortEnumTermTransformer<User> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(query, users, termTransformer));
		}
	}

	extension(User user)
	{
		public void ShouldSatisfy(AddUserCommand command)
		{
			user.ShouldSatisfy(p => p.Matches(command));
		}

		public void ShouldSatisfy(UpdateUserCommand command)
		{
			user.ShouldSatisfy(p => p.Matches(command));
		}
	}

	extension(ICollection<EmailConfirmationToken> emailConfirmationTokens)
	{
		public void ShouldSatisfy(AddUserCommand command)
		{
			emailConfirmationTokens.ShouldSatisfy(p => p.Matches(command));
		}

		public void ShouldSatisfy(UpdateUserCommand command)
		{
			emailConfirmationTokens.ShouldSatisfy(p => p.Matches(command));
		}
	}

	extension(UserAddedEventRequest r)
	{
		public void ShouldSatisfy(AddUserCommand command, User entity)
		{
			r.ShouldSatisfy(r => r.Matches(command, entity));
		}
	}

	extension(UserUpdatedEventRequest r)
	{
		public void ShouldSatisfy(UpdateUserCommand command, User entity)
		{
			r.ShouldSatisfy(r => r.Matches(command, entity));
		}
	}

	extension(UserDeletedEventRequest r)
	{
		public void ShouldSatisfy(DeleteUserCommand command, User entity)
		{
			r.ShouldSatisfy(r => r.Matches(command, entity));
		}
	}

	extension(ICollection<EmailConfirmationTokenAddedEventRequest> r)
	{
		public void ShouldSatisfy(AddUserCommand command, ICollection<EmailConfirmationToken> entities)
		{
			r.ShouldSatisfy(r => r.Matches(command, entities));
		}
	}

	extension(ICollection<EmailConfirmationTokenDeletedEventRequest> r)
	{
		public void ShouldSatisfy(UpdateUserCommand command, ICollection<EmailConfirmationToken> entities)
		{
			r.ShouldSatisfy(r => r.Matches(command, entities));
		}
	}
}
