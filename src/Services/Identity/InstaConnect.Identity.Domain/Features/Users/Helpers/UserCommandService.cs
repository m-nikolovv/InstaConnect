using InstaConnect.Common.Domain.Features.Images.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;

namespace InstaConnect.Identity.Domain.Features.Users.Helpers;

internal class UserCommandService : IUserCommandService
{
	private readonly IUserFactory _factory;
	private readonly IApplicationMapper _mapper;
	private readonly IImageHandler _imageHandler;
	private readonly IEventPublisher _eventPublisher;
	private readonly IUserCommandRepository _repository;
	private readonly IDateTimeProvider _dateTimeProvider;
	private readonly IUserIncludeBuilderFactory _includeBuilderFactory;
	private readonly IEmailConfirmationTokenFactory _emailConfirmationTokenFactory;
	private readonly IEmailConfirmationTokenEmailSender _emailConfirmationTokenEmailSender;
	private readonly IEmailConfirmationTokenCommandRepository _emailConfirmationTokenRepository;

	public UserCommandService(
		IUserFactory factory,
		IApplicationMapper mapper,
		IImageHandler imageHandler,
		IEventPublisher eventPublisher,
		IUserCommandRepository repository,
		IDateTimeProvider dateTimeProvider,
		IUserIncludeBuilderFactory includeBuilderFactory,
		IEmailConfirmationTokenFactory emailConfirmationTokenFactory,
		IEmailConfirmationTokenEmailSender emailConfirmationTokenEmailSender,
		IEmailConfirmationTokenCommandRepository emailConfirmationTokenRepository)
	{
		_factory = factory;
		_mapper = mapper;
		_imageHandler = imageHandler;
		_eventPublisher = eventPublisher;
		_repository = repository;
		_dateTimeProvider = dateTimeProvider;
		_includeBuilderFactory = includeBuilderFactory;
		_emailConfirmationTokenFactory = emailConfirmationTokenFactory;
		_emailConfirmationTokenEmailSender = emailConfirmationTokenEmailSender;
		_emailConfirmationTokenRepository = emailConfirmationTokenRepository;
	}

	public async Task<UserId> AddAsync(AddUserCommand command, CancellationToken cancellationToken)
	{
		var emailIsNotUnique = !await _repository.IsEmailUniqueAsync(command.Email, cancellationToken);

		if (emailIsNotUnique)
		{
			throw new UserEmailAlreadyTakenException(command.Email);
		}

		var nameIsNotUnique = !await _repository.IsNameUniqueAsync(command.Name, cancellationToken);

		if (nameIsNotUnique)
		{
			throw new UserNameAlreadyTakenException(command.Name);
		}

		var newUser = _factory.Create(
			command.Name, command.FirstName, command.LastName, command.Email, command.Password);

		if (command.ProfileImage != null)
		{
			newUser.UpdateProfileImage(await _imageHandler.UploadAsync(command.ProfileImage, cancellationToken));
		}

		await _repository.AddAsync(newUser, cancellationToken);

		await _eventPublisher.PublishAsync(
			_mapper.Map<UserAddedEventRequest>(newUser), cancellationToken);

		var newEmailConfirmationToken = _emailConfirmationTokenFactory.Create(newUser.Id).AddUser(newUser);
		await _emailConfirmationTokenRepository.AddAsync(newEmailConfirmationToken, cancellationToken);

		await _eventPublisher.PublishAsync(
			_mapper.Map<EmailConfirmationTokenAddedEventRequest>(newEmailConfirmationToken), cancellationToken);

		await _emailConfirmationTokenEmailSender.SendAsync(newEmailConfirmationToken, cancellationToken);

		return newUser.Id;
	}

	public async Task<UserId> UpdateAsync(UpdateUserCommand command, CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithEmailConfirmationTokens().Build();
		var user = await _repository.GetByIdAsync(command.Id, include, cancellationToken);

		if (user == null)
		{
			throw new UserNotFoundException(command.Id);
		}

		var nameIsNotUnique = !await _repository.IsNameUniqueAsync(command.Name, cancellationToken);

		if (user.Name.IsNot(command.Name) && nameIsNotUnique)
		{
			throw new UserNameAlreadyTakenException(command.Name);
		}

		var emailIsNotUnique = !await _repository.IsEmailUniqueAsync(command.Email, cancellationToken);

		if (user.Email.IsNot(command.Email) && emailIsNotUnique)
		{
			throw new UserEmailAlreadyTakenException(command.Email);
		}

		user.Update(command.FirstName, command.LastName, command.Name, _dateTimeProvider.GetOffsetUtcNow());

		if (command.ProfileImage != null)
		{
			user.UpdateProfileImage(await _imageHandler.UploadAsync(command.ProfileImage, cancellationToken));
		}

		if (user.Email.IsNot(command.Email))
		{
			user.UpdateEmail(command.Email);

			await _emailConfirmationTokenRepository.DeleteRangeAsync(user.EmailConfirmationTokens, cancellationToken);

			await _eventPublisher.PublishAsync(
				_mapper.Map<ICollection<EmailConfirmationTokenDeletedEventRequest>>(user), cancellationToken);
		}

		await _repository.UpdateAsync(user, cancellationToken);

		await _eventPublisher.PublishAsync(
			_mapper.Map<UserUpdatedEventRequest>(user), cancellationToken);

		return user.Id;
	}

	public async Task DeleteAsync(DeleteUserCommand command, CancellationToken cancellationToken)
	{
		var user = await _repository.GetByIdAsync(command.Id, cancellationToken);

		if (user == null)
		{
			throw new UserNotFoundException(command.Id);
		}

		await _repository.DeleteAsync(user, cancellationToken);

		await _eventPublisher.PublishAsync(
			_mapper.Map<UserDeletedEventRequest>(user), cancellationToken);
	}
}
