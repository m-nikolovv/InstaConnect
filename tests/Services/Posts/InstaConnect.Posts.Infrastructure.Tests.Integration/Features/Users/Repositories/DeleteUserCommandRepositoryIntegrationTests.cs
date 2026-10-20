namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.Users.Repositories;

public class DeleteUserCommandRepositoryIntegrationTests : BaseUserInfrastructureCommandIntegrationTest
{
	public DeleteUserCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUser_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(User, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}
}
