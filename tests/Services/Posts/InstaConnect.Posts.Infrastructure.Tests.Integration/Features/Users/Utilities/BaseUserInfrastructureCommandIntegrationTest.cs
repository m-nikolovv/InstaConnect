using InstaConnect.Posts.Domain.Features.Users.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserInfrastructureCommandIntegrationTest : BaseUserWebTest
{
	protected IUserCommandRepository Repository { get; }

	protected IUserIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseUserInfrastructureCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetUserCommandRepository();
		IncludeBuilderFactory = ServiceScope.GetUserIncludeBuilderFactory();

	}
}
