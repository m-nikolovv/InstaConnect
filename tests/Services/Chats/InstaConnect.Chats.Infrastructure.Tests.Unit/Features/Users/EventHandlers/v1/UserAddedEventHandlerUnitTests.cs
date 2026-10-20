using InstaConnect.Chats.Infrastructure.Features.Users.EventHandlers;
using InstaConnect.Chats.Infrastructure.Tests.Features.Users.Builders;
using InstaConnect.Common.Infrastructure.Tests.Features.Utilities;
using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.Users.EventHandlers.v1;

public class UserAddedEventHandlerUnitTests : BaseUserInfrastructureEventHandlerUnitTest
{
	private readonly UserAddedEventRequestBuilderFactory _requestBuilderFactory;
	private readonly UserAddedEventRequestBuilder _requestBuilder;
	private readonly UserAddedEventRequest _request;

	private readonly UserAddedEventHandler _handler;

	public UserAddedEventHandlerUnitTests()
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
