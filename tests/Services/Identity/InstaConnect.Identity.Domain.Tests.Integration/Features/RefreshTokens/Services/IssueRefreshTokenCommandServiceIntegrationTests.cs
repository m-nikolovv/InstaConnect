using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;
using InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Builders;
using InstaConnect.Identity.Domain.Tests.Integration.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Name;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Integration.Features.RefreshTokens.Services;

public class IssueRefreshTokenCommandServiceIntegrationTests : BaseRefreshTokenDomainCommandIntegrationTest
{
	private readonly IssueRefreshTokenCommandBuilderFactory _commandBuilderFactory;
	private readonly IssueRefreshTokenCommandBuilder _commandBuilder;
	private readonly IssueRefreshTokenCommand _command;

	public IssueRefreshTokenCommandServiceIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(User, Password);
		_command = _commandBuilder.Build();
	}

	[Fact]
	public async Task IssueAsync_ShouldThrowUserInvalidDetailsException_WhenUserInvalidDetailsAndNameIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await Service.ShouldThrowUserInvalidDetailsExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task IssueAsync_ShouldThrowUserInvalidDetailsException_WhenUserInvalidDetailsAndPasswordIsInvalid()
	{
		// Arrange
		var updatedUser = UserBuilder.WithPasswordHash(PasswordHasher.Hash(NewPassword)).Build();
		await ServiceScope.UpdateAsync(updatedUser, CancellationToken);

		// Assert
		await Service.ShouldThrowUserInvalidDetailsExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task IssueAsync_ShouldThrowUserNameEmailNotConfirmedException_WhenUserNameEmailNotConfirmed()
	{
		// Arrange
		var updatedUser = UserBuilder.WithUnconfirmedEmail().Build();
		await ServiceScope.UpdateAsync(updatedUser, CancellationToken);

		// Assert
		await Service.ShouldThrowUserNameEmailNotConfirmedExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task IssueAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Service.IssueAsync(_command, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(response.Id, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, refreshToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task IssueAsync_ShouldReturnResponse_WhenCommandAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();

		// Act
		var response = await Service.IssueAsync(command, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(response.Id, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, refreshToken);
	}

	[Fact]
	public async Task IssueAsync_ShouldAddRefreshToken_WhenCommandIsValid()
	{
		// Act
		var response = await Service.IssueAsync(_command, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(response.Id, CancellationToken);

		// Assert
		refreshToken.ShouldSatisfy(_command);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task IssueAsync_ShouldAddRefreshToken_WhenCommandAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();

		// Act
		var response = await Service.IssueAsync(command, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(response.Id, CancellationToken);

		// Assert
		refreshToken.ShouldSatisfy(command);
	}
}
