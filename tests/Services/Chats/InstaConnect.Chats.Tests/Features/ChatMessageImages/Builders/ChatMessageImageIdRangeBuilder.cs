namespace InstaConnect.Chats.Tests.Features.ChatMessageImages.Builders;

public class ChatMessageImageIdRangeBuilder
{
	private readonly ICollection<ChatMessageImageIdBuilder> _idBuilders;

	public ChatMessageImageIdRangeBuilder(ICollection<ChatMessageImageIdBuilder> idBuilders)
	{
		_idBuilders = idBuilders;
	}

	public ChatMessageImageIdRangeBuilder WithParticipantOneId(IStringTransformer transformer)
	{
		foreach (var idBuilder in _idBuilders)
		{
			idBuilder.WithParticipantOneId(transformer);
		}

		return this;
	}

	public ChatMessageImageIdRangeBuilder WithParticipantTwoId(IStringTransformer transformer)
	{
		foreach (var idBuilder in _idBuilders)
		{
			idBuilder.WithParticipantTwoId(transformer);
		}

		return this;
	}

	public ChatMessageImageIdRangeBuilder WithMessageId(IStringTransformer transformer)
	{
		foreach (var idBuilder in _idBuilders)
		{
			idBuilder.WithMessageId(transformer);
		}

		return this;
	}

	public ChatMessageImageIdRangeBuilder WithImageId(IStringTransformer transformer)
	{
		foreach (var idBuilder in _idBuilders)
		{
			idBuilder.WithImageId(transformer);
		}

		return this;
	}

	public ICollection<ChatMessageImageId> Build()
	{
		return [.. _idBuilders.Select(idBuilder => idBuilder.Build())];
	}
}
