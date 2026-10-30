using FluentValidation.Results;

using InstaConnect.Common.Application.Features.AccessTokens.Models;
using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Domain.Features.Entities.Abstractions;
using InstaConnect.Common.Domain.Features.Requests.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Common.Tests.Features.Extensions;

namespace InstaConnect.Common.Application.Tests.Features.Utilities;

public static class CommonEquals
{
	extension(AccessTokenCommandResponse response)
	{
		public bool Matches()
		{
			return response.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   response.ExpiresAtUtc != default;
		}
	}

	extension(ValidationFailure v)
	{
		public bool Matches(
		string errorMessage)
		{
			return v.ErrorMessage.EqualsOrdinalIgnoreCase(errorMessage);
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
		where TRequest : IPaginatableQueryRequest
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
			where TRequest : IPaginatableQueryRequest
			where TEntity : IEntity
		{
			var sortedEntities = entities.Filter(request, termTransformer, filter);

			return expected.Count == sortedEntities.Count &&
				   expected.Zip(sortedEntities, (e, a) => matcher(e, a))
						   .AllAndNotEmpty(match => match);
		}
	}

	extension<TResponse>(TResponse response) where TResponse : ICollectionQueryResponse
	{
		public bool MatchesCollectionResponse<TRequest>(
		TRequest request,
		int totalCount)
			where TRequest : IPaginatableQueryRequest
		{
			var paginator = new Paginator();

			return response.Page == request.Page &&
				   response.PageSize == request.PageSize &&
				   response.TotalCount == totalCount &&
				   response.HasPreviousPage == paginator.HasPreviousPage(response.Page) &&
				   response.HasNextPage == paginator.HasNextPage(response.Page, response.PageSize, response.TotalCount);
		}
	}

	extension<TQuery, TSortTerm, TSortingQuery>(TQuery query)
			where TQuery : ISortableQuery<TSortingQuery, TSortTerm>
			where TSortingQuery : ISortingQuery<TSortTerm>
			where TSortTerm : Enum
	{
		public bool MatchesSortable<TQueryRequest>(TQueryRequest request)
		where TQueryRequest : ISortableQueryRequest<TSortTerm>
		{
			return query.Sorting.Order == request.SortOrder &&
				   query.Sorting.Term.Equals(request.SortTerm);
		}
	}

	extension<TQuery, TPaginationQuery>(TQuery query)
			where TQuery : IPaginatableQuery<TPaginationQuery>
			where TPaginationQuery : IPaginationQuery
	{
		public bool MatchesPaginatable<TQueryRequest>(TQueryRequest request)
		where TQueryRequest : IPaginatableQueryRequest
		{
			return query.Pagination.Page == request.Page &&
				   query.Pagination.PageSize == request.PageSize;
		}
	}
}
