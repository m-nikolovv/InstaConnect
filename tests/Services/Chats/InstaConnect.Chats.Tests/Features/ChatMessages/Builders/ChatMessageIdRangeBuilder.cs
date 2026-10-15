using InstaConnect.Chats.Domain.Features.ChatMessages.Models.ValueObjects;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.Builders;

public class ChatMessageIdRangeBuilder
{
	private readonly ICollection<ChatMessageIdBuilder> _idBuilders;

	public ChatMessageIdRangeBuilder(ICollection<ChatMessageIdBuilder> idBuilders)
	{
		_idBuilders = idBuilders;
	}

	public ChatMessageIdRangeBuilder WithParticipantOneId(IStringTransformer transformer)
	{
		foreach (var idBuilder in _idBuilders)
		{
			idBuilder.WithParticipantOneId(transformer);
		}

		return this;
	}

	public ChatMessageIdRangeBuilder WithParticipantTwoId(IStringTransformer transformer)
	{
		foreach (var idBuilder in _idBuilders)
		{
			idBuilder.WithParticipantTwoId(transformer);
		}

		return this;
	}

	public ChatMessageIdRangeBuilder WithMessageId(IStringTransformer transformer)
	{
		foreach (var idBuilder in _idBuilders)
		{
			idBuilder.WithMessageId(transformer);
		}

		return this;
	}

	public ICollection<ChatMessageId> Build()
	{
		return [.. _idBuilders.Select(idBuilder => idBuilder.Build())];
	}
}
