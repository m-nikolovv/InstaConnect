using InstaConnect.Identity.Tests.Features.Users.Assertions;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.Users.Repositories;

public class UpdateUserCommandRepositoryIntegrationTests : BaseUserInfrastructureCommandIntegrationTest
{
	public UpdateUserCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldUpdateUser_WhenCommandIsValid()
	{
		// Arrange
		var updatedUser = UserBuilderFactory.Create(PasswordHasher.Hash(Password)).WithId(UserId).Build();

		// Act
		await Repository.UpdateAsync(updatedUser, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldSatisfy(updatedUser);
	}
}
