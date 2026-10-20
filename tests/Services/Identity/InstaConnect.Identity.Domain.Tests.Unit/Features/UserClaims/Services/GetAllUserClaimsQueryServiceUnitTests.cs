using InstaConnect.Identity.Domain.Features.UserClaims.Helpers;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Requests;
using InstaConnect.Identity.Domain.Tests.Features.UserClaims.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.UserClaims.Builders;
using InstaConnect.Identity.Domain.Tests.Unit.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Unit.Features.UserClaims.Services;

public class GetAllUserClaimsQueryServiceUnitTests : BaseUserClaimDomainQueryUnitTest
{
	private readonly GetAllUserClaimsQueryBuilderFactory _queryBuilderFactory;
	private readonly GetAllUserClaimsQueryBuilder _queryBuilder;
	private readonly GetAllUserClaimsQuery _query;

	private readonly UserClaimQueryService _service;

	public GetAllUserClaimsQueryServiceUnitTests()
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(UserClaim);
		_query = _queryBuilder.Build();

		_service = new(Repository, ClaimRepository, CollectionResponseFactory);

		Repository.SetupGetByIdAsync(_query, User, CancellationToken);
		ClaimRepository.SetupGetAllAsync(_query, UserClaims, CancellationToken);
		ClaimRepository.SetupGetTotalCountAsync(_query, UserClaims, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		Repository.RemoveGetByIdAsync(_query, User, CancellationToken);

		// Assert
		await _service.ShouldThrowUserNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(_query, User, UserClaims);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheRepositoryGetByIdAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetByIdAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheClaimRepositoryGetAllAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		await ClaimRepository.ShouldHaveReceivedOneGetAllAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheClaimRepositoryGetTotalCountAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		await ClaimRepository.ShouldHaveReceivedOneGetTotalCountAsync(_query, CancellationToken);
	}
}
