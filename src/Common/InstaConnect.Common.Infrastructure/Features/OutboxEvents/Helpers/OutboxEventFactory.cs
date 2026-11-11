using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Domain.Features.Guids.Abstractions;
using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Events.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Events.Utilities;
using InstaConnect.Common.Infrastructure.Features.Jsons.Abstractions;
using InstaConnect.Common.Infrastructure.Features.OutboxEvents.Abstractions;
using InstaConnect.Common.Infrastructure.Features.OutboxEvents.Models.Entities;
using InstaConnect.Common.Infrastructure.Features.OutboxEvents.Models;

using Microsoft.Extensions.Options;

namespace InstaConnect.Common.Infrastructure.Features.OutboxEvents.Helpers;

internal class OutboxEventFactory : IOutboxEventFactory
{
	private readonly IGuidProvider _guidProvider;
	private readonly IJsonConverter _jsonConverter;
	private readonly IDateTimeProvider _dateTimeProvider;
	private readonly OutboxEventOptions _outboxEventOptions;
	private readonly IEventKeySelectorProvider _eventKeySelectorProvider;

	public OutboxEventFactory(
		IGuidProvider guidProvider,
		IJsonConverter jsonConverter,
		IDateTimeProvider dateTimeProvider,
		IOptions<OutboxEventOptions> outboxEventOptions,
		IEventKeySelectorProvider eventKeySelectorProvider)
	{
		_guidProvider = guidProvider;
		_jsonConverter = jsonConverter;
		_dateTimeProvider = dateTimeProvider;
		_outboxEventOptions = outboxEventOptions.Value;
		_eventKeySelectorProvider = eventKeySelectorProvider;
	}

	public OutboxEvent Create<TEvent>(TEvent message)
		where TEvent : class, IEventRequest
	{
		var id = _guidProvider.NewStringGuid();
		var topic = EventUtilities.GetName<TEvent>();
		var key = _eventKeySelectorProvider.GetKeySelector<TEvent>()(message);
		var payload = _jsonConverter.Serialize(message);
		var expiresAt = _dateTimeProvider.GetOffsetUtcNow(_outboxEventOptions.LifetimeSeconds);
		var utcNow = _dateTimeProvider.GetOffsetUtcNow();
		var outboxEvent = new OutboxEvent(
			new(id),
			topic,
			key,
			payload,
			expiresAt,
			utcNow);

		return outboxEvent;
	}

	public ICollection<OutboxEvent> CreateRange<TEvent>(ICollection<TEvent> messages)
		where TEvent : class, IEventRequest
	{
		return [.. messages.Select(Create)];
	}
}
