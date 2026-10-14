using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;
using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Identity.Domain.Features.Users.Models.Requests;
using InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.Users.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.Users.Builders;
using InstaConnect.Identity.Domain.Tests.Integration.Features.Users.Utilities;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Assertions;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Assertions;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Email;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Name;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.ProfileImage;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Integration.Features.Users.Services;

public class AddUserCommandServiceIntegrationTests : BaseUserDomainCommandIntegrationTest
{
	private readonly AddUserCommandBuilderFactory _commandBuilderFactory;
	private readonly AddUserCommandBuilder _commandBuilder;
	private readonly AddUserCommand _command;

	public AddUserCommandServiceIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create();
		_command = _commandBuilder.Build();
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserEmailAlreadyTakenException_WhenEmailIsNotUnique()
	{
		// Arrange
		await ServiceScope.AddAsync(User, CancellationToken);
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Assert
		await Service.ShouldThrowUserEmailAlreadyTakenExceptionAsync(command, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task AddAsync_ShouldThrowUserEmailAlreadyTakenException_WhenEmailIsNotUniqueAndDifferentCase(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(User, CancellationToken);
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();

		// Assert
		await Service.ShouldThrowUserEmailAlreadyTakenExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNameAlreadyTakenException_WhenNameIsNotUnique()
	{
		// Arrange
		await ServiceScope.AddAsync(User, CancellationToken);
		var command = _commandBuilder.WithName(User.Name).Build();

		// Assert
		await Service.ShouldThrowUserNameAlreadyTakenExceptionAsync(command, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task AddAsync_ShouldThrowUserNameAlreadyTakenException_WhenNameIsNotUniqueAndDifferentCase(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(User, CancellationToken);
		var command = _commandBuilder.WithName(User.Name, transformer).Build();

		// Assert
		await Service.ShouldThrowUserNameAlreadyTakenExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, user);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldReturnResponse_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, user);
	}

	[Fact]
	public async Task AddAsync_ShouldAddUser_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(_command);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldAddUser_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(command);
	}

	[Fact]
	public async Task AddAsync_ShouldAddEmailConfirmationToken_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldSatisfy(_command);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldAddEmailConfirmationToken_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldSatisfy(command);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishUserAddedEvent_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_command, user);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldPublishUserAddedEvent_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, user);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishEmailConfirmationTokenAddedEvent_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedAddedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(_command, user.EmailConfirmationTokens);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldPublishEmailConfirmationTokenAddedEvent_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedAddedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(command, user.EmailConfirmationTokens);
	}
}
