using InstaConnect.Follows.Domain.Features.Follows.Helpers;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Domain.Tests.Features.Follows.Assertions;
using InstaConnect.Follows.Domain.Tests.Features.Follows.Builders;
using InstaConnect.Follows.Domain.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Domain.Tests.Unit.Features.Follows.Utilities;

namespace InstaConnect.Follows.Domain.Tests.Unit.Features.Follows.Services;

public class GetFollowByIdQueryServiceUnitTests : BaseFollowDomainQueryUnitTest
{
	private readonly GetFollowByIdQueryBuilderFactory _queryBuilderFactory;
	private readonly GetFollowByIdQueryBuilder _queryBuilder;
	private readonly GetFollowByIdQuery _query;

	private readonly FollowQueryService _service;

	public GetFollowByIdQueryServiceUnitTests()
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(Follow);
		_query = _queryBuilder.Build();

		_service = new(Repository, UserRepository, CollectionResponseFactory);

		Repository.SetupGetByIdAsync(_query, Follow, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldThrowFollowNotFoundException_WhenFollowNotFound()
	{
		// Arrange
		Repository.RemoveGetByIdAsync(_query, Follow, CancellationToken);

		// Assert
		await _service.ShouldThrowFollowNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _service.GetByIdAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(_query, Follow);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheRepositoryGetByIdAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetByIdAsync(_query, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetByIdAsync(_query, CancellationToken);
	}
}
