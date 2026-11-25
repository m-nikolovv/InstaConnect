using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Common.Infrastructure.Tests.Features.Builders;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.Users.Repositories;

public class IsUserNameUniqueCommandRepositoryIntegrationTests : BaseUserInfrastructureCommandIntegrationTest
{
	private readonly NameBuilderFactory _nameBuilderFactory;
	private readonly NameBuilder _nameBuilder;
	private readonly Name _name;

	public IsUserNameUniqueCommandRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_nameBuilderFactory = new();
		_nameBuilder = _nameBuilderFactory.Create(User.Name);
		_name = _nameBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
	}

	[Fact]
	public async Task IsNameUniqueAsync_ShouldReturnNull_WhenNameIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		var response = await Repository.IsNameUniqueAsync(_name, CancellationToken);
		var user = await ServiceScope.GetByNameAsync(_name, CancellationToken);

		// Assert
		response.ShouldSatisfy(_name, user);
	}

	[Fact]
	public async Task IsNameUniqueAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.IsNameUniqueAsync(_name, CancellationToken);
		var user = await ServiceScope.GetByNameAsync(_name, CancellationToken);

		// Assert
		response.ShouldSatisfy(_name, user);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task IsNameUniqueAsync_ShouldReturnResponse_WhenCommandAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var name = _nameBuilder.WithName(transformer).Build();

		// Act
		var response = await Repository.IsNameUniqueAsync(name, CancellationToken);
		var user = await ServiceScope.GetByNameAsync(_name, CancellationToken);

		// Assert
		response.ShouldSatisfy(name, user);
	}
}
