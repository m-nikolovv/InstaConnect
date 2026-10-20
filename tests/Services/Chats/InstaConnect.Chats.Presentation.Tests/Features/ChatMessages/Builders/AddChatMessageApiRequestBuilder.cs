using InstaConnect.Chats.Tests.Features.ChatMessageImages.Utilities;
using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Builders;

public class AddChatMessageApiRequestBuilder
{
	private string _participantOneId;
	private string _participantTwoId;
	private string _content;
	private ICollection<IFormFile> _images;

	public AddChatMessageApiRequestBuilder(Chat chat, int numberOfImages)
	{
		_participantOneId = chat.Id.ParticipantOneId.Id;
		_participantTwoId = chat.Id.ParticipantTwoId.Id;
		_content = ChatMessageDataFaker.GetContent();
		_images = ChatMessageImageDataFaker.GetImages(numberOfImages);
	}

	public AddChatMessageApiRequestBuilder WithParticipantOneId(UserId participantOneId, IStringTransformer? transformer = null)
	{
		_participantOneId = transformer.TryTransform(participantOneId.Id);

		return this;
	}

	public AddChatMessageApiRequestBuilder WithParticipantOneId(IStringTransformer transformer)
	{
		_participantOneId = transformer.Transform(_participantOneId);

		return this;
	}

	public AddChatMessageApiRequestBuilder WithParticipantTwoId(UserId participantTwoId, IStringTransformer? transformer = null)
	{
		_participantTwoId = transformer.TryTransform(participantTwoId.Id);

		return this;
	}

	public AddChatMessageApiRequestBuilder WithParticipantTwoId(IStringTransformer transformer)
	{
		_participantTwoId = transformer.Transform(_participantTwoId);

		return this;
	}

	public AddChatMessageApiRequestBuilder WithContent(IStringTransformer transformer)
	{
		_content = transformer.Transform(_content);

		return this;
	}

	public AddChatMessageApiRequestBuilder WithImages(IFormFileCollectionTransformer transformer)
	{
		_images = transformer.Transform(_images);

		return this;
	}

	public AddChatMessageApiRequest Build()
	{
		return new(_participantOneId, _participantTwoId, new(_content, _images));
	}
}
