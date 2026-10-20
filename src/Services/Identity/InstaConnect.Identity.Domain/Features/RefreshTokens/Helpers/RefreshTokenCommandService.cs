using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Exceptions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Responses;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Helpers;

internal class RefreshTokenCommandService : IRefreshTokenCommandService
{
	private readonly IPasswordHasher _passwordHasher;
	private readonly IUserCommandRepository _repository;
	private readonly IDateTimeProvider _dateTimeProvider;
	private readonly IRefreshTokenFactory _refreshTokenFactory;
	private readonly ISessionTokenGenerator _sessionTokenGenerator;
	private readonly IUserIncludeBuilderFactory _includeBuilderFactory;
	private readonly IRefreshTokenCommandRepository _refreshTokenRepository;

	public RefreshTokenCommandService(
		IPasswordHasher passwordHasher,
		IUserCommandRepository repository,
		IDateTimeProvider dateTimeProvider,
		IRefreshTokenFactory refreshTokenFactory,
		ISessionTokenGenerator sessionTokenGenerator,
		IUserIncludeBuilderFactory includeBuilderFactory,
		IRefreshTokenCommandRepository refreshTokenRepository)
	{
		_passwordHasher = passwordHasher;
		_repository = repository;
		_dateTimeProvider = dateTimeProvider;
		_refreshTokenFactory = refreshTokenFactory;
		_sessionTokenGenerator = sessionTokenGenerator;
		_includeBuilderFactory = includeBuilderFactory;
		_refreshTokenRepository = refreshTokenRepository;
	}

	public async Task<SessionToken> IssueAsync(IssueRefreshTokenCommand command, CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithUserClaims().Build();
		var user = await _repository.GetByNameAsync(command.Name, include, cancellationToken);

		if (user == null)
		{
			throw new UserInvalidDetailsException(command.Name);
		}

		var isMismatch = _passwordHasher.IsMismatch(command.Password, user.PasswordHash);

		if (isMismatch)
		{
			throw new UserInvalidDetailsException(command.Name);
		}

		if (user.IsEmailNotConfirmed)
		{
			throw new UserNameEmailNotConfirmedException(command.Name);
		}

		var newRefreshToken = _refreshTokenFactory.Create(user.Id).AddUser(user);
		await _refreshTokenRepository.AddAsync(newRefreshToken, cancellationToken);

		return _sessionTokenGenerator.Generate(newRefreshToken);
	}

	public async Task<SessionToken> RotateAsync(RotateRefreshTokenCommand command, CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithUserClaims().Build();
		var user = await _repository.GetByIdAsync(command.Id.Id, include, cancellationToken);

		if (user == null)
		{
			throw new UserNotFoundException(command.Id.Id);
		}

		if (user.IsEmailNotConfirmed)
		{
			throw new UserEmailNotConfirmedException(command.Id.Id);
		}

		var refreshToken = await _refreshTokenRepository.GetByIdAsync(command.Id, cancellationToken);

		if (refreshToken == null)
		{
			throw new RefreshTokenNotFoundException(command.Id);
		}

		if (refreshToken.HasExpired(_dateTimeProvider.GetOffsetUtcNow()))
		{
			throw new RefreshTokenExpiredException(command.Id);
		}

		await _refreshTokenRepository.DeleteAsync(refreshToken, cancellationToken);

		var newRefreshToken = _refreshTokenFactory.Create(user.Id).AddUser(user);
		await _refreshTokenRepository.AddAsync(newRefreshToken, cancellationToken);

		return _sessionTokenGenerator.Generate(newRefreshToken);
	}

	public async Task DeleteAsync(DeleteRefreshTokenCommand command, CancellationToken cancellationToken)
	{
		var userNotExists = !await _repository.ExistsByIdAsync(command.Id.Id, cancellationToken);

		if (userNotExists)
		{
			throw new UserNotFoundException(command.Id.Id);
		}

		var refreshToken = await _refreshTokenRepository.GetByIdAsync(command.Id, cancellationToken);

		if (refreshToken == null)
		{
			throw new RefreshTokenNotFoundException(command.Id);
		}

		await _refreshTokenRepository.DeleteAsync(refreshToken, cancellationToken);
	}
}
