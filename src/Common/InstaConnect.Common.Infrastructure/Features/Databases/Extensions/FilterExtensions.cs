using InstaConnect.Common.Domain.Features.ValueObjects.Models;

namespace InstaConnect.Common.Infrastructure.Features.Databases.Extensions;

public static class FilterExtensions
{
	extension<T>(FilterDefinitionBuilder<T> builder)
	{
		public FilterDefinition<T> False => builder.Where(_ => false);

		public FilterDefinition<T> OrRange(IEnumerable<FilterDefinition<T>> filters)
		{
			if (filters.IsEmpty())
			{
				return builder.False;
			}

			return builder.Or(filters);
		}

		public FilterDefinition<T> AndAll(params FilterDefinition<T>[] filters)
		{
			if (filters.IsEmpty())
			{
				return builder.False;
			}

			return builder.And(filters);
		}

		public FilterDefinition<T> InRange(Expression<Func<T, object>> field, IEnumerable<object> values)
		{
			if (values.IsEmpty())
			{
				return builder.False;
			}

			return builder.In(field, values);
		}

		public FilterDefinition<T> EqualsValue(Expression<Func<T, object>> field, object value)
		{
			return builder.Eq(field, value);
		}

		public FilterDefinition<T> EqualsIgnoreCaseOrFalse(Expression<Func<T, object>> field, string value)
		{
			if (value.IsNullOrEmptyOrWhiteSpace())
			{
				return builder.False;
			}

			return builder.Eq(field, value);
		}

		public FilterDefinition<T> EqualsIgnoreCase(Expression<Func<T, object>> field, string value)
		{
			if (value.IsNullOrEmptyOrWhiteSpace())
			{
				return builder.Empty;
			}

			return builder.Eq(field, value);
		}

		public FilterDefinition<T> StartsWithIgnoreCase(Expression<Func<T, object>> field, string value)
		{
			if (value.IsNullOrEmptyOrWhiteSpace())
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
				.EqualsIgnoreCase(nameField, filter.Value);
		}

		public FilterDefinition<T> GetFilterForNameStartsWith(Expression<Func<T, object>> nameField)
		{
			return Builders<T>.Filter
				.StartsWithIgnoreCase(nameField, filter.Value);
		}
	}

	extension<T>(Email filter)
	{
		public FilterDefinition<T> GetFilterForEmailEquals(Expression<Func<T, object>> emailField)
		{
			return Builders<T>.Filter
				.EqualsIgnoreCase(emailField, filter.Value);
		}
	}
}
