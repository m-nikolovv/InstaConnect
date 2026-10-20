using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Identity.Domain.Features.UserClaims.Exceptions;
using InstaConnect.Identity.Events.Features.UserClaims;

namespace InstaConnect.Identity.Domain.Features.UserClaims.Helpers;

internal class UserClaimCommandService : IUserClaimCommandService
{
	private readonly IApplicationMapper _mapper;
	private readonly IEventPublisher _eventPublisher;
	private readonly IUserClaimFactory _claimFactory;
	private readonly IUserCommandRepository _repository;
	private readonly IUserClaimCommandRepository _claimRepository;
	private readonly IUserClaimIncludeBuilderFactory _claimIncludeBuilderFactory;

	public UserClaimCommandService(
		IApplicationMapper mapper,
		IEventPublisher eventPublisher,
		IUserClaimFactory claimFactory,
		IUserCommandRepository repository,
		IUserClaimCommandRepository claimRepository,
		IUserClaimIncludeBuilderFactory claimIncludeBuilderFactory)
	{
		_mapper = mapper;
		_eventPublisher = eventPublisher;
		_claimFactory = claimFactory;
		_repository = repository;
		_claimRepository = claimRepository;
		_claimIncludeBuilderFactory = claimIncludeBuilderFactory;
	}

	public async Task<UserClaimId> AddAsync(AddUserClaimCommand command, CancellationToken cancellationToken)
	{
		var user = await _repository.GetByIdAsync(command.Id, cancellationToken);

		if (user == null)
		{
			throw new UserNotFoundException(command.Id);
		}

		var newUserClaim = _claimFactory.Create(user.Id, command.Claim).AddUser(user);
		var userClaim = await _claimRepository.GetByIdAsync(newUserClaim.Id, cancellationToken);

		if (userClaim != null)
		{
			throw new UserClaimAlreadyExistsException(newUserClaim.Id);
		}

		await _claimRepository.AddAsync(newUserClaim, cancellationToken);

		await _eventPublisher.PublishAsync(
			_mapper.Map<UserClaimAddedEventRequest>(newUserClaim), cancellationToken);

		return newUserClaim.Id;
	}

	public async Task DeleteAsync(DeleteUserClaimCommand command, CancellationToken cancellationToken)
	{
		var userNotExists = !await _repository.ExistsByIdAsync(command.Id.Id, cancellationToken);

		if (userNotExists)
		{
			throw new UserNotFoundException(command.Id.Id);
		}

		var claimInclude = _claimIncludeBuilderFactory.Create().WithUser().Build();
		var userClaim = await _claimRepository.GetByIdAsync(command.Id, claimInclude, cancellationToken);

		if (userClaim == null)
		{
			throw new UserClaimNotFoundException(command.Id);
		}

		await _claimRepository.DeleteAsync(userClaim, cancellationToken);

		await _eventPublisher.PublishAsync(
			_mapper.Map<UserClaimDeletedEventRequest>(userClaim), cancellationToken);
	}
}
