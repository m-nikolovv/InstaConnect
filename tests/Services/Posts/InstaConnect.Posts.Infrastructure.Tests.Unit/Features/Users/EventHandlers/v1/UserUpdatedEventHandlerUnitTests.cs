using InstaConnect.Common.Infrastructure.Tests.Features.Utilities;
using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Posts.Infrastructure.Features.Users.EventHandlers;
using InstaConnect.Posts.Infrastructure.Tests.Features.Users.Builders;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.Users.EventHandlers.v1;

public class UserUpdatedEventHandlerUnitTests : BaseUserInfrastructureEventHandlerUnitTest
{
	private readonly UserUpdatedEventRequestBuilderFactory _requestBuilderFactory;
	private readonly UserUpdatedEventRequestBuilder _requestBuilder;
	private readonly UserUpdatedEventRequest _request;

	private readonly UserUpdatedEventHandler _handler;

	public UserUpdatedEventHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, Sender);
	}

	[Fact]
	public async Task Consume_ShouldCallTheSenderSendAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Consume(_request, CancellationToken);

		// Assert
		await Sender.ShouldHaveReceivedOneSendAsync(_request, CancellationToken);
	}
}
