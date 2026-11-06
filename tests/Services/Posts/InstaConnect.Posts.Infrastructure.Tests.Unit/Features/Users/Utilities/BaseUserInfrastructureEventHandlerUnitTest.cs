using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.Common.Extensions;
using InstaConnect.Posts.Tests.Features.Common.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.Users.Utilities;

public abstract class BaseUserInfrastructureEventHandlerUnitTest : BasePostsCommandTest
{
	protected IApplicationSender Sender { get; }

	protected IApplicationMapper Mapper { get; }

	protected BaseUserInfrastructureEventHandlerUnitTest()
	{
		Sender = MockFactory.CreateApplicationSender();
		Mapper = MockFactory.CreateMapper(PostsInfrastructureReference.Assembly);
	}
}
