using InstaConnect.Posts.Domain.Features.Users.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserInfrastructureQueryIntegrationTest : BaseUserWebTest
{
	protected IUserQueryRepository Repository { get; }

	protected BaseUserInfrastructureQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetUserQueryRepository();

	}
}
