using InstaConnect.Chats.Domain.Features.Chats.Exceptions;
using InstaConnect.Chats.Domain.Features.Users.Exceptions;
using InstaConnect.Chats.Events.Features.Chats.Models;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Events.Features.Events.Abstractions;

namespace InstaConnect.Chats.Domain.Features.Chats.Helpers;

internal class ChatCommandService : IChatCommandService
{
	private readonly IChatFactory _factory;
	private readonly IApplicationMapper _mapper;
	private readonly IEventPublisher _eventPublisher;
	private readonly IChatCommandRepository _repository;
	private readonly IUserCommandRepository _userRepository;

	public ChatCommandService(
		IChatFactory factory,
		IApplicationMapper mapper,
		IEventPublisher eventPublisher,
		IChatCommandRepository repository,
		IUserCommandRepository userRepository)
	{
		_factory = factory;
		_mapper = mapper;
		_eventPublisher = eventPublisher;
		_repository = repository;
		_userRepository = userRepository;
	}

	public async Task<ChatId> AddAsync(AddChatCommand command, CancellationToken cancellationToken)
	{
		var participantOne = await _userRepository.GetByIdAsync(command.ParticipantOneId, cancellationToken);

		if (participantOne == null)
		{
			throw new UserNotFoundException(command.ParticipantOneId);
		}

		var participantTwo = await _userRepository.GetByIdAsync(command.ParticipantTwoId, cancellationToken);

		if (participantTwo == null)
		{
			throw new UserNotFoundException(command.ParticipantTwoId);
		}

		var newChat = _factory.Create(participantOne.Id, participantTwo.Id).AddParticipantOne(participantOne).AddParticipantTwo(participantTwo);
		var chat = await _repository.GetByIdAsync(newChat.Id, cancellationToken);

		if (chat != null)
		{
			throw new ChatAlreadyExistsException(newChat.Id);
		}

		await _repository.AddAsync(newChat, cancellationToken);

		await _eventPublisher.PublishAsync(
			_mapper.Map<ChatAddedEventRequest>(newChat), cancellationToken);

		return newChat.Id;
	}
}
