using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Posts.Tests.Features.PostImages.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Abstractions;
using InstaConnect.Posts.Tests.Features.Posts.Extensions;

namespace InstaConnect.Posts.Application.Tests.Integration.Features.Posts.Utilities;

public abstract class BasePostApplicationCommandIntegrationTest : BasePostWebTest
{
	protected IApplicationSender Sender { get; }

	protected IPostEventClient EventClient { get; }

	protected BasePostApplicationCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
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
