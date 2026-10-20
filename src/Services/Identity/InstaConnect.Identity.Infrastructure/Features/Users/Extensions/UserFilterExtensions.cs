namespace InstaConnect.Identity.Infrastructure.Features.Users.Extensions;

public static class UserFilterExtensions
{
	extension(UsersFilterQuery filter)
	{
		public FilterDefinition<User> GetFilter()
		{
			var name = filter.Name.GetFilterForNameStartsWith<User>(p => p.Name.Value);
			var firstName = Builders<User>.Filter.StartsWithIgnoreCase(
				p => p.FirstName, filter.FirstName, filter.FirstName.IsNullOrEmptyOrWhiteSpace());
			var lastName = Builders<User>.Filter.StartsWithIgnoreCase(
				p => p.LastName, filter.LastName, filter.LastName.IsNullOrEmptyOrWhiteSpace());

			return Builders<User>.Filter.And(name, firstName, lastName);
		}
	}

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
