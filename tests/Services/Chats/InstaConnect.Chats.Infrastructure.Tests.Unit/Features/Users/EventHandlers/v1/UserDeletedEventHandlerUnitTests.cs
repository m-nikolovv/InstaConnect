using InstaConnect.Chats.Infrastructure.Features.Users.EventHandlers;
using InstaConnect.Chats.Infrastructure.Tests.Features.Users.Builders;
using InstaConnect.Common.Infrastructure.Tests.Features.Utilities;
using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.Users.EventHandlers.v1;

public class UserDeletedEventHandlerUnitTests : BaseUserInfrastructureEventHandlerUnitTest
{
	private readonly UserDeletedEventRequestBuilderFactory _requestBuilderFactory;
	private readonly UserDeletedEventRequestBuilder _requestBuilder;
	private readonly UserDeletedEventRequest _request;

	private readonly UserDeletedEventHandler _handler;

	public UserDeletedEventHandlerUnitTests()
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
