using InstaConnect.Posts.Domain.Features.Users.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.Users.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.Users.Builders;
using InstaConnect.Posts.Domain.Tests.Integration.Features.Users.Utilities;
using InstaConnect.Posts.Tests.Features.Users.DataAttributes.Email;
using InstaConnect.Posts.Tests.Features.Users.DataAttributes.ProfileImage;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.Users.Services;

public class AddUserCommandServiceIntegrationTests : BaseUserDomainCommandIntegrationTest
{
	private readonly AddUserCommandBuilderFactory _commandBuilderFactory;
	private readonly AddUserCommandBuilder _commandBuilder;
	private readonly AddUserCommand _command;

	public AddUserCommandServiceIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create();
		_command = _commandBuilder.Build();
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserAlreadyExistsException_WhenUserAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddAsync(User, CancellationToken);
		var command = _commandBuilder.WithId(UserId).Build();

		// Assert
		await UserService.ShouldThrowUserAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldThrowUserAlreadyExistsException_WhenUserAlreadyExistsAndIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(User, CancellationToken);
		var command = _commandBuilder.WithId(UserId, transformer).Build();

		// Assert
		await UserService.ShouldThrowUserAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserEmailAlreadyExistsException_WhenUserEmailAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddAsync(User, CancellationToken);
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Assert
		await UserService.ShouldThrowUserEmailAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task AddAsync_ShouldThrowUserEmailAlreadyExistsException_WhenUserEmailAlreadyExistsAndEmailIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(User, CancellationToken);
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();

		// Assert
		await UserService.ShouldThrowUserEmailAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNameAlreadyExistsException_WhenUserNameAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddAsync(User, CancellationToken);
		var command = _commandBuilder.WithName(User.Name).Build();

		// Assert
		await UserService.ShouldThrowUserNameAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task AddAsync_ShouldThrowUserNameAlreadyExistsException_WhenUserNameAlreadyExistsAndNameIsInvalid(
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
	public async Task AddAsync_ShouldReturnResponse_WhenCommandAndProfileImageAreValid(
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
	public async Task AddAsync_ShouldAddUser_WhenCommandAndProfileImageAreValid(
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
