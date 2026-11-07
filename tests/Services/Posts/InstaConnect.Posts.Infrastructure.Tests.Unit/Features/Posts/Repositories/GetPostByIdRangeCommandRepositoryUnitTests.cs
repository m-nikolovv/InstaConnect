using InstaConnect.Posts.Tests.Features.Posts.Assertions;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.Posts.Repositories;

public class GetPostByIdRangeCommandRepositoryUnitTests : BasePostInfrastructureCommandUnitTest
{
	private readonly PostInclude _include;

	private readonly PostCommandRepository _repository;

	public GetPostByIdRangeCommandRepositoryUnitTests()
	{
		_include = IncludeBuilderFactory.Create().WithUser().WithPostLikes().Build();

		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(PostIds, Fluent);
		Fluent.SetupApplyIncludes(PostIds, _include);
		Fluent.SetupMatch(PostIds);
		Fluent.SetupToListAsync(PostIds, Posts, CancellationToken);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _repository.GetByIdRangeAsync(PostIds, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostIds, Posts);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheCollectionAggregateFluent_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(PostIds, _include, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(PostIds);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheFluentApplyIncludes_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(PostIds, _include, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneApplyIncludes(PostIds, _include);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheFluentMatch_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(PostIds, _include, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(PostIds);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheFluentToListAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(PostIds, _include, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneToListAsync(PostIds, CancellationToken);
	}
}
