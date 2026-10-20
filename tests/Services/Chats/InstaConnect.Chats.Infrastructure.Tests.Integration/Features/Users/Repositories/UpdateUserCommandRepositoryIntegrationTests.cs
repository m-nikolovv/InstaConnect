using InstaConnect.Chats.Tests.Features.Users.Assertions;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.Users.Repositories;

public class UpdateUserCommandRepositoryIntegrationTests : BaseUserInfrastructureCommandIntegrationTest
{
	public UpdateUserCommandRepositoryIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
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
		var updatedUser = UserBuilderFactory.Create().WithId(UserId).Build();

		// Act
		await Repository.UpdateAsync(updatedUser, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldSatisfy(updatedUser);
	}
}
