using InstaConnect.Chats.Domain.Features.Chats.Models.ValueObjects;

namespace InstaConnect.Chats.Tests.Features.Chats.Builders;

public class ChatIdRangeBuilder
{
	private readonly ICollection<ChatIdBuilder> _idBuilders;

	public ChatIdRangeBuilder(ICollection<ChatIdBuilder> idBuilders)
	{
		_idBuilders = idBuilders;
	}

	public ChatIdRangeBuilder WithParticipantOneId(IStringTransformer transformer)
	{
		foreach (var idBuilder in _idBuilders)
		{
			idBuilder.WithParticipantOneId(transformer);
		}

		return this;
	}

	public ChatIdRangeBuilder WithParticipantTwoId(IStringTransformer transformer)
	{
		foreach (var idBuilder in _idBuilders)
		{
			idBuilder.WithParticipantTwoId(transformer);
		}

		return this;
	}

	public ICollection<ChatId> Build()
	{
		return [.. _idBuilders.Select(idBuilder => idBuilder.Build())];
	}
}
