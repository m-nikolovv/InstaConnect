using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Follows.Domain.Features.Users.Models.Requests;
using InstaConnect.Follows.Domain.Tests.Features.Users.Assertions;
using InstaConnect.Follows.Domain.Tests.Features.Users.Builders;
using InstaConnect.Follows.Domain.Tests.Integration.Features.Users.Utilities;
using InstaConnect.Follows.Tests.Features.Users.DataAttributes.Email;
using InstaConnect.Follows.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Follows.Tests.Features.Users.DataAttributes.Name;
using InstaConnect.Follows.Tests.Features.Users.DataAttributes.ProfileImage;
using InstaConnect.Follows.Tests.Features.Users.Utilities;

namespace InstaConnect.Follows.Domain.Tests.Integration.Features.Users.Services;

public class AddUserCommandServiceIntegrationTests : BaseUserDomainCommandIntegrationTest
{
	private readonly AddUserCommandBuilderFactory _commandBuilderFactory;
	private readonly AddUserCommandBuilder _commandBuilder;
	private readonly AddUserCommand _command;

	public AddUserCommandServiceIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create();
		_command = _commandBuilder.Build();
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserAlreadyExistsException_WhenCommandIsInvalid()
	{
		// Arrange
		await ServiceScope.AddAsync(User, CancellationToken);
		var command = _commandBuilder.WithId(UserId).Build();

		// Assert
		await UserService.ShouldThrowUserAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldThrowUserAlreadyExistsException_WhenIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(User, CancellationToken);
		var command = _commandBuilder.WithId(UserId, transformer).Build();

		// Assert
		await UserService.ShouldThrowUserAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserEmailAlreadyExistsException_WhenCommandIsInvalid()
	{
		// Arrange
		await ServiceScope.AddAsync(User, CancellationToken);
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Assert
		await UserService.ShouldThrowUserEmailAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task AddAsync_ShouldThrowUserEmailAlreadyExistsException_WhenEmailIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(User, CancellationToken);
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();

		// Assert
		await UserService.ShouldThrowUserEmailAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNameAlreadyExistsException_WhenCommandIsInvalid()
	{
		// Arrange
		await ServiceScope.AddAsync(User, CancellationToken);
		var command = _commandBuilder.WithName(User.Name).Build();

		// Assert
		await UserService.ShouldThrowUserNameAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task AddAsync_ShouldThrowUserNameAlreadyExistsException_WhenNameIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(User, CancellationToken);
		var command = _commandBuilder.WithName(User.Name, transformer).Build();

		// Assert
		await UserService.ShouldThrowUserNameAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await UserService.AddAsync(_command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, user);
	}

	[Theory]
	[UserProfileImageNullData]
	[UserProfileImageEmptyData]
	public async Task AddAsync_ShouldReturnResponse_WhenProfileImageIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await UserService.AddAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, user);
	}

	[Fact]
	public async Task AddAsync_ShouldAddUser_WhenCommandIsValid()
	{
		// Act
		var response = await UserService.AddAsync(_command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(_command);
	}

	[Theory]
	[UserProfileImageNullData]
	[UserProfileImageEmptyData]
	public async Task AddAsync_ShouldAddUser_WhenProfileImageIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await UserService.AddAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(command);
	}
}
