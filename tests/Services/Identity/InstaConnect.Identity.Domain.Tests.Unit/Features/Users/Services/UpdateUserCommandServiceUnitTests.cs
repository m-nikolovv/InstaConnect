using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;
using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Identity.Domain.Features.Users.Helpers;
using InstaConnect.Identity.Domain.Features.Users.Models.Requests;
using InstaConnect.Identity.Domain.Tests.Features.Users.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.Users.Builders;
using InstaConnect.Identity.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Tests.Unit.Features.Users.Utilities;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Email;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Name;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.ProfileImage;

namespace InstaConnect.Identity.Domain.Tests.Unit.Features.Users.Services;

public class UpdateUserCommandServiceUnitTests : BaseUserDomainCommandUnitTest
{
	private readonly UpdateUserCommandBuilderFactory _commandBuilderFactory;
	private readonly UpdateUserCommandBuilder _commandBuilder;
	private readonly UpdateUserCommand _command;

	private readonly UserInclude _include;

	private readonly UserCommandService _service;

	public UpdateUserCommandServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(User);
		_command = _commandBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithEmailConfirmationTokens().Build();

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

		Repository.SetupGetByIdAsync(_command, _include, User, CancellationToken);
		Repository.SetupIsEmailUniqueAsync(_command, CancellationToken);
		Repository.SetupIsNameUniqueAsync(_command, CancellationToken);
		DateTimeProvider.SetupGetOffsetUtcNow(_command, User);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		Repository.RemoveGetByIdAsync(_command, _include, User, CancellationToken);

		// Assert
		await _service.ShouldThrowUserNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowUserEmailAlreadyTakenException_WhenUserEmailAlreadyTaken()
	{
		// Arrange
		Repository.RemoveIsEmailUniqueAsync(_command, CancellationToken);

		// Assert
		await _service.ShouldThrowUserEmailAlreadyTakenExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowUserNameAlreadyTakenException_WhenUserNameAlreadyTaken()
	{
		// Arrange
		Repository.RemoveIsNameUniqueAsync(_command, CancellationToken);

		// Assert
		await _service.ShouldThrowUserNameAlreadyTakenExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, User);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenCommandAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();
		Repository.SetupIsNameUniqueAsync(command, CancellationToken);

		// Act
		var response = await _service.UpdateAsync(command, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, User);
	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnResponse_WhenNameHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name).Build();

		// Act
		var response = await _service.UpdateAsync(command, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, User);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();
		Repository.SetupIsNameUniqueAsync(command, CancellationToken);

		// Act
		var response = await _service.UpdateAsync(command, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, User);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenCommandAndEmailAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(transformer).Build();
		Repository.SetupIsEmailUniqueAsync(command, CancellationToken);

		// Act
		var response = await _service.UpdateAsync(command, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, User);
	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnResponse_WhenEmailHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		var response = await _service.UpdateAsync(command, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, User);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();
		Repository.SetupIsEmailUniqueAsync(command, CancellationToken);

