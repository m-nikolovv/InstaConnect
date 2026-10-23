using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Exceptions;
using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Helpers;

internal class EmailConfirmationTokenCommandService : IEmailConfirmationTokenCommandService
{
	private readonly IApplicationMapper _mapper;
	private readonly IEventPublisher _eventPublisher;
	private readonly IUserCommandRepository _repository;
	private readonly IDateTimeProvider _dateTimeProvider;
	private readonly IUserIncludeBuilderFactory _includeBuilderFactory;
	private readonly IEmailConfirmationTokenFactory _emailConfirmationTokenFactory;
	private readonly IEmailConfirmationTokenEmailSender _emailConfirmationTokenEmailSender;
	private readonly IEmailConfirmationTokenCommandRepository _emailConfirmationTokenRepository;

	public EmailConfirmationTokenCommandService(
		IApplicationMapper mapper,
		IEventPublisher eventPublisher,
		IUserCommandRepository repository,
		IDateTimeProvider dateTimeProvider,
		IUserIncludeBuilderFactory includeBuilderFactory,
		IEmailConfirmationTokenFactory emailConfirmationTokenFactory,
		IEmailConfirmationTokenEmailSender emailConfirmationTokenEmailSender,
		IEmailConfirmationTokenCommandRepository emailConfirmationTokenRepository)
	{
		_mapper = mapper;
		_eventPublisher = eventPublisher;
		_repository = repository;
		_dateTimeProvider = dateTimeProvider;
		_includeBuilderFactory = includeBuilderFactory;
		_emailConfirmationTokenFactory = emailConfirmationTokenFactory;
		_emailConfirmationTokenEmailSender = emailConfirmationTokenEmailSender;
		_emailConfirmationTokenRepository = emailConfirmationTokenRepository;
	}

	public async Task<EmailConfirmationTokenId> AddAsync(AddEmailConfirmationTokenCommand command, CancellationToken cancellationToken)
	{
		var user = await _repository.GetByNameAsync(command.Name, cancellationToken);

		if (user == null)
		{
			throw new UserNameNotFoundException(command.Name);
		}

		if (user.IsEmailConfirmed)
		{
			throw new UserNameEmailAlreadyConfirmedException(command.Name);
		}

		var newEmailConfirmationToken = _emailConfirmationTokenFactory.Create(user.Id).AddUser(user);
		await _emailConfirmationTokenRepository.AddAsync(newEmailConfirmationToken, cancellationToken);

		await _eventPublisher.PublishAsync(
			_mapper.Map<EmailConfirmationTokenAddedEventRequest>(newEmailConfirmationToken), cancellationToken);

		await _emailConfirmationTokenEmailSender.SendAsync(newEmailConfirmationToken, cancellationToken);

		return newEmailConfirmationToken.Id;
	}

	public async Task VerifyAsync(VerifyEmailConfirmationTokenCommand command, CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithEmailConfirmationTokens().Build();
		var user = await _repository.GetByIdAsync(command.Id.Id, include, cancellationToken);

		if (user == null)
		{
			throw new UserNotFoundException(command.Id.Id);
		}

		if (user.IsEmailConfirmed)
		{
			throw new UserEmailAlreadyConfirmedException(command.Id.Id);
		}

		var emailConfirmationToken = await _emailConfirmationTokenRepository.GetByIdAsync(command.Id, cancellationToken);

		if (emailConfirmationToken == null)
		{
			throw new EmailConfirmationTokenNotFoundException(command.Id);
		}

		if (emailConfirmationToken.HasExpired(_dateTimeProvider.GetOffsetUtcNow()))
		{
			throw new EmailConfirmationTokenExpiredException(command.Id);
		}

		await _emailConfirmationTokenRepository.DeleteRangeAsync(user.EmailConfirmationTokens, cancellationToken);

		await _eventPublisher.PublishRangeAsync(
			_mapper.Map<ICollection<EmailConfirmationTokenDeletedEventRequest>>(user), cancellationToken);

		user.ConfirmEmail();
		await _repository.UpdateAsync(user, cancellationToken);
	}
}
