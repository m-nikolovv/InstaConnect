namespace InstaConnect.Chats.Domain.Features.Chats.Helpers;

public class ChatIncludeBuilder
{
	private readonly ICollection<ChatsIncludeDescriptor> _descriptors;
	private readonly IChatIncludeDescriptorFactory _descriptorFactory;

	internal ChatIncludeBuilder(
		ICollection<ChatsIncludeDescriptor> descriptors,
		IChatIncludeDescriptorFactory descriptorFactory)
	{
		_descriptors = descriptors;
		_descriptorFactory = descriptorFactory;
	}

	public ChatIncludeBuilder WithParticipantOne()
	{
		_descriptors.Add(_descriptorFactory.CreateParticipantOne());

		return this;
	}

	public ChatIncludeBuilder WithParticipantOne(ParticipantOneInclude include)
	{
		_descriptors.Add(_descriptorFactory.CreateParticipantOne());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public ChatIncludeBuilder WithParticipantTwo()
	{
		_descriptors.Add(_descriptorFactory.CreateParticipantTwo());

		return this;
	}
	public ChatIncludeBuilder WithParticipantTwo(ParticipantTwoInclude include)
	{
		_descriptors.Add(_descriptorFactory.CreateParticipantTwo());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public ChatInclude Build()
	{
		return new(_descriptors);
	}
}
