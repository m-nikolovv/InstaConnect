namespace InstaConnect.Chats.Domain.Features.Users.Helpers;

public class SenderIncludeBuilder
{
	private readonly ICollection<ChatsIncludeDescriptor> _descriptors;
	private readonly ISenderIncludeDescriptorFactory _descriptorsFactory;

	public SenderIncludeBuilder(
		ICollection<ChatsIncludeDescriptor> descriptors,
		ISenderIncludeDescriptorFactory descriptorsFactory)
	{
		_descriptors = descriptors;
		_descriptorsFactory = descriptorsFactory;
	}

	public SenderIncludeBuilder WithChats()
	{
		_descriptors.Add(_descriptorsFactory.CreateChats());

		return this;
	}

	public SenderIncludeBuilder WithChats(ChatInclude include)
	{
		_descriptors.Add(_descriptorsFactory.CreateChats());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public SenderIncludeBuilder WithChatMessages()
	{
		_descriptors.Add(_descriptorsFactory.CreateChatMessages());

		return this;
	}

	public SenderIncludeBuilder WithChatMessages(ChatMessageInclude include)
	{
		_descriptors.Add(_descriptorsFactory.CreateChatMessages());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public SenderInclude Build()
	{
		return new(_descriptors);
	}
}
