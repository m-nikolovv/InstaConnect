namespace InstaConnect.Chats.Domain.Features.Users.Helpers;

public class ParticipantOneIncludeBuilder
{
	private readonly ICollection<ChatsIncludeDescriptor> _descriptors;
	private readonly IParticipantOneIncludeDescriptorFactory _descriptorsFactory;

	public ParticipantOneIncludeBuilder(
		ICollection<ChatsIncludeDescriptor> descriptors,
		IParticipantOneIncludeDescriptorFactory descriptorsFactory)
	{
		_descriptors = descriptors;
		_descriptorsFactory = descriptorsFactory;
	}

	public ParticipantOneIncludeBuilder WithChats()
	{
		_descriptors.Add(_descriptorsFactory.CreateChats());

		return this;
	}

	public ParticipantOneIncludeBuilder WithChats(ChatInclude include)
	{
		_descriptors.Add(_descriptorsFactory.CreateChats());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public ParticipantOneIncludeBuilder WithChatMessages()
	{
		_descriptors.Add(_descriptorsFactory.CreateChatMessages());

		return this;
	}

	public ParticipantOneIncludeBuilder WithChatMessages(ChatMessageInclude include)
	{
		_descriptors.Add(_descriptorsFactory.CreateChatMessages());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public ParticipantOneInclude Build()
	{
		return new(_descriptors);
	}
}
