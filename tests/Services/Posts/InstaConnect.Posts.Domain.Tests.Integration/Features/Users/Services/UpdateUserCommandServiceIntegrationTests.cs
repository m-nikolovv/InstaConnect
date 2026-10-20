using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Posts.Domain.Features.Users.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.Users.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.Users.Builders;
using InstaConnect.Posts.Domain.Tests.Integration.Features.Users.Utilities;
using InstaConnect.Posts.Tests.Features.Users.DataAttributes.Email;
using InstaConnect.Posts.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Posts.Tests.Features.Users.DataAttributes.Name;
using InstaConnect.Posts.Tests.Features.Users.DataAttributes.ProfileImage;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.Users.Services;

public class UpdateUserCommandServiceIntegrationTests : BaseUserDomainCommandIntegrationTest
{
	private readonly UpdateUserCommandBuilderFactory _commandBuilderFactory;
	private readonly UpdateUserCommandBuilder _commandBuilder;
	private readonly UpdateUserCommand _command;

	public UpdateUserCommandServiceIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(User);
		_command = _commandBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await UserService.ShouldThrowUserNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowUserEmailAlreadyExistsException_WhenUserEmailAlreadyExists()
	{
		// Arrange
		var user = UserBuilderFactory.Create().Build();
		await ServiceScope.AddAsync(user, CancellationToken);

		var command = _commandBuilder.WithEmail(user.Email).Build();

		// Assert
		await UserService.ShouldThrowUserEmailAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldThrowUserEmailAlreadyExistsException_WhenUserEmailAlreadyExistsAndEmailIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var user = UserBuilderFactory.Create().Build();
		await ServiceScope.AddAsync(user, CancellationToken);

		var command = _commandBuilder.WithEmail(user.Email, transformer).Build();

		// Assert
		await UserService.ShouldThrowUserEmailAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowUserNameAlreadyExistsException_WhenUserNameAlreadyExists()
	{
		// Arrange
		var user = UserBuilderFactory.Create().Build();
		await ServiceScope.AddAsync(user, CancellationToken);

		var command = _commandBuilder.WithName(user.Name).Build();

		// Assert
		await UserService.ShouldThrowUserNameAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldThrowUserNameAlreadyExistsException_WhenUserNameAlreadyExistsAndNameIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var user = UserBuilderFactory.Create().Build();
		await ServiceScope.AddAsync(user, CancellationToken);

		var command = _commandBuilder.WithName(user.Name, transformer).Build();

		// Assert
		await UserService.ShouldThrowUserNameAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await UserService.UpdateAsync(_command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, user);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		var response = await UserService.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, user);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenCommandAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();

		// Act
		var response = await UserService.UpdateAsync(command, CancellationToken);
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
		var response = await UserService.UpdateAsync(command, CancellationToken);
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
		var response = await UserService.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, user);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenCommandAndEmailAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(transformer).Build();

		// Act
		var response = await UserService.UpdateAsync(command, CancellationToken);
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
		var response = await UserService.UpdateAsync(command, CancellationToken);
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
		var response = await UserService.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, user);
	}

	[Theory]
	[UserProfileImageNullData]
	[UserProfileImageEmptyData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenCommandAndProfileImageAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await UserService.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, user);
	}

	[Fact]
	public async Task UpdateAsync_ShouldUpdateUser_WhenCommandIsValid()
	{
		// Act
		var response = await UserService.UpdateAsync(_command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(_command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateUser_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		var response = await UserService.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(command);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateUser_WhenCommandAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();

		// Act
		var response = await UserService.UpdateAsync(command, CancellationToken);
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
		var response = await UserService.UpdateAsync(command, CancellationToken);
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
		var response = await UserService.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(command);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdateUser_WhenCommandAndEmailAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(transformer).Build();

		// Act
		var response = await UserService.UpdateAsync(command, CancellationToken);
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
		var response = await UserService.UpdateAsync(command, CancellationToken);
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
		var response = await UserService.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(command);
	}

	[Theory]
	[UserProfileImageNullData]
	[UserProfileImageEmptyData]
	public async Task UpdateAsync_ShouldUpdateUser_WhenCommandAndProfileImageAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await UserService.UpdateAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(command);
	}
}
