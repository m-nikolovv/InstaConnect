using InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;
using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Builders;

public class AddChatMessageCommandBuilder
{
	private string _participantOneId;
	private string _participantTwoId;
	private string _content;
	private ICollection<IFormFile> _images;

	public AddChatMessageCommandBuilder(Chat chat)
	{
		_participantOneId = chat.Id.ParticipantOneId.Id;
		_participantTwoId = chat.Id.ParticipantTwoId.Id;
		_content = ChatMessageDataFaker.GetContent();
		_images = ChatMessageImageDataFaker.GetImages();
	}

	public AddChatMessageCommandBuilder WithParticipantOneId(UserId participantOneId, IStringTransformer? transformer = null)
	{
		_participantOneId = transformer.TryTransform(participantOneId.Id);

		return this;
	}

	public AddChatMessageCommandBuilder WithParticipantOneId(IStringTransformer transformer)
	{
		_participantOneId = transformer.Transform(_participantOneId);

		return this;
	}

	public AddChatMessageCommandBuilder WithParticipantTwoId(UserId participantTwoId, IStringTransformer? transformer = null)
	{
		_participantTwoId = transformer.TryTransform(participantTwoId.Id);

		return this;
	}

	public AddChatMessageCommandBuilder WithParticipantTwoId(IStringTransformer transformer)
	{
		_participantTwoId = transformer.Transform(_participantTwoId);

		return this;
	}

	public AddChatMessageCommandBuilder WithContent(IStringTransformer transformer)
	{
		_content = transformer.Transform(_content);

		return this;
	}

	public AddChatMessageCommandBuilder WithImages(IFormFileCollectionTransformer transformer)
	{
		_images = transformer.Transform(_images);

		return this;
	}

	public AddChatMessageCommand Build()
	{
		return new(
			new(
				new(_participantOneId),
				new(_participantTwoId)),
			_content,
			_images);
	}
}
