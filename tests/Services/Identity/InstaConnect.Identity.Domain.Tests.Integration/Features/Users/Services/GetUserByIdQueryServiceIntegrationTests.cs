using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Identity.Domain.Features.Users.Models.Requests;
using InstaConnect.Identity.Domain.Tests.Features.Users.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.Users.Builders;
using InstaConnect.Identity.Domain.Tests.Integration.Features.Users.Utilities;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Integration.Features.Users.Services;

public class GetUserByIdQueryServiceIntegrationTests : BaseUserDomainQueryIntegrationTest
{
	private readonly GetUserByIdQueryBuilderFactory _queryBuilderFactory;
	private readonly GetUserByIdQueryBuilder _queryBuilder;
	private readonly GetUserByIdQuery _query;

	public GetUserByIdQueryServiceIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(User);
		_query = _queryBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await Service.ShouldThrowUserNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Service.GetByIdAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(_query, User);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.GetByIdAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, User);
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Service.GetByIdAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(query, User);
	}
}
