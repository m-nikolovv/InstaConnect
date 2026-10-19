using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Helpers;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Builders;
using InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Domain.Tests.Unit.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Unit.Features.EmailConfirmationTokens.Services;

public class AddEmailConfirmationTokenCommandServiceUnitTests : BaseEmailConfirmationTokenDomainCommandUnitTest
{
	private readonly AddEmailConfirmationTokenCommandBuilderFactory _commandBuilderFactory;
	private readonly AddEmailConfirmationTokenCommandBuilder _commandBuilder;
	private readonly AddEmailConfirmationTokenCommand _command;

	private readonly EmailConfirmationTokenCommandService _service;

	public AddEmailConfirmationTokenCommandServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(User);
		_command = _commandBuilder.Build();

		_service = new(
			Mapper,
			EventPublisher,
			Repository,
			DateTimeProvider,
			IncludeBuilderFactory,
			Factory,
			EmailSender,
			EmailConfirmationTokenRepository);

		Repository.SetupGetByNameAsync(_command, User, CancellationToken);
		Factory.SetupCreate(_command, EmailConfirmationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNameNotFoundException_WhenUserNotFound()
	{
		// Arrange
		Repository.RemoveGetByNameAsync(_command, User, CancellationToken);

		// Assert
		await _service.ShouldThrowUserNameNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNameEmailAlreadyConfirmedException_WhenEmailIsConfirmed()
	{
		// Arrange
		var confirmedUser = UserBuilder.WithConfirmedEmail().Build();
		Repository.SetupGetByNameAsync(_command, confirmedUser, CancellationToken);

		// Assert
		await _service.ShouldThrowUserNameEmailAlreadyConfirmedExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _service.AddAsync(_command, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, EmailConfirmationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheRepositoryGetByNameAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetByNameAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheFactoryCreate_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		Factory.ShouldHaveReceivedOneCreate(_command, EmailConfirmationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheEmailConfirmationTokenRepositoryAddAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await EmailConfirmationTokenRepository.ShouldHaveReceivedOneAddAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheEventPublisherPublishAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishAsync(_command, EmailConfirmationToken, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheEmailSenderSendAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await EmailSender.ShouldHaveReceivedOneSendAsync(_command, CancellationToken);
	}
}
