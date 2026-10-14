using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;
using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Assertions;

public static class UserMatchAssertions
{
	extension(AddUserApiResponse response)
	{
		public void ShouldSatisfy(
		AddUserApiRequest request,
		User user)
		{
			response.ShouldSatisfy(p => p.Matches(request, user));
		}
	}

	extension(UpdateCurrentUserApiResponse response)
	{
		public void ShouldSatisfy(
		UpdateCurrentUserApiRequest request,
		User user)
		{
			response.ShouldSatisfy(p => p.Matches(request, user));
		}
	}

	extension(GetUserByIdApiResponse response)
	{
		public void ShouldSatisfy(
		GetUserByIdApiRequest request,
		User user)
		{
			response.ShouldSatisfy(p => p.Matches(request, user));
		}
	}


	extension(GetCurrentUserByIdApiResponse response)
	{
		public void ShouldSatisfy(
		GetCurrentUserByIdApiRequest request,
		User user)
		{
			response.ShouldSatisfy(p => p.Matches(request, user));
		}
	}

	extension(GetUserDetailsByIdApiResponse response)
	{
		public void ShouldSatisfy(
		GetUserDetailsByIdApiRequest request,
		User user)
		{
			response.ShouldSatisfy(p => p.Matches(request, user));
		}
	}


	extension(GetCurrentUserDetailsByIdApiResponse response)
	{
		public void ShouldSatisfy(
		GetCurrentUserDetailsByIdApiRequest request,
		User user)
		{
			response.ShouldSatisfy(p => p.Matches(request, user));
		}
	}

	extension(GetAllUsersApiResponse response)
	{
		public void ShouldSatisfy(
		GetAllUsersApiRequest request,
		ICollection<User> users)
		{
			response.ShouldSatisfy(p => p.Matches(request, users));
		}

		public void ShouldSatisfy(
			GetAllUsersApiRequest request,
			ICollection<User> users,
			ISortEnumTermTransformer<User> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(request, users, termTransformer));
		}
	}

	extension(ActionResult<AddUserApiResponse> response)
	{
		public void ShouldSatisfy(
		AddUserApiRequest request,
		User user)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, user));
		}
	}

	extension(ActionResult<UpdateCurrentUserApiResponse> response)
	{
		public void ShouldSatisfy(
		UpdateCurrentUserApiRequest request,
		User user)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, user));
		}
	}

	extension(ActionResult<GetUserByIdApiResponse> response)
	{
		public void ShouldSatisfy(
		GetUserByIdApiRequest request,
		User user)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, user));
		}
	}

	extension(ActionResult<GetCurrentUserByIdApiResponse> response)
	{
		public void ShouldSatisfy(
		GetCurrentUserByIdApiRequest request,
		User user)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, user));
		}
	}

	extension(ActionResult<GetUserDetailsByIdApiResponse> response)
	{
		public void ShouldSatisfy(
		GetUserDetailsByIdApiRequest request,
		User user)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, user));
		}
	}

	extension(ActionResult<GetCurrentUserDetailsByIdApiResponse> response)
	{
		public void ShouldSatisfy(
		GetCurrentUserDetailsByIdApiRequest request,
		User user)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, user));
		}
	}

	extension(ActionResult<GetAllUsersApiResponse> response)
	{
		public void ShouldSatisfy(
		GetAllUsersApiRequest request,
		ICollection<User> users)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, users));
		}

		public void ShouldSatisfy(
			GetAllUsersApiRequest request,
			ICollection<User> users,
			ISortEnumTermTransformer<User> termTransformer)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, users, termTransformer));
		}
	}

	extension(User user)
	{
		public void ShouldSatisfy(AddUserApiRequest request, IPasswordHasher passwordHasher)
		{
			user.ShouldSatisfy(p => p.Matches(request, passwordHasher));
		}

		public void ShouldSatisfy(UpdateCurrentUserApiRequest request)
		{
			user.ShouldSatisfy(p => p.Matches(request));
		}
	}

	extension(ICollection<EmailConfirmationToken> emailConfirmationTokens)
	{
		public void ShouldSatisfy(AddUserApiRequest request)
		{
			emailConfirmationTokens.ShouldSatisfy(p => p.Matches(request));
		}

		public void ShouldSatisfy(UpdateCurrentUserApiRequest request)
		{
			emailConfirmationTokens.ShouldSatisfy(p => p.Matches(request));
		}
	}

	extension(UserAddedEventRequest r)
	{
		public void ShouldSatisfy(AddUserApiRequest request, User entity)
		{
			r.ShouldSatisfy(r => r.Matches(request, entity));
		}
	}

	extension(UserUpdatedEventRequest r)
	{
		public void ShouldSatisfy(UpdateCurrentUserApiRequest request, User entity)
		{
			r.ShouldSatisfy(r => r.Matches(request, entity));
		}
	}

	extension(UserDeletedEventRequest r)
	{
		public void ShouldSatisfy(DeleteUserApiRequest request, User entity)
		{
			r.ShouldSatisfy(r => r.Matches(request, entity));
		}

		public void ShouldSatisfy(DeleteCurrentUserApiRequest request, User entity)
		{
			r.ShouldSatisfy(r => r.Matches(request, entity));
		}
	}

	extension(ICollection<EmailConfirmationTokenAddedEventRequest> r)
	{
		public void ShouldSatisfy(AddUserApiRequest request, ICollection<EmailConfirmationToken> entities)
		{
			r.ShouldSatisfy(r => r.Matches(request, entities));
		}
	}

	extension(ICollection<EmailConfirmationTokenDeletedEventRequest> r)
	{
		public void ShouldSatisfy(UpdateCurrentUserApiRequest request, ICollection<EmailConfirmationToken> entities)
		{
			r.ShouldSatisfy(r => r.Matches(request, entities));
		}
	}
}
