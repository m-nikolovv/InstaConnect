namespace InstaConnect.Chats.Domain.Features.Users.Helpers;

public class UserIncludeBuilder
{
	private readonly ICollection<ChatsIncludeDescriptor> _descriptors;
	private readonly IUserIncludeDescriptorFactory _descriptorsFactory;

	public UserIncludeBuilder(
		ICollection<ChatsIncludeDescriptor> descriptors,
		IUserIncludeDescriptorFactory descriptorsFactory)
	{
		_descriptors = descriptors;
		_descriptorsFactory = descriptorsFactory;
	}

	public UserIncludeBuilder WithChats()
	{
		_descriptors.Add(_descriptorsFactory.CreateChats());

		return this;
	}

	public UserIncludeBuilder WithChats(ChatInclude include)
	{
		_descriptors.Add(_descriptorsFactory.CreateChats());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public UserIncludeBuilder WithChatMessages()
	{
		_descriptors.Add(_descriptorsFactory.CreateChatMessages());

		return this;
	}

	public UserIncludeBuilder WithChatMessages(ChatMessageInclude include)
	{
		_descriptors.Add(_descriptorsFactory.CreateChatMessages());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public UserInclude Build()
	{
		return new(_descriptors);
	}
}
