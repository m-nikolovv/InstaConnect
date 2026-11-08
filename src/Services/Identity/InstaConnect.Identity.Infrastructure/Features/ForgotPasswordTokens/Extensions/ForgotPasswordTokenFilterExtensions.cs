using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;

internal static class ForgotPasswordTokenFilterExtensions
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
			var value = Builders<T>.Filter.EqualsIgnoreCaseOrFalse(valueField, filter.Value);

			return Builders<T>.Filter.AndAll(id, value);
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
			return Builders<T>.Filter.OrRange(filter.Select(item => item.GetFilterForIdEquals(idField, valueField)));
		}
	}

	extension(UserId filter)
	{
		public FilterDefinition<ForgotPasswordToken> GetForgotPasswordTokenCascadeFilter()
		{
			return filter.GetFilterForIdEquals<ForgotPasswordToken>(p => p.Id.Id.Id);
		}
	}
}
