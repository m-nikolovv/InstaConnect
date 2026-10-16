using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Posts.Domain.Features.Users.Models.ValueObjects;

namespace InstaConnect.Posts.Tests.Features.Users.Utilities;

public static class UserEquals
{
	extension(UserEventRequest r)
	{
		public bool Matches(UserEventRequest request)
		{
			return r.Id == request.Id &&
				   r.Name == request.Name &&
				   r.Email == request.Email &&
				   r.FirstName == request.FirstName &&
				   r.LastName == request.LastName &&
				   r.ProfileImageUrl == request.ProfileImageUrl &&
				   r.CreatedAtUtc == request.CreatedAtUtc &&
				   r.UpdatedAtUtc == request.UpdatedAtUtc;
		}
	}

	extension(User? entity)
	{
		public bool Matches(UserEventRequest request)
		{
			return entity != null &&
				   entity.Id.Matches(request.Id) &&
				   entity.Name.Matches(request.Name) &&
				   entity.Email.Matches(request.Email) &&
				   entity.FirstName == request.FirstName &&
				   entity.LastName == request.LastName &&
				   entity.ProfileImageUrl.Matches(request.ProfileImageUrl) &&
				   entity.CreatedAtUtc == request.CreatedAtUtc &&
				   entity.UpdatedAtUtc == request.UpdatedAtUtc;
		}
	}

	extension(User entity)
	{
		public bool Matches(User u)
		{
			return entity.Id.Matches(u.Id) &&
				   entity.Email.Matches(u.Email) &&
				   entity.FirstName == u.FirstName &&
				   entity.LastName == u.LastName &&
				   entity.Name.Matches(u.Name) &&
				   entity.ProfileImageUrl.Matches(u.ProfileImageUrl) &&
				   entity.CreatedAtUtc == u.CreatedAtUtc &&
				   entity.UpdatedAtUtc == u.UpdatedAtUtc;
		}
	}

	extension(UserId p)
	{
		public bool Matches(UserId id)
		{
			return p.Matches(id.Id);
		}

		public bool Matches(string id)
		{
			return p.Id.EqualsOrdinalIgnoreCase(id);
		}
	}
}
