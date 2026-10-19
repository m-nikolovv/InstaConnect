using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;
using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.Identity.Domain.Features.Users.Models.Requests;
using InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.Users.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.Users.Builders;
using InstaConnect.Identity.Domain.Tests.Integration.Features.Users.Utilities;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Assertions;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Assertions;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Email;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Name;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.ProfileImage;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Integration.Features.Users.Services;

public class UpdateUserCommandServiceIntegrationTests : BaseUserDomainCommandIntegrationTest
{
	private readonly UpdateUserCommandBuilderFactory _commandBuilderFactory;
	private readonly UpdateUserCommandBuilder _commandBuilder;
	private readonly UpdateUserCommand _command;

	public UpdateUserCommandServiceIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(User);
		_command = _commandBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddRangeAsync(User.EmailConfirmationTokens, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await Service.ShouldThrowUserNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowUserEmailAlreadyTakenException_WhenUserEmailAlreadyTaken()
	{
		// Arrange
		var user = UserBuilderFactory.Create(User.PasswordHash).Build();
		await ServiceScope.AddAsync(user, CancellationToken);

		var command = _commandBuilder.WithEmail(user.Email).Build();

		// Assert
		await Service.ShouldThrowUserEmailAlreadyTakenExceptionAsync(command, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldThrowUserEmailAlreadyTakenException_WhenUserEmailAlreadyTakenAndEmailIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var user = UserBuilderFactory.Create(User.PasswordHash).Build();
		await ServiceScope.AddAsync(user, CancellationToken);

		var command = _commandBuilder.WithEmail(user.Email, transformer).Build();

		// Assert
		await Service.ShouldThrowUserEmailAlreadyTakenExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowUserNameAlreadyTakenException_WhenUserNameAlreadyTaken()
	{
		// Arrange
		var user = UserBuilderFactory.Create(User.PasswordHash).Build();
		await ServiceScope.AddAsync(user, CancellationToken);

		var command = _commandBuilder.WithName(user.Name).Build();

		// Assert
		await Service.ShouldThrowUserNameAlreadyTakenExceptionAsync(command, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldThrowUserNameAlreadyTakenException_WhenUserNameAlreadyTakenAndNameIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var user = UserBuilderFactory.Create(User.PasswordHash).Build();
		await ServiceScope.AddAsync(user, CancellationToken);

		var command = _commandBuilder.WithName(user.Name, transformer).Build();

		// Assert
		await Service.ShouldThrowUserNameAlreadyTakenExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Service.UpdateAsync(_command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, user);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, user);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenNameIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, user);
	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnResponse_WhenNameHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, user);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, user);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenEmailIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, user);
	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnResponse_WhenEmailHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, user);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, user);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, user);
	}

	[Fact]
	public async Task UpdateAsync_ShouldUpdateUser_WhenCommandIsValid()
	{
		// Act
		var response = await Service.UpdateAsync(_command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(_command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateUser_WhenIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(command);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateUser_WhenNameIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(command);
	}

	[Fact]
	public async Task UpdateAsync_ShouldUpdateUser_WhenNameHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(command);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateUser_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(command);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateUser_WhenEmailIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(command);
	}

	[Fact]
	public async Task UpdateAsync_ShouldUpdateUser_WhenEmailHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(command);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateUser_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(command);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateAsync_ShouldUpdateUser_WhenCommandAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(command);
	}

	[Fact]
	public async Task UpdateAsync_ShouldPublishUserUpdatedEvent_WhenCommandIsValid()
	{
		// Act
		var response = await Service.UpdateAsync(_command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_command, user);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishUserUpdatedEvent_WhenIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, user);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishUserUpdatedEvent_WhenNameIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, user);
	}

	[Fact]
	public async Task UpdateAsync_ShouldPublishUserUpdatedEvent_WhenNameHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, user);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishUserUpdatedEvent_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, user);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishUserUpdatedEvent_WhenEmailIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, user);
	}

	[Fact]
	public async Task UpdateAsync_ShouldPublishUserUpdatedEvent_WhenEmailHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, user);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishUserUpdatedEvent_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, user);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateAsync_ShouldPublishUserUpdatedEvent_WhenCommandAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, user);
	}

	[Fact]
	public async Task UpdateAsync_ShouldDeleteEmailConfirmationTokens_WhenCommandIsValid()
	{
		// Act
		var response = await Service.UpdateAsync(_command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldDeleteEmailConfirmationTokens_WhenIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldDeleteEmailConfirmationTokens_WhenNameIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Fact]
	public async Task UpdateAsync_ShouldDeleteEmailConfirmationTokens_WhenNameHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldDeleteEmailConfirmationTokens_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Fact]
	public async Task UpdateAsync_ShouldNotDeleteEmailConfirmationTokens_WhenEmailHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldSatisfy(command);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldNotDeleteEmailConfirmationTokens_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldSatisfy(command);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldDeleteEmailConfirmationTokens_WhenEmailIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateAsync_ShouldDeleteEmailConfirmationTokens_WhenCommandAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Fact]
	public async Task UpdateAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenCommandIsValid()
	{
		// Act
		var response = await Service.UpdateAsync(_command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedDeletedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(_command, User.EmailConfirmationTokens.AddUser(user));
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedDeletedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(command, User.EmailConfirmationTokens.AddUser(user));
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenNameIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedDeletedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(command, User.EmailConfirmationTokens.AddUser(user));
	}

	[Fact]
	public async Task UpdateAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenNameHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedDeletedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(command, User.EmailConfirmationTokens.AddUser(user));
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedDeletedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(command, User.EmailConfirmationTokens.AddUser(user));
	}

	[Fact]
	public async Task UpdateAsync_ShouldNotPublishEmailConfirmationTokenDeletedEvents_WhenEmailHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		await Service.UpdateAsync(command, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedDeletedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldBeEmpty();
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldNotPublishEmailConfirmationTokenDeletedEvents_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		await Service.UpdateAsync(command, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedDeletedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldBeEmpty();
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenEmailIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedDeletedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(command, User.EmailConfirmationTokens.AddUser(user));
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenCommandAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedDeletedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(command, User.EmailConfirmationTokens.AddUser(user));
	}
}
