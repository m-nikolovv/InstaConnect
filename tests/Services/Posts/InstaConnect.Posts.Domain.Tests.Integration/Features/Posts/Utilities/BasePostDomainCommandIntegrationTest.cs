using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Abstractions;
using InstaConnect.Posts.Tests.Features.Posts.Extensions;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.Posts.Utilities;

public abstract class BasePostDomainCommandIntegrationTest : BasePostWebTest
{
	protected IPostCommandService Service { get; }

	protected IPostEventClient EventClient { get; }

	protected BasePostDomainCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Service = ServiceScope.GetPostCommandService();
		EventClient = webApplicationFactory.CreateEventClient();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await OnInitializeAsync();
		await EventClient.StartAsync(CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await EventClient.StopAsync(CancellationToken);
	}
}
