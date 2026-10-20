namespace InstaConnect.Posts.Infrastructure.Features.Users.Extensions;

internal static class UserFilterExtensions
{
	extension(UserId filter)
	{
		public FilterDefinition<User> GetFilter()
		{
			return filter.GetFilterForIdEquals<User>(p => p.Id.Id);
		}

		public FilterDefinition<T> GetFilterForIdEquals<T>(Expression<Func<T, object>> idField)
		{
			return Builders<T>.Filter.EqualsIgnoreCase(idField, filter.Id, filter.Id.IsEmpty());
		}
	}

	extension(Name filter)
	{
		public FilterDefinition<User> GetFilter()
		{
			return filter.GetFilterForNameEquals<User>(p => p.Name.Value);
		}
	}

	extension(Email filter)
	{
		public FilterDefinition<User> GetFilter()
		{
			return filter.GetFilterForEmailEquals<User>(p => p.Email.Value);
		}
	}
}
