using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Extensions;

internal static class RefreshTokenFilterExtensions
{
	extension(RefreshTokenId filter)
	{
		public FilterDefinition<RefreshToken> GetFilter()
		{
			return filter.GetFilterForIdEquals<RefreshToken>(p => p.Id.Id.Id, p => p.Id.Value);
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

	extension(IEnumerable<RefreshTokenId> filter)
	{
		public FilterDefinition<RefreshToken> GetFilter()
		{
			return filter.GetFilterForIdRange<RefreshToken>(p => p.Id.Id.Id, p => p.Id.Value);
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
		public FilterDefinition<RefreshToken> GetRefreshTokenByParentFilter()
		{
			return filter.GetFilterForIdEquals<RefreshToken>(p => p.Id.Id.Id);
		}
	}
}
