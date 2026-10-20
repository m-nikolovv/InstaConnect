namespace InstaConnect.Chats.Domain.Features.Users.Helpers;

public class ParticipantTwoIncludeBuilder
{
	private readonly ICollection<ChatsIncludeDescriptor> _descriptors;
	private readonly IParticipantTwoIncludeDescriptorFactory _descriptorsFactory;

	public ParticipantTwoIncludeBuilder(
		ICollection<ChatsIncludeDescriptor> descriptors,
		IParticipantTwoIncludeDescriptorFactory descriptorsFactory)
	{
		_descriptors = descriptors;
		_descriptorsFactory = descriptorsFactory;
	}

	public ParticipantTwoIncludeBuilder WithChats()
	{
		_descriptors.Add(_descriptorsFactory.CreateChats());

		return this;
	}

	public ParticipantTwoIncludeBuilder WithChats(ChatInclude include)
	{
		_descriptors.Add(_descriptorsFactory.CreateChats());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public ParticipantTwoIncludeBuilder WithChatMessages()
	{
		_descriptors.Add(_descriptorsFactory.CreateChatMessages());

		return this;
	}

	public ParticipantTwoIncludeBuilder WithChatMessages(ChatMessageInclude include)
	{
		_descriptors.Add(_descriptorsFactory.CreateChatMessages());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public ParticipantTwoInclude Build()
	{
		return new(_descriptors);
	}
}
