using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;

public static class ForgotPasswordTokenFilterExtensions
{
	extension(ForgotPasswordTokenId filter)
	{
		public FilterDefinition<ForgotPasswordToken> GetFilter()
		{
			return filter.GetFilterForIdEquals<ForgotPasswordToken>(p => p.Id.Id.Id, p => p.Id.Value);
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

	extension(IEnumerable<ForgotPasswordTokenId> filter)
	{
		public FilterDefinition<ForgotPasswordToken> GetFilter()
		{
			return filter.GetFilterForIdRange<ForgotPasswordToken>(p => p.Id.Id.Id, p => p.Id.Value);
		}

		public FilterDefinition<T> GetFilterForIdRange<T>(
			Expression<Func<T, object>> idField,
			Expression<Func<T, object>> valueField)
		{
			return Builders<T>.Filter.Or(filter.Select(item => item.GetFilterForIdEquals(idField, valueField)));
		}
	}
}
