namespace InstaConnect.Chats.Domain.Features.ChatMessages.Helpers;

public class ChatMessageIncludeBuilder
{
	private readonly ICollection<ChatsIncludeDescriptor> _descriptors;
	private readonly IChatMessageIncludeDescriptorFactory _descriptorFactory;

	internal ChatMessageIncludeBuilder(
		ICollection<ChatsIncludeDescriptor> descriptors,
		IChatMessageIncludeDescriptorFactory descriptorFactory)
	{
		_descriptors = descriptors;
		_descriptorFactory = descriptorFactory;
	}

	public ChatMessageIncludeBuilder WithSender()
	{
		_descriptors.Add(_descriptorFactory.CreateSender());

		return this;
	}

	public ChatMessageIncludeBuilder WithSender(SenderInclude include)
	{
		_descriptors.Add(_descriptorFactory.CreateSender());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public ChatMessageIncludeBuilder WithChat()
	{
		_descriptors.Add(_descriptorFactory.CreateChat());

		return this;
	}

	public ChatMessageIncludeBuilder WithChat(ChatInclude include)
	{
		_descriptors.Add(_descriptorFactory.CreateChat());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public ChatMessageIncludeBuilder WithChatMessageImages()
	{
		_descriptors.Add(_descriptorFactory.CreateChatMessageImages());

		return this;
	}

	public ChatMessageInclude Build()
	{
		return new(_descriptors);
	}
}
