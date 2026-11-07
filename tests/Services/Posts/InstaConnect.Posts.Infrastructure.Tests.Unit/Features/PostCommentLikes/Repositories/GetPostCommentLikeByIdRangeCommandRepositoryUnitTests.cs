namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostCommentLikes.Repositories;

public class GetPostCommentLikeByIdRangeCommandRepositoryUnitTests : BasePostCommentLikeInfrastructureCommandUnitTest
{
	private readonly PostCommentLikeInclude _include;

	private readonly PostCommentLikeCommandRepository _repository;

	public GetPostCommentLikeByIdRangeCommandRepositoryUnitTests()
	{
		_include = IncludeBuilderFactory.Create().WithUser().WithPostComment().Build();

		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(PostCommentLikeIds, Fluent);
		Fluent.SetupApplyIncludes(PostCommentLikeIds, _include);
		Fluent.SetupMatch(PostCommentLikeIds);
		Fluent.SetupToListAsync(PostCommentLikeIds, PostCommentLikes, CancellationToken);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _repository.GetByIdRangeAsync(PostCommentLikeIds, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostCommentLikeIds, PostCommentLikes);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheCollectionAggregateFluent_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(PostCommentLikeIds, _include, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(PostCommentLikeIds);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheFluentApplyIncludes_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(PostCommentLikeIds, _include, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneApplyIncludes(PostCommentLikeIds, _include);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheFluentMatch_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(PostCommentLikeIds, _include, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(PostCommentLikeIds);
	}

	[Fact]
	public async Task GetByIdRangeAsync_ShouldCallTheFluentToListAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByIdRangeAsync(PostCommentLikeIds, _include, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneToListAsync(PostCommentLikeIds, CancellationToken);
	}
}
