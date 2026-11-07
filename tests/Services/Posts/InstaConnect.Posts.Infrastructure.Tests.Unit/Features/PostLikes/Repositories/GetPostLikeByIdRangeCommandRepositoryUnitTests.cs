namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostLikes.Repositories;

public class GetPostLikeByIdRangeCommandRepositoryUnitTests : BasePostLikeInfrastructureCommandUnitTest
{
	private readonly PostLikeInclude _include;

	private readonly PostLikeCommandRepository _repository;

	public GetPostLikeByIdRangeCommandRepositoryUnitTests()
	{
		_include = IncludeBuilderFactory.Create().WithUser().WithPost().Build();

		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(PostLikeIds, Fluent);
		Fluent.SetupApplyIncludes(PostLikeIds, _include);
		Fluent.SetupMatch(PostLikeIds);
		Fluent.SetupToListAsync(PostLikeIds, PostLikes, CancellationToken);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _repository.GetByIdRangeAsync(PostLikeIds, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostLikeIds, PostLikes);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheCollectionAggregateFluent_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(PostLikeIds, _include, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(PostLikeIds);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheFluentApplyIncludes_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(PostLikeIds, _include, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneApplyIncludes(PostLikeIds, _include);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheFluentMatch_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(PostLikeIds, _include, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(PostLikeIds);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheFluentToListAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(PostLikeIds, _include, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneToListAsync(PostLikeIds, CancellationToken);
	}
}
