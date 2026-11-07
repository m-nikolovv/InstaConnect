using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Common.Infrastructure.Tests.Features.Builders;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Name;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.Users.Repositories;

public class GetUserByNameCommandRepositoryIntegrationTests : BaseUserInfrastructureCommandIntegrationTest
{
	private readonly NameBuilderFactory _nameBuilderFactory;
	private readonly NameBuilder _nameBuilder;
	private readonly Name _name;

	private readonly UserInclude _include;

	public GetUserByNameCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_nameBuilderFactory = new();
		_nameBuilder = _nameBuilderFactory.Create(User.Name);
		_name = _nameBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithUserClaims().WithRefreshTokens().WithForgotPasswordTokens().WithEmailConfirmationTokens().Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
	}

	[Fact]
	public async Task GetByNameAsync_ShouldReturnNull_WhenNameIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		var response = await Repository.GetByNameAsync(_name, _include, CancellationToken);

		// Assert
		response.ShouldBeNull();
	}

	[Fact]
	public async Task GetByNameAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.GetByNameAsync(_name, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(_name, User);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task GetByNameAsync_ShouldReturnResponse_WhenCommandAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var name = _nameBuilder.WithName(transformer).Build();

		// Act
		var response = await Repository.GetByNameAsync(name, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(name, User);
	}
}
