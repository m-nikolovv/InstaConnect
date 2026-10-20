using InstaConnect.Posts.Tests.Features.PostComments.Abstractions;
using InstaConnect.Posts.Tests.Features.PostComments.Extensions;

namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostComments.Utilities;

public abstract class BasePostCommentApplicationCommandIntegrationTest : BasePostCommentWebTest
{
	protected IApplicationSender Sender { get; }

	protected IPostCommentEventClient CommentEventClient { get; }

	protected BasePostCommentApplicationCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
		CommentEventClient = webApplicationFactory.CreateCommentEventClient();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddAsync(Post, CancellationToken);
		await OnInitializeAsync();
		await CommentEventClient.StartAsync(CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await CommentEventClient.StopAsync(CancellationToken);
	}
}
