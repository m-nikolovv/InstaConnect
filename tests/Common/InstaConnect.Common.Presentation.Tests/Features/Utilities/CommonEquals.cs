using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Domain.Features.Entities.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Common.Presentation.Features.AccessTokens.Models.Responses;
using InstaConnect.Common.Presentation.Features.Exceptions.Models;
using InstaConnect.Common.Presentation.Features.Requests.Abstractions;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Common.Tests.Features.Extensions;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace InstaConnect.Common.Presentation.Tests.Features.Utilities;

public static class CommonEquals
{
	extension(SetCookieHeaderValue cookie)
	{
		public bool MatchesHttpOnly(DateTimeOffset expires)
		{
			return cookie.Expires == expires &&
				   cookie.Secure &&
				   cookie.HttpOnly;
		}
	}

	extension(AccessTokenApiResponse response)
	{
		public bool Matches()
		{
			return response.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   response.ExpiresAtUtc != default;
		}
	}

	extension(ApplicationProblemDetails d)
	{
		public bool Matches(int statusCode, string detail)
		{
			return d.Status == statusCode &&
				   detail.EqualsOrdinalIgnoreCase(d.Detail);
		}

		public bool Matches(int statusCode, string detail, string errorMessage)
		{
			return d.Status == statusCode &&
				   detail.EqualsOrdinalIgnoreCase(d.Detail) &&
				   d.Errors!.AllAndNotEmpty(e => e == errorMessage);
		}
	}

	extension(ObjectResult s)
	{
		public bool Matches(int statusCode)
		{
			return s.StatusCode == statusCode;
		}
	}

	extension(StatusCodeResult s)
	{
		public bool Matches(int statusCode)
		{
			return s.StatusCode == statusCode;
		}
	}

	extension<TExpected>(ICollection<TExpected> expected)
	{
		public bool MatchesCollectionAndNotEmpty<TEntity, TKey, TRequest>(
			TRequest request,
			ICollection<TEntity> entities,
			Func<TExpected, TKey> expectedKey,
			Func<TEntity, TKey> entityKey,
			Func<TExpected, TEntity, bool> matcher,
			Func<TEntity, bool> filter)
			where TRequest : IPaginatableApiRequest
			where TEntity : IEntity
			where TKey : notnull
		{
			var entitiesByKey = entities.FilterToDictionary(request, filter, entityKey);

			return expected.Count == entitiesByKey.Count &&
				   expected.AllAndNotEmpty(e =>
				   entitiesByKey.TryGetValue(expectedKey(e), out var a) &&
				   matcher(e, a));
		}

		public bool MatchesSortedCollection<TEntity, TRequest>(
			TRequest request,
			ICollection<TEntity> entities,
			Func<TExpected, TEntity, bool> matcher,
			ISortEnumTermTransformer<TEntity> termTransformer,
			Func<TEntity, bool> filter)
			where TRequest : IPaginatableApiRequest
			where TEntity : IEntity
		{
			var sortedEntities = entities.Filter(request, termTransformer, filter);

			return expected.Count == sortedEntities.Count &&
				   expected.Zip(sortedEntities, (e, a) => matcher(e, a))
						   .AllAndNotEmpty(match => match);
		}
	}

	extension<TResponse>(TResponse response)
		where TResponse : ICollectionApiResponse
	{
		public bool MatchesCollectionResponse<TRequest>(TRequest request, int totalCount)
			where TRequest : IPaginatableApiRequest
		{
			var paginator = new Paginator();

			return response.Page == request.Page &&
				   response.PageSize == request.PageSize &&
				   response.TotalCount == totalCount &&
				   response.HasPreviousPage == paginator.HasPreviousPage(response.Page) &&
				   response.HasNextPage == paginator.HasNextPage(response.Page, response.PageSize, response.TotalCount);
		}
	}

	extension<TQueryRequest, TSortTerm>(TQueryRequest query)
			where TQueryRequest : ISortableQueryRequest<TSortTerm>
			where TSortTerm : Enum
	{
		public bool MatchesSortable<TApiRequest>(TApiRequest request)
			where TApiRequest : ISortableApiRequest<TSortTerm>
		{
			return query.SortOrder == request.SortOrder &&
				   query.SortTerm.Equals(request.SortTerm);
		}
	}

	extension<TQueryRequest>(TQueryRequest query)
			where TQueryRequest : IPaginatableQueryRequest
	{
		public bool MatchesPaginatable<TApiRequest>(TApiRequest request)
			where TApiRequest : IPaginatableApiRequest
		{
			return query.Page == request.Page &&
				   query.PageSize == request.PageSize;
		}
	}
}
