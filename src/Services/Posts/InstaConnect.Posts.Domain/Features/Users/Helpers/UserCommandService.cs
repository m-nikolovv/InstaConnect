namespace InstaConnect.Posts.Domain.Features.Users.Helpers;

internal class UserCommandService : IUserCommandService
{
	private readonly IUserFactory _factory;
	private readonly IUserCommandRepository _userRepository;

	public UserCommandService(
		IUserFactory factory,
		IUserCommandRepository userRepository)
	{
		_factory = factory;
		_userRepository = userRepository;
	}

	public async Task<UserId> AddAsync(AddUserCommand command, CancellationToken cancellationToken)
	{
		var userExists = await _userRepository.ExistsByIdAsync(command.Id, cancellationToken);

		if (userExists)
		{
			throw new UserAlreadyExistsException(command.Id);
		}

		var emailIsNotUnique = !await _userRepository.IsEmailUniqueAsync(command.Email, cancellationToken);

		if (emailIsNotUnique)
		{
			throw new UserEmailAlreadyExistsException(command.Email);
		}

		var nameIsNotUnique = !await _userRepository.IsNameUniqueAsync(command.Name, cancellationToken);

		if (nameIsNotUnique)
		{
			throw new UserNameAlreadyExistsException(command.Name);
		}

		var newUser = _factory.Create(
			command.Id,
			command.FirstName,
			command.LastName,
			command.Name,
			command.Email,
			command.ProfileImageUrl,
			command.CreatedAtUtc,
			command.UpdatedAtUtc);

		await _userRepository.AddAsync(newUser, cancellationToken);

		return newUser.Id;
	}

	public async Task<UserId> UpdateAsync(UpdateUserCommand command, CancellationToken cancellationToken)
	{
		var user = await _userRepository.GetByIdAsync(command.Id, cancellationToken);

		if (user == null)
		{
			throw new UserNotFoundException(command.Id);
		}

		var emailIsNotUnique = !await _userRepository.IsEmailUniqueAsync(command.Email, cancellationToken);

		if (user.Email.IsNot(command.Email) && emailIsNotUnique)
		{
			throw new UserEmailAlreadyExistsException(command.Email);
		}

		var nameIsNotUnique = !await _userRepository.IsNameUniqueAsync(command.Name, cancellationToken);

		if (user.Name.IsNot(command.Name) && nameIsNotUnique)
		{
			throw new UserNameAlreadyExistsException(command.Name);
		}

		user.Update(
			command.Email,
			command.FirstName,
			command.LastName,
			command.Name,
			command.ProfileImageUrl,
			command.UpdatedAtUtc);
		await _userRepository.UpdateAsync(user, cancellationToken);

		return user.Id;
	}

	public async Task DeleteAsync(DeleteUserCommand command, CancellationToken cancellationToken)
	{
		var user = await _userRepository.GetByIdAsync(command.Id, cancellationToken);

		if (user == null)
		{
			throw new UserNotFoundException(command.Id);
		}

		await _userRepository.DeleteAsync(user, cancellationToken);
	}
}
