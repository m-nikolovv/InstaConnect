using InstaConnect.Posts.Infrastructure.Tests.Features.Posts.Builders;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Title;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.Posts.Repositories;

public class GetPostsTotalCountQueryRepositoryIntegrationTests : BasePostInfrastructureQueryIntegrationTest
{
	private readonly PostsFilterQueryBuilderFactory _filterQueryBuilderFactory;
	private readonly PostsFilterQueryBuilder _filterQueryBuilder;
	private readonly PostsFilterQuery _filterQuery;

	public GetPostsTotalCountQueryRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_filterQueryBuilderFactory = new();
		_filterQueryBuilder = _filterQueryBuilderFactory.Create(Post);
		_filterQuery = _filterQueryBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Posts, CancellationToken);
	}

	[Fact]
	public async Task GetTotalCountAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Repository.GetTotalCountAsync(_filterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, Posts);
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameDifferentCaseData]
	public async Task GetTotalCountAsync_ShouldReturnResponse_WhenQueryAndUserNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var filterQuery = _filterQueryBuilder.WithUserName(transformer).Build();

		// Act
		var response = await Repository.GetTotalCountAsync(filterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(filterQuery, Posts);
	}

	[Theory]
	[PostTitleNullData]
	[PostTitleEmptyData]
	[PostTitleDifferentCaseData]
	public async Task GetTotalCountAsync_ShouldReturnResponse_WhenQueryAndTitleAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var filterQuery = _filterQueryBuilder.WithTitle(transformer).Build();

		// Act
		var response = await Repository.GetTotalCountAsync(filterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(filterQuery, Posts);
	}
}
