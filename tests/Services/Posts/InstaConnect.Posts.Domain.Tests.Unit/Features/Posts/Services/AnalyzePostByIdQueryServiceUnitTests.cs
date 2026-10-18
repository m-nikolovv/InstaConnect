using InstaConnect.Posts.Domain.Features.Posts.Helpers;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Builders;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Tests.Unit.Features.Posts.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.Posts.Services;

public class AnalyzePostByIdQueryServiceUnitTests : BasePostDomainQueryUnitTest
{
	private readonly AnalyzePostByIdQueryBuilderFactory _queryBuilderFactory;
	private readonly AnalyzePostByIdQueryBuilder _queryBuilder;
	private readonly AnalyzePostByIdQuery _query;

	private readonly PostQueryService _service;

	public AnalyzePostByIdQueryServiceUnitTests()
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(Post);
		_query = _queryBuilder.Build();

		_service = new(Analyzer, Repository, UserRepository, CollectionResponseFactory);

		Repository.SetupGetByIdAsync(_query, Post, CancellationToken);
	}

	[Fact]
	public async Task AnalyzeByIdAsync_ShouldThrowPostNotFoundException_WhenIdIsInvalid()
	{
		// Arrange
		Repository.RemoveGetByIdAsync(_query, Post, CancellationToken);

		// Assert
		await _service.ShouldThrowPostNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task AnalyzeByIdAsync_ShouldNotCallTheAnalyzerAnalyzeAsync_WhenIdIsInvalid()
	{
		// Arrange
		Repository.RemoveGetByIdAsync(_query, Post, CancellationToken);

		// Act
		await Record.ExceptionAsync(() => _service.AnalyzeByIdAsync(_query, CancellationToken));

		// Assert
		await Analyzer.ShouldHaveReceivedZeroAnalyzeAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task AnalyzeByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _service.AnalyzeByIdAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(_query, Post);
	}

	[Fact]
	public async Task AnalyzeByIdAsync_ShouldCallTheRepositoryGetByIdAsync_WhenQueryIsValid()
	{
		// Act
		await _service.AnalyzeByIdAsync(_query, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetByIdAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task AnalyzeByIdAsync_ShouldCallTheAnalyzerAnalyzeAsync_WhenQueryIsValid()
	{
		// Act
		await _service.AnalyzeByIdAsync(_query, CancellationToken);

		// Assert
		await Analyzer.ShouldHaveReceivedOneAnalyzeAsync(_query, Post, CancellationToken);
	}
}
