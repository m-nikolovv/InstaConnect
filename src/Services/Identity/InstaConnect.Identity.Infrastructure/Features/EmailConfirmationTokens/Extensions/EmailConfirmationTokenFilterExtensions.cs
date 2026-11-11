using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Extensions;

internal static class EmailConfirmationTokenFilterExtensions
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
			var value = Builders<T>.Filter.EqualsIgnoreCaseOrFalse(valueField, filter.Value);

			return Builders<T>.Filter.AndAll(id, value);
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
			return Builders<T>.Filter.OrRange(filter.Select(item => item.GetFilterForIdEquals(idField, valueField)));
		}
	}

	extension(UserId filter)
	{
		public FilterDefinition<EmailConfirmationToken> GetEmailConfirmationTokenByParentFilter()
		{
			return filter.GetFilterForIdEquals<EmailConfirmationToken>(p => p.Id.Id.Id);
		}
	}
}