		// Act
		var response = await _service.UpdateAsync(command, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, User);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenCommandAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await _service.UpdateAsync(command, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, User);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetByIdAsync(_command, _include, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheRepositoryGetByIdAsync_WhenCommandAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();
		Repository.SetupIsNameUniqueAsync(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetByIdAsync(command, _include, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheRepositoryGetByIdAsync_WhenNameHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetByIdAsync(command, _include, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheRepositoryGetByIdAsync_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();
		Repository.SetupIsNameUniqueAsync(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetByIdAsync(command, _include, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheRepositoryGetByIdAsync_WhenCommandAndEmailAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(transformer).Build();
		Repository.SetupIsEmailUniqueAsync(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetByIdAsync(command, _include, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheRepositoryGetByIdAsync_WhenEmailHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetByIdAsync(command, _include, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheRepositoryGetByIdAsync_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();
		Repository.SetupIsEmailUniqueAsync(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetByIdAsync(command, _include, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateAsync_ShouldCallTheRepositoryGetByIdAsync_WhenCommandAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetByIdAsync(command, _include, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheRepositoryIsEmailUniqueAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneIsEmailUniqueAsync(_command, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheRepositoryIsEmailUniqueAsync_WhenCommandAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();
		Repository.SetupIsNameUniqueAsync(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneIsEmailUniqueAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheRepositoryIsEmailUniqueAsync_WhenNameHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneIsEmailUniqueAsync(command, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheRepositoryIsEmailUniqueAsync_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();
		Repository.SetupIsNameUniqueAsync(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneIsEmailUniqueAsync(command, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheRepositoryIsEmailUniqueAsync_WhenCommandAndEmailAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(transformer).Build();
		Repository.SetupIsEmailUniqueAsync(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneIsEmailUniqueAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheRepositoryIsEmailUniqueAsync_WhenEmailHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneIsEmailUniqueAsync(command, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheRepositoryIsEmailUniqueAsync_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();
		Repository.SetupIsEmailUniqueAsync(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneIsEmailUniqueAsync(command, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateAsync_ShouldCallTheRepositoryIsEmailUniqueAsync_WhenCommandAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneIsEmailUniqueAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheRepositoryIsNameUniqueAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneIsNameUniqueAsync(_command, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheRepositoryIsNameUniqueAsync_WhenCommandAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();
		Repository.SetupIsNameUniqueAsync(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneIsNameUniqueAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheRepositoryIsNameUniqueAsync_WhenNameHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneIsNameUniqueAsync(command, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheRepositoryIsNameUniqueAsync_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();
		Repository.SetupIsNameUniqueAsync(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneIsNameUniqueAsync(command, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheRepositoryIsNameUniqueAsync_WhenCommandAndEmailAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(transformer).Build();
		Repository.SetupIsEmailUniqueAsync(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneIsNameUniqueAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheRepositoryIsNameUniqueAsync_WhenEmailHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneIsNameUniqueAsync(command, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheRepositoryIsNameUniqueAsync_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();
		Repository.SetupIsEmailUniqueAsync(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneIsNameUniqueAsync(command, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateAsync_ShouldCallTheRepositoryIsNameUniqueAsync_WhenCommandAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneIsNameUniqueAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheEmailConfirmationTokenRepositoryDeleteRangeAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await EmailConfirmationTokenRepository.ShouldHaveReceivedOneDeleteRangeAsync(_command, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheEmailConfirmationTokenRepositoryDeleteRangeAsync_WhenCommandAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();
		Repository.SetupIsNameUniqueAsync(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EmailConfirmationTokenRepository.ShouldHaveReceivedOneDeleteRangeAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheEmailConfirmationTokenRepositoryDeleteRangeAsync_WhenNameHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EmailConfirmationTokenRepository.ShouldHaveReceivedOneDeleteRangeAsync(command, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheEmailConfirmationTokenRepositoryDeleteRangeAsync_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();
		Repository.SetupIsNameUniqueAsync(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EmailConfirmationTokenRepository.ShouldHaveReceivedOneDeleteRangeAsync(command, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheEmailConfirmationTokenRepositoryDeleteRangeAsync_WhenCommandAndEmailAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(transformer).Build();
		Repository.SetupIsEmailUniqueAsync(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EmailConfirmationTokenRepository.ShouldHaveReceivedOneDeleteRangeAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldNotCallTheEmailConfirmationTokenRepositoryDeleteRangeAsync_WhenEmailHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EmailConfirmationTokenRepository.ShouldHaveReceivedZeroDeleteRangeAsync(command, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldNotCallTheEmailConfirmationTokenRepositoryDeleteRangeAsync_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();
		Repository.SetupIsEmailUniqueAsync(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EmailConfirmationTokenRepository.ShouldHaveReceivedZeroDeleteRangeAsync(command, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateAsync_ShouldCallTheEmailConfirmationTokenRepositoryDeleteRangeAsync_WhenCommandAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EmailConfirmationTokenRepository.ShouldHaveReceivedOneDeleteRangeAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheEventPublisherPublishAsyncForEmailConfirmationTokenDeleted_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishEmailConfirmationTokenDeletedAsync(_command, User.EmailConfirmationTokens, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheEventPublisherPublishAsyncForEmailConfirmationTokenDeleted_WhenCommandAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();
		Repository.SetupIsNameUniqueAsync(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishEmailConfirmationTokenDeletedAsync(command, User.EmailConfirmationTokens, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheEventPublisherPublishAsyncForEmailConfirmationTokenDeleted_WhenNameHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishEmailConfirmationTokenDeletedAsync(command, User.EmailConfirmationTokens, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheEventPublisherPublishAsyncForEmailConfirmationTokenDeleted_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();
		Repository.SetupIsNameUniqueAsync(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishEmailConfirmationTokenDeletedAsync(command, User.EmailConfirmationTokens, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheEventPublisherPublishAsyncForEmailConfirmationTokenDeleted_WhenCommandAndEmailAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(transformer).Build();
		Repository.SetupIsEmailUniqueAsync(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishEmailConfirmationTokenDeletedAsync(command, User.EmailConfirmationTokens, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldNotCallTheEventPublisherPublishAsyncForEmailConfirmationTokenDeleted_WhenEmailHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedZeroPublishEmailConfirmationTokenDeletedAsync(command, User.EmailConfirmationTokens, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldNotCallTheEventPublisherPublishAsyncForEmailConfirmationTokenDeleted_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();
		Repository.SetupIsEmailUniqueAsync(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedZeroPublishEmailConfirmationTokenDeletedAsync(command, User.EmailConfirmationTokens, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateAsync_ShouldCallTheEventPublisherPublishAsyncForEmailConfirmationTokenDeleted_WhenCommandAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishEmailConfirmationTokenDeletedAsync(command, User.EmailConfirmationTokens, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheImageHandlerUploadAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await ImageHandler.ShouldHaveReceivedOneUploadAsync(_command, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheImageHandlerUploadAsync_WhenCommandAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();
		Repository.SetupIsNameUniqueAsync(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await ImageHandler.ShouldHaveReceivedOneUploadAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheImageHandlerUploadAsync_WhenNameHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await ImageHandler.ShouldHaveReceivedOneUploadAsync(command, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheImageHandlerUploadAsync_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();
		Repository.SetupIsNameUniqueAsync(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await ImageHandler.ShouldHaveReceivedOneUploadAsync(command, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheImageHandlerUploadAsync_WhenCommandAndEmailAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(transformer).Build();
		Repository.SetupIsEmailUniqueAsync(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await ImageHandler.ShouldHaveReceivedOneUploadAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheImageHandlerUploadAsync_WhenEmailHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await ImageHandler.ShouldHaveReceivedOneUploadAsync(command, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheImageHandlerUploadAsync_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();
		Repository.SetupIsEmailUniqueAsync(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await ImageHandler.ShouldHaveReceivedOneUploadAsync(command, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateAsync_ShouldNotCallTheImageHandlerUploadAsync_WhenCommandAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await ImageHandler.ShouldHaveReceivedZeroUploadAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		DateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow(_command);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenCommandAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();
		Repository.SetupIsNameUniqueAsync(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		DateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow(command);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenNameHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		DateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow(command);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();
		Repository.SetupIsNameUniqueAsync(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		DateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow(command);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenCommandAndEmailAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(transformer).Build();
		Repository.SetupIsEmailUniqueAsync(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		DateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow(command);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenEmailHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		DateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow(command);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();
		Repository.SetupIsEmailUniqueAsync(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		DateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow(command);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateAsync_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenCommandAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		DateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow(command);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheRepositoryUpdateAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneUpdateAsync(_command, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheRepositoryUpdateAsync_WhenCommandAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();
		Repository.SetupIsNameUniqueAsync(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneUpdateAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheRepositoryUpdateAsync_WhenNameHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneUpdateAsync(command, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheRepositoryUpdateAsync_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();
		Repository.SetupIsNameUniqueAsync(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneUpdateAsync(command, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheRepositoryUpdateAsync_WhenCommandAndEmailAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(transformer).Build();
		Repository.SetupIsEmailUniqueAsync(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneUpdateAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheRepositoryUpdateAsync_WhenEmailHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneUpdateAsync(command, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheRepositoryUpdateAsync_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();
		Repository.SetupIsEmailUniqueAsync(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneUpdateAsync(command, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateAsync_ShouldCallTheRepositoryUpdateAsync_WhenCommandAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneUpdateAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheEventPublisherPublishAsyncForUserUpdated_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishAsync(_command, User, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheEventPublisherPublishAsyncForUserUpdated_WhenCommandAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();
		Repository.SetupIsNameUniqueAsync(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishAsync(command, User, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheEventPublisherPublishAsyncForUserUpdated_WhenNameHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishAsync(command, User, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheEventPublisherPublishAsyncForUserUpdated_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();
		Repository.SetupIsNameUniqueAsync(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishAsync(command, User, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheEventPublisherPublishAsyncForUserUpdated_WhenCommandAndEmailAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(transformer).Build();
		Repository.SetupIsEmailUniqueAsync(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishAsync(command, User, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheEventPublisherPublishAsyncForUserUpdated_WhenEmailHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishAsync(command, User, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheEventPublisherPublishAsyncForUserUpdated_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();
		Repository.SetupIsEmailUniqueAsync(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishAsync(command, User, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateAsync_ShouldCallTheEventPublisherPublishAsyncForUserUpdated_WhenCommandAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishAsync(command, User, CancellationToken);
	}
}
