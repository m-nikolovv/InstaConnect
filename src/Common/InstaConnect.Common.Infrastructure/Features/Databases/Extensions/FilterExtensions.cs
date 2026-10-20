using InstaConnect.Common.Domain.Features.ValueObjects.Models;

namespace InstaConnect.Common.Infrastructure.Features.Databases.Extensions;

public static class FilterExtensions
{
	extension<T>(FilterDefinitionBuilder<T> builder)
	{
		public FilterDefinition<T> EqualsIgnoreCase(Expression<Func<T, object>> field, string value, bool isEmpty = false)
		{
			if (isEmpty)
			{
				return builder.Empty;
			}

			return builder.Regex(field, value.ToEqualsIgnoreCaseRegex());
		}

		public FilterDefinition<T> StartsWithIgnoreCase(Expression<Func<T, object>> field, string value, bool isEmpty = false)
		{
			if (isEmpty)
			{
				return builder.Empty;
			}

			return builder.Regex(field, value.ToStartsWithIgnoreCaseRegex());
		}
	}

	extension<T>(Name filter)
	{
		public FilterDefinition<T> GetFilterForNameEquals(Expression<Func<T, object>> nameField)
		{
			return Builders<T>.Filter
				.EqualsIgnoreCase(nameField, filter.Value, filter.IsEmpty());
		}

		public FilterDefinition<T> GetFilterForNameStartsWith(Expression<Func<T, object>> nameField)
		{
			return Builders<T>.Filter
				.StartsWithIgnoreCase(nameField, filter.Value, filter.IsEmpty());
		}
	}

	extension<T>(Email filter)
	{
		public FilterDefinition<T> GetFilterForEmailEquals(Expression<Func<T, object>> emailField)
		{
			return Builders<T>.Filter
				.EqualsIgnoreCase(emailField, filter.Value, filter.IsEmpty());
		}
	}
}
