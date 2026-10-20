using InstaConnect.Common.Domain.Features.Entities.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;
using InstaConnect.Common.Tests.Features.Utilities;

namespace InstaConnect.Common.Infrastructure.Tests.Features.Utilities;

public static class MockSetups
{
	extension<TEntity>(IMongoDbFluent<TEntity> fluent)
		where TEntity : ICreatable
	{
		public void SetupAnyAsync(
			bool exists,
			CancellationToken cancellationToken)
		{
			fluent.AnyAsync(cancellationToken).ReturnsTaskResponse(exists);
		}

		public void SetupGetCountAsync(
			long count,
			CancellationToken cancellationToken)
		{
			fluent.GetCountAsync(cancellationToken).ReturnsTaskResponse(count);
		}

		public void SetupFirstOrDefaultAsync(
			TEntity? entity,
			CancellationToken cancellationToken)
		{
			fluent.FirstOrDefaultAsync(cancellationToken).ReturnsTaskResponse(entity);
		}

		public void SetupToListAsync(
			ICollection<TEntity> entities,
			CancellationToken cancellationToken)
		{
			fluent.ToListAsync(cancellationToken).ReturnsTaskResponse(entities);
		}
	}

	extension<TEntity>(IMongoDbResponseFluent<TEntity> fluent)
		where TEntity : ICreatable
	{
		public void SetupFirstOrDefaultAsync(
			TEntity? entity,
			CancellationToken cancellationToken)
		{
			fluent.FirstOrDefaultAsync(cancellationToken).ReturnsTaskResponse(entity);
		}

		public void SetupToListAsync(
			ICollection<TEntity> entities,
			CancellationToken cancellationToken)
		{
			fluent.ToListAsync(cancellationToken).ReturnsTaskResponse(entities);
		}
	}
}
