using InstaConnect.Identity.Tests.Features.Users.Assertions;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.Users.Repositories;

public class AddUserCommandRepositoryIntegrationTests : BaseUserInfrastructureCommandIntegrationTest
{
	public AddUserCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task DisposeAsync()
	{
		await ServiceScope.DisposeInsertAsync(User, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldAddUser_WhenCommandIsValid()
	{
		// Act
		await Repository.AddAsync(User, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldSatisfy(User);
	}
}
