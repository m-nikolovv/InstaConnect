using InstaConnect.Common.Domain.Features.Entities.Abstractions;
using InstaConnect.Common.Domain.Features.Requests.Abstractions;
using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Common.Tests.Features.Extensions;

namespace InstaConnect.Common.Tests.Features.Utilities;

public static class CommonEquals
{
	extension(Name p)
	{
		public bool Matches(string value)
		{
			return p.Value.EqualsOrdinalIgnoreCase(value);
		}

		public bool Matches(Name name)
		{
			return p.Matches(name.Value);
		}
	}

	extension(Email p)
	{
		public bool Matches(string value)
		{
			return p.Value.EqualsOrdinalIgnoreCase(value);
		}

		public bool Matches(Email email)
		{
			return p.Matches(email.Value);
		}
	}

	extension(Summary p)
	{
		public bool Matches(string value)
		{
			return p.Value == value;
		}

		public bool Matches(Summary summary)
		{
			return p.Matches(summary.Value);
		}
	}

	extension(Url? p)
	{
		public bool Matches(string? url)
		{
			return p == null || p.Value == url;
		}

		public bool Matches(Url? url)
		{
			return p.Matches(url?.Value);
		}
	}

	extension<TExpected>(ICollection<TExpected> e)
	{
		public bool MatchesCollection<TEntity, TKey>(
		ICollection<TEntity> entities,
		Func<TExpected, TKey> expectedKey,
		Func<TEntity, TKey> entityKey,
		Func<TExpected, TEntity, bool> matcher)
		where TEntity : IEntity
		where TKey : notnull
		{
			var entitiesByKey = entities
				.OrderBy(a => a.CreatedAtUtc)
				.ToDictionary(entityKey);

			return e.Count == entitiesByKey.Count &&
				   e.AllAndNotEmpty(e =>
				   entitiesByKey.TryGetValue(expectedKey(e), out var a) &&
				   matcher(e, a));
		}

		public bool MatchesCollection<TEntity, TKey, TQuery>(
		TQuery request,
		ICollection<TEntity> entities,
		Func<TExpected, TKey> expectedKey,
		Func<TEntity, TKey> entityKey,
		Func<TExpected, TEntity, bool> matcher,
		Func<TEntity, bool> filter)
		where TQuery : IPaginationQuery
		where TEntity : IEntity
		where TKey : notnull
		{
			var entitiesByKey = entities.FilterToDictionary(request, filter, entityKey);

			return e.Count == entitiesByKey.Count &&
				   e.AllAndNotEmpty(e =>
				   entitiesByKey.TryGetValue(expectedKey(e), out var a) &&
				   matcher(e, a));
		}

		public bool MatchesSortedCollection<TEntity, TQuery>(
			TQuery request,
			ICollection<TEntity> entities,
			Func<TExpected, TEntity, bool> matcher,
			ISortEnumTermTransformer<TEntity> termTransformer,
			Func<TEntity, bool> filter)
			where TQuery : IPaginationQuery
			where TEntity : IEntity
		{
			var sortedEntities = entities.Filter(request, termTransformer, filter);

			return e.Count == sortedEntities.Count &&
				   e.Zip(sortedEntities, (e, a) => matcher(e, a))
						   .AllAndNotEmpty(match => match);
		}
	}
}
