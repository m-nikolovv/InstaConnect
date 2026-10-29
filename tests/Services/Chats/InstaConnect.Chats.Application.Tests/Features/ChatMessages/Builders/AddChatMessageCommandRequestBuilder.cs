using InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;
using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Builders;

public class AddChatMessageCommandRequestBuilder
{
	private string _participantOneId;
	private string _participantTwoId;
	private string _content;
	private ICollection<IFormFile> _images;

	public AddChatMessageCommandRequestBuilder(Chat chat)
	{
		_participantOneId = chat.Id.ParticipantOneId.Id;
		_participantTwoId = chat.Id.ParticipantTwoId.Id;
		_content = ChatMessageDataFaker.GetContent();
		_images = ChatMessageImageDataFaker.GetImages();
	}

	public AddChatMessageCommandRequestBuilder WithParticipantOneId(UserId participantOneId, IStringTransformer? transformer = null)
	{
		_participantOneId = transformer.TryTransform(participantOneId.Id);

		return this;
	}

	public AddChatMessageCommandRequestBuilder WithParticipantOneId(IStringTransformer transformer)
	{
		_participantOneId = transformer.Transform(_participantOneId);

		return this;
	}

	public AddChatMessageCommandRequestBuilder WithParticipantTwoId(UserId participantTwoId, IStringTransformer? transformer = null)
	{
		_participantTwoId = transformer.TryTransform(participantTwoId.Id);

		return this;
	}

	public AddChatMessageCommandRequestBuilder WithParticipantTwoId(IStringTransformer transformer)
	{
		_participantTwoId = transformer.Transform(_participantTwoId);

		return this;
	}

	public AddChatMessageCommandRequestBuilder WithContent(IStringTransformer transformer)
	{
		_content = transformer.Transform(_content);

		return this;
	}

	public AddChatMessageCommandRequestBuilder WithImages(IFormFileCollectionTransformer transformer)
	{
		_images = transformer.Transform(_images);

		return this;
	}

	public AddChatMessageCommandRequest Build()
	{
		return new(_participantOneId, _participantTwoId, _content, _images);
	}
}
