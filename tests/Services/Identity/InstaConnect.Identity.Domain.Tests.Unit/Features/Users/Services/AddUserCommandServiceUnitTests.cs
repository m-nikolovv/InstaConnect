using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;
using InstaConnect.Identity.Domain.Features.Users.Helpers;
using InstaConnect.Identity.Domain.Features.Users.Models.Requests;
using InstaConnect.Identity.Domain.Tests.Features.Users.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.Users.Builders;
using InstaConnect.Identity.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Tests.Unit.Features.Users.Utilities;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.ProfileImage;

namespace InstaConnect.Identity.Domain.Tests.Unit.Features.Users.Services;

public class AddUserCommandServiceUnitTests : BaseUserDomainCommandUnitTest
{
	private readonly AddUserCommandBuilderFactory _commandBuilderFactory;
	private readonly AddUserCommandBuilder _commandBuilder;
	private readonly AddUserCommand _command;

	private readonly UserCommandService _service;

	public AddUserCommandServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create();
		_command = _commandBuilder.Build();

		_service = new(
			Factory,
			Mapper,
			ImageHandler,
			EventPublisher,
			Repository,
			DateTimeProvider,
			IncludeBuilderFactory,
			EmailConfirmationTokenFactory,
			EmailConfirmationTokenEmailSender,
			EmailConfirmationTokenRepository);

		Repository.SetupIsEmailUniqueAsync(_command, CancellationToken);
		Repository.SetupIsNameUniqueAsync(_command, CancellationToken);
		Factory.SetupCreate(_command, User);
		EmailConfirmationTokenFactory.SetupCreate(_command, EmailConfirmationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserEmailAlreadyTakenException_WhenEmailIsInvalid()
	{
		// Arrange
		Repository.RemoveIsEmailUniqueAsync(_command, CancellationToken);

		// Assert
		await _service.ShouldThrowUserEmailAlreadyTakenExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNameAlreadyTakenException_WhenNameIsInvalid()
	{
		// Arrange
		Repository.RemoveIsNameUniqueAsync(_command, CancellationToken);

		// Assert
		await _service.ShouldThrowUserNameAlreadyTakenExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _service.AddAsync(_command, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, User);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldReturnResponse_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await _service.AddAsync(command, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, User);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheRepositoryIsEmailUniqueAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneIsEmailUniqueAsync(_command, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldCallTheRepositoryIsEmailUniqueAsync_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneIsEmailUniqueAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheRepositoryIsNameUniqueAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneIsNameUniqueAsync(_command, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldCallTheRepositoryIsNameUniqueAsync_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneIsNameUniqueAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheFactoryCreate_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		Factory.ShouldHaveReceivedOneCreate(_command);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldCallTheFactoryCreate_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		Factory.ShouldHaveReceivedOneCreate(command);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheImageHandlerUploadAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await ImageHandler.ShouldHaveReceivedOneUploadAsync(_command, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldNotCallTheImageHandlerUploadAsync_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		await ImageHandler.ShouldHaveReceivedZeroUploadAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheRepositoryAddAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneAddAsync(_command, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldCallTheRepositoryAddAsync_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneAddAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheEventPublisherPublishAsyncForUserAdded_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishAsync(_command, User, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldCallTheEventPublisherPublishAsyncForUserAdded_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishAsync(command, User, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheEmailConfirmationTokenFactoryCreate_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		EmailConfirmationTokenFactory.ShouldHaveReceivedOneCreate(_command, User);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldCallTheEmailConfirmationTokenFactoryCreate_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		EmailConfirmationTokenFactory.ShouldHaveReceivedOneCreate(command, User);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheEmailConfirmationTokenRepositoryAddAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await EmailConfirmationTokenRepository.ShouldHaveReceivedOneAddAsync(_command, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldCallTheEmailConfirmationTokenRepositoryAddAsync_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		await EmailConfirmationTokenRepository.ShouldHaveReceivedOneAddAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheEventPublisherPublishAsyncForEmailConfirmationTokenAdded_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishAsync(_command, EmailConfirmationToken, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldCallTheEventPublisherPublishAsyncForEmailConfirmationTokenAdded_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishAsync(command, EmailConfirmationToken, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheEmailConfirmationTokenEmailSenderSendAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await EmailConfirmationTokenEmailSender.ShouldHaveReceivedOneSendAsync(_command, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldCallTheEmailConfirmationTokenEmailSenderSendAsync_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		await EmailConfirmationTokenEmailSender.ShouldHaveReceivedOneSendAsync(command, CancellationToken);
	}
}
