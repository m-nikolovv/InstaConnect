using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Helpers;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Requests;
using InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Builders;
using InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Domain.Tests.Unit.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Unit.Features.ForgotPasswordTokens.Services;

public class AddForgotPasswordTokenCommandServiceUnitTests : BaseForgotPasswordTokenDomainCommandUnitTest
{
	private readonly AddForgotPasswordTokenCommandBuilderFactory _commandBuilderFactory;
	private readonly AddForgotPasswordTokenCommandBuilder _commandBuilder;
	private readonly AddForgotPasswordTokenCommand _command;

	private readonly ForgotPasswordTokenCommandService _service;

	public AddForgotPasswordTokenCommandServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(User);
		_command = _commandBuilder.Build();

		_service = new(
			Mapper,
			PasswordHasher,
			EventPublisher,
			Repository,
			DateTimeProvider,
			IncludeBuilderFactory,
			Factory,
			EmailSender,
			ForgotPasswordTokenRepository);

		Repository.SetupGetByNameAsync(_command, User, CancellationToken);
		Factory.SetupCreate(_command, ForgotPasswordToken);
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
	public async Task AddAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _service.AddAsync(_command, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, ForgotPasswordToken);
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
		Factory.ShouldHaveReceivedOneCreate(_command, ForgotPasswordToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheForgotPasswordTokenRepositoryAddAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await ForgotPasswordTokenRepository.ShouldHaveReceivedOneAddAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheEventPublisherPublishAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishAsync(_command, ForgotPasswordToken, CancellationToken);
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
