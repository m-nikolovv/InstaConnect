using InstaConnect.Common.Domain.Features.Requests.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;

namespace InstaConnect.Common.Tests.Features.Utilities;

public static class CommonCollectionFiltering
{
	extension<TEntity>(ICollection<TEntity> entities)
		where TEntity : IEntity
	{
		public IDictionary<TKey, TEntity> FilterToDictionary<TQuery, TKey>(
			TQuery request,
			Func<TEntity, bool> filter,
			Func<TEntity, TKey> entityKey)
			where TQuery : IPaginationQuery
			where TKey : notnull
		{
			var paginator = new Paginator();
			var offset = paginator.GetOffset(request.Page, request.PageSize);

			return entities.Where(filter)
				.OrderBy(a => a.CreatedAtUtc)
				.Skip(offset)
				.Take(request.PageSize)
				.ToDictionary(entityKey);
		}

		public ICollection<TEntity> Filter<TQuery>(
			TQuery request,
			ISortEnumTermTransformer<TEntity> termTransformer,
			Func<TEntity, bool> filter)
			where TQuery : IPaginationQuery
		{
			var paginator = new Paginator();
			var offset = paginator.GetOffset(request.Page, request.PageSize);

			var filteredEntities = entities.Where(filter);

			return [.. termTransformer
				.Transform(filteredEntities)
				.Skip(offset)
				.Take(request.PageSize)];
		}

		public ICollection<TResponse> Filter<TQuery, TResponse>(
			TQuery request,
			Func<TEntity, bool> filter,
			Func<TEntity, TResponse> select)
			where TQuery : IPaginationQuery
		{
			var paginator = new Paginator();
			var offset = paginator.GetOffset(request.Page, request.PageSize);

			return [.. entities
				.Where(filter)
				.OrderBy(a => a.CreatedAtUtc)
				.Select(select)
				.Skip(offset)
				.Take(request.PageSize)];
		}
	}
}
