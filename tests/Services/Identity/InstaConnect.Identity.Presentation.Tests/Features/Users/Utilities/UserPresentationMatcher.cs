using InstaConnect.Identity.Application.Features.Users.Commands.Add;
using InstaConnect.Identity.Application.Features.Users.Commands.Delete;
using InstaConnect.Identity.Application.Features.Users.Commands.DeleteCurrent;
using InstaConnect.Identity.Application.Features.Users.Commands.UpdateCurrent;
using InstaConnect.Identity.Application.Features.Users.Queries.GetAll;
using InstaConnect.Identity.Application.Features.Users.Queries.GetById;
using InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentById;
using InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentDetailsById;
using InstaConnect.Identity.Application.Features.Users.Queries.GetDetailsById;

namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

public static class UserPresentationMatcher
{
	extension(GetAllUsersApiRequest request)
	{
		public GetAllUsersQueryRequest IsGetAllUsersQueryRequest()
		{
			return Matcher.Is<GetAllUsersQueryRequest>(p => p.Matches(request));
		}
	}

	extension(GetUserByIdApiRequest request)
	{
		public GetUserByIdQueryRequest IsGetUserByIdQueryRequest()
		{
			return Matcher.Is<GetUserByIdQueryRequest>(p => p.Matches(request));
		}
	}

	extension(GetCurrentUserByIdApiRequest request)
	{
		public GetCurrentUserByIdQueryRequest IsGetCurrentUserByIdQueryRequest()
		{
			return Matcher.Is<GetCurrentUserByIdQueryRequest>(p => p.Matches(request));
		}
	}

	extension(GetUserDetailsByIdApiRequest request)
	{
		public GetUserDetailsByIdQueryRequest IsGetUserDetailsByIdQueryRequest()
		{
			return Matcher.Is<GetUserDetailsByIdQueryRequest>(p => p.Matches(request));
		}
	}

	extension(GetCurrentUserDetailsByIdApiRequest request)
	{
		public GetCurrentUserDetailsByIdQueryRequest IsGetCurrentUserDetailsByIdQueryRequest()
		{
			return Matcher.Is<GetCurrentUserDetailsByIdQueryRequest>(p => p.Matches(request));
		}
	}

	extension(AddUserApiRequest request)
	{
		public AddUserCommandRequest IsAddUserCommandRequest()
		{
			return Matcher.Is<AddUserCommandRequest>(p => p.Matches(request));
		}
	}

	extension(UpdateCurrentUserApiRequest request)
	{
		public UpdateCurrentUserCommandRequest IsUpdateCurrentUserCommandRequest()
		{
			return Matcher.Is<UpdateCurrentUserCommandRequest>(p => p.Matches(request));
		}
	}

	extension(DeleteUserApiRequest request)
	{
		public DeleteUserCommandRequest IsDeleteUserCommandRequest()
		{
			return Matcher.Is<DeleteUserCommandRequest>(p => p.Matches(request));
		}
	}

	extension(DeleteCurrentUserApiRequest request)
	{
		public DeleteCurrentUserCommandRequest IsDeleteCurrentUserCommandRequest()
		{
			return Matcher.Is<DeleteCurrentUserCommandRequest>(p => p.Matches(request));
		}
	}
}
