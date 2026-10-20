using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Repositories;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Assertions;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostLikes.Repositories;

public class GetPostLikeByIdCommandRepositoryUnitTests : BasePostLikeInfrastructureCommandUnitTest
{
	private readonly PostLikeInclude _include;

	private readonly PostLikeCommandRepository _repository;

	public GetPostLikeByIdCommandRepositoryUnitTests()
	{
		_include = IncludeBuilderFactory.Create().WithUser().WithPost().Build();

		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(PostLikeId, Fluent);
		Fluent.SetupApplyIncludes(PostLikeId, _include);
		Fluent.SetupMatch(PostLikeId);
		Fluent.SetupFirstOrDefaultAsync(PostLikeId, PostLike, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _repository.GetByIdAsync(PostLikeId, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostLikeId, PostLike);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(PostLikeId, _include, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(PostLikeId);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentApplyIncludes_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(PostLikeId, _include, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneApplyIncludes(PostLikeId, _include);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(PostLikeId, _include, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(PostLikeId);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentFirstOrDefaultAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdAsync(PostLikeId, _include, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(PostLikeId, CancellationToken);
	}
}
