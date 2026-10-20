using InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Repositories;
using InstaConnect.Follows.Infrastructure.Tests.Unit.Features.Follows.Utilities;

namespace InstaConnect.Follows.Infrastructure.Tests.Unit.Features.Follows.Repositories;

public class AddFollowCommandRepositoryUnitTests : BaseFollowInfrastructureCommandUnitTest
{
	private readonly FollowCommandRepository _repository;

	public AddFollowCommandRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheCollectionAddAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.AddAsync(Follow, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneAddAsync(Follow, CancellationToken);
	}
}
