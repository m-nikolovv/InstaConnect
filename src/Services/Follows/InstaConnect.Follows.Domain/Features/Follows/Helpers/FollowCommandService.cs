using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Follows.Domain.Features.Follows.Exceptions;
using InstaConnect.Follows.Domain.Features.Users.Exceptions;
using InstaConnect.Follows.Events.Features.Follows;

namespace InstaConnect.Follows.Domain.Features.Follows.Helpers;

internal class FollowCommandService : IFollowCommandService
{
	private readonly IFollowFactory _factory;
	private readonly IApplicationMapper _mapper;
	private readonly IEventPublisher _eventPublisher;
	private readonly IFollowCommandRepository _repository;
	private readonly IUserCommandRepository _userRepository;
	private readonly IFollowNotificationService _notificationService;
	private readonly IFollowIncludeBuilderFactory _includeBuilderFactory;

	public FollowCommandService(
		IFollowFactory factory,
		IApplicationMapper mapper,
		IEventPublisher eventPublisher,
		IFollowCommandRepository repository,
		IUserCommandRepository userRepository,
		IFollowNotificationService notificationService,
		IFollowIncludeBuilderFactory includeBuilderFactory)
	{
		_factory = factory;
		_mapper = mapper;
		_eventPublisher = eventPublisher;
		_repository = repository;
		_userRepository = userRepository;
		_includeBuilderFactory = includeBuilderFactory;
		_notificationService = notificationService;
	}

	public async Task<FollowId> AddAsync(AddFollowCommand command, CancellationToken cancellationToken)
	{
		var follower = await _userRepository.GetByIdAsync(command.FollowerId, cancellationToken);

		if (follower == null)
		{
			throw new UserNotFoundException(command.FollowerId);
		}

		var following = await _userRepository.GetByIdAsync(command.FollowingId, cancellationToken);

		if (following == null)
		{
			throw new UserNotFoundException(command.FollowingId);
		}

		var newFollow = _factory.Create(follower.Id, following.Id).AddFollower(follower).AddFollowing(following);
		var followExists = await _repository.ExistsByIdAsync(newFollow.Id, cancellationToken);

		if (followExists)
		{
			throw new FollowAlreadyExistsException(newFollow.Id);
		}

		await _repository.AddAsync(newFollow, cancellationToken);

		await _eventPublisher.PublishAsync(
			_mapper.Map<FollowAddedEventRequest>(newFollow), cancellationToken);

		await _notificationService.AddedAsync(
			_mapper.Map<FollowAddedNotificationRequest>(newFollow), cancellationToken);

		return newFollow.Id;
	}

	public async Task DeleteAsync(DeleteFollowCommand command, CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithFollower().WithFollowing().Build();
		var follow = await _repository.GetByIdAsync(command.Id, include, cancellationToken);

		if (follow == null)
		{
			throw new FollowNotFoundException(command.Id);
		}

		await _repository.DeleteAsync(follow, cancellationToken);

		await _eventPublisher.PublishAsync(
			_mapper.Map<FollowDeletedEventRequest>(follow), cancellationToken);
	}
}
