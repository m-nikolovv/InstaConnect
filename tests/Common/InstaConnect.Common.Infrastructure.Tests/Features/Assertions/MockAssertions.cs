using InstaConnect.Common.Domain.Features.Entities.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;
using InstaConnect.Common.Tests.Features.Assertions;

namespace InstaConnect.Common.Infrastructure.Tests.Features.Assertions;

public static class MockAssertions
{
	extension<TEntity, TEntityId>(IMongoDbFluent<TEntity, TEntityId> fluent)
		where TEntity : ICreatable, IEntityWithId<TEntityId>
		where TEntityId : IEntityId
	{
		public async Task ShouldHaveReceivedOneAnyAsync(CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOne().AnyAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetCountAsync(CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOne().GetCountAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneFirstOrDefaultAsync(CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOne().FirstOrDefaultAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneToListAsync(CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOne().ToListAsync(cancellationToken);
		}
	}

	extension<TEntity>(IMongoDbResponseFluent<TEntity> fluent)
		where TEntity : ICreatable
	{
		public async Task ShouldHaveReceivedOneFirstOrDefaultAsync(CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOne().FirstOrDefaultAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneToListAsync(CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOne().ToListAsync(cancellationToken);
		}
	}
}
