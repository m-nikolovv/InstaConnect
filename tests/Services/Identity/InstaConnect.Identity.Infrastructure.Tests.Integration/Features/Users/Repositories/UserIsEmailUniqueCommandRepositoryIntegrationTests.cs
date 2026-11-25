using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Common.Infrastructure.Tests.Features.Builders;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Email;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.Users.Repositories;

public class UserIsEmailUniqueCommandRepositoryIntegrationTests : BaseUserInfrastructureCommandIntegrationTest
{
	private readonly EmailBuilderFactory _emailBuilderFactory;
	private readonly EmailBuilder _emailBuilder;
	private readonly Email _email;

	public UserIsEmailUniqueCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_emailBuilderFactory = new();
		_emailBuilder = _emailBuilderFactory.Create(User.Email);
		_email = _emailBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
	}

	[Fact]
	public async Task IsEmailUniqueAsync_ShouldReturnNull_WhenEmailIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		var response = await Repository.IsEmailUniqueAsync(_email, CancellationToken);
		var user = await ServiceScope.GetByEmailAsync(_email, CancellationToken);

		// Assert
		response.ShouldSatisfy(_email, user);
	}

	[Fact]
	public async Task IsEmailUniqueAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.IsEmailUniqueAsync(_email, CancellationToken);
		var user = await ServiceScope.GetByEmailAsync(_email, CancellationToken);

		// Assert
		response.ShouldSatisfy(_email, user);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task IsEmailUniqueAsync_ShouldReturnResponse_WhenCommandAndEmailAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var email = _emailBuilder.WithEmail(transformer).Build();

		// Act
		var response = await Repository.IsEmailUniqueAsync(email, CancellationToken);
		var user = await ServiceScope.GetByEmailAsync(_email, CancellationToken);

		// Assert
		response.ShouldSatisfy(email, user);
	}
}
