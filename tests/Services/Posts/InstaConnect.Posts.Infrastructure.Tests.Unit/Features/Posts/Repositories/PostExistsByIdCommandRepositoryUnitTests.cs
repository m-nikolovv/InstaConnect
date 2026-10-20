using InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Repositories;
using InstaConnect.Posts.Infrastructure.Tests.Features.Posts.Assertions;
using InstaConnect.Posts.Infrastructure.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Infrastructure.Tests.Unit.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Assertions;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.Posts.Repositories;

public class PostExistsByIdCommandRepositoryUnitTests : BasePostInfrastructureCommandUnitTest
{
	private readonly PostCommandRepository _repository;

	public PostExistsByIdCommandRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(PostId, Fluent);
		Fluent.SetupMatch(PostId);
		Fluent.SetupAnyAsync(PostId, Post, CancellationToken);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _repository.ExistsByIdAsync(PostId, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostId, Post);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenCommandIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(PostId, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(PostId);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheFluentMatch_WhenCommandIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(PostId, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(PostId);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheFluentAnyAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(PostId, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneAnyAsync(PostId, CancellationToken);
	}
}
