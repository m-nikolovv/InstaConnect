using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Extensions;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Extensions;

public static class EmailConfirmationTokenFilterExtensions
{
	extension(EmailConfirmationTokenId filter)
	{
		public FilterDefinition<EmailConfirmationToken> GetFilter()
		{
			return filter.GetFilterForIdEquals<EmailConfirmationToken>(p => p.Id.Id.Id, p => p.Id.Value);
		}

		public FilterDefinition<T> GetFilterForIdEquals<T>(
			Expression<Func<T, object>> idField,
			Expression<Func<T, object>> valueField)
		{
			var id = filter.Id.GetFilterForIdEquals(idField);
			var value = Builders<T>.Filter.EqualsIgnoreCase(valueField, filter.Value, filter.Value.IsNullOrEmptyOrWhiteSpace());

			return Builders<T>.Filter.And(id, value);
		}
	}

	extension(IEnumerable<EmailConfirmationTokenId> filter)
	{
		public FilterDefinition<EmailConfirmationToken> GetFilter()
		{
			return filter.GetFilterForIdRange<EmailConfirmationToken>(p => p.Id.Id.Id, p => p.Id.Value);
		}

		public FilterDefinition<T> GetFilterForIdRange<T>(
			Expression<Func<T, object>> idField,
			Expression<Func<T, object>> valueField)
		{
			return Builders<T>.Filter.Or(filter.Select(item => item.GetFilterForIdEquals(idField, valueField)));
		}
	}
}
