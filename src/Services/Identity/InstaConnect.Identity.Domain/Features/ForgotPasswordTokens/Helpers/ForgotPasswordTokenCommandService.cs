using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Exceptions;
using InstaConnect.Identity.Events.Features.ForgotPasswordTokens;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Helpers;

internal class ForgotPasswordTokenCommandService : IForgotPasswordTokenCommandService
{
	private readonly IApplicationMapper _mapper;
	private readonly IPasswordHasher _passwordHasher;
	private readonly IEventPublisher _eventPublisher;
	private readonly IUserCommandRepository _repository;
	private readonly IDateTimeProvider _dateTimeProvider;
	private readonly IUserIncludeBuilderFactory _includeBuilderFactory;
	private readonly IForgotPasswordTokenFactory _forgotPasswordTokenFactory;
	private readonly IForgotPasswordTokenEmailSender _forgotPasswordTokenEmailSender;
	private readonly IForgotPasswordTokenCommandRepository _forgotPasswordTokenRepository;

	public ForgotPasswordTokenCommandService(
		IApplicationMapper mapper,
		IPasswordHasher passwordHasher,
		IEventPublisher eventPublisher,
		IUserCommandRepository repository,
		IDateTimeProvider dateTimeProvider,
		IUserIncludeBuilderFactory includeBuilderFactory,
		IForgotPasswordTokenFactory forgotPasswordTokenFactory,
		IForgotPasswordTokenEmailSender forgotPasswordTokenEmailSender,
		IForgotPasswordTokenCommandRepository forgotPasswordTokenRepository)
	{
		_mapper = mapper;
		_passwordHasher = passwordHasher;
		_eventPublisher = eventPublisher;
		_repository = repository;
		_dateTimeProvider = dateTimeProvider;
		_includeBuilderFactory = includeBuilderFactory;
		_forgotPasswordTokenFactory = forgotPasswordTokenFactory;
		_forgotPasswordTokenEmailSender = forgotPasswordTokenEmailSender;
		_forgotPasswordTokenRepository = forgotPasswordTokenRepository;
	}

	public async Task<ForgotPasswordTokenId> AddAsync(AddForgotPasswordTokenCommand command, CancellationToken cancellationToken)
	{
		var user = await _repository.GetByNameAsync(command.Name, cancellationToken);

		if (user == null)
		{
			throw new UserNameNotFoundException(command.Name);
		}

		var newForgotPasswordToken = _forgotPasswordTokenFactory.Create(user.Id).AddUser(user);
		await _forgotPasswordTokenRepository.AddAsync(newForgotPasswordToken, cancellationToken);

		await _eventPublisher.PublishAsync(
			_mapper.Map<ForgotPasswordTokenAddedEventRequest>(newForgotPasswordToken), cancellationToken);

		await _forgotPasswordTokenEmailSender.SendAsync(newForgotPasswordToken, cancellationToken);

		return newForgotPasswordToken.Id;
	}

	public async Task VerifyAsync(VerifyForgotPasswordTokenCommand command, CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithForgotPasswordTokens().Build();
		var user = await _repository.GetByIdAsync(command.Id.Id, include, cancellationToken);

		if (user == null)
		{
			throw new UserNotFoundException(command.Id.Id);
		}

		var forgotPasswordToken = await _forgotPasswordTokenRepository.GetByIdAsync(command.Id, cancellationToken);

		if (forgotPasswordToken == null)
		{
			throw new ForgotPasswordTokenNotFoundException(command.Id);
		}

		if (forgotPasswordToken.HasExpired(_dateTimeProvider.GetOffsetUtcNow()))
		{
			throw new ForgotPasswordTokenExpiredException(command.Id);
		}

		await _forgotPasswordTokenRepository.DeleteRangeAsync(user.ForgotPasswordTokens, cancellationToken);

		await _eventPublisher.PublishRangeAsync(
			_mapper.Map<ICollection<ForgotPasswordTokenDeletedEventRequest>>(user), cancellationToken);

		user.UpdatePasswordHash(_passwordHasher.Hash(command.Password));
		await _repository.UpdateAsync(user, cancellationToken);
	}
}
