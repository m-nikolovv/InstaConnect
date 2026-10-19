using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;
using InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Builders;
using InstaConnect.Identity.Domain.Tests.Integration.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.RefreshTokens.DataAttributes.Value;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Integration.Features.RefreshTokens.Services;

public class RotateRefreshTokenCommandServiceIntegrationTests : BaseRefreshTokenDomainCommandIntegrationTest
{
	private readonly RotateRefreshTokenCommandBuilderFactory _commandBuilderFactory;
	private readonly RotateRefreshTokenCommandBuilder _commandBuilder;
	private readonly RotateRefreshTokenCommand _command;

	public RotateRefreshTokenCommandServiceIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(RefreshToken);
		_command = _commandBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(RefreshToken, CancellationToken);
	}

	[Fact]
	public async Task RotateAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await Service.ShouldThrowUserNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task RotateAsync_ShouldThrowRefreshTokenNotFoundException_WhenRefreshTokenNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(RefreshToken, CancellationToken);

		// Assert
		await Service.ShouldThrowRefreshTokenNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task RotateAsync_ShouldThrowRefreshTokenExpiredException_WhenRefreshTokenExpired()
	{
		// Arrange
		var updatedRefreshToken = RefreshTokenBuilder.WithAlreadyExpiresAtUtc().Build();
		await ServiceScope.UpdateAsync(updatedRefreshToken, CancellationToken);

		// Assert
		await Service.ShouldThrowRefreshTokenExpiredExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task RotateAsync_ShouldDeleteRefreshToken_WhenCommandIsValid()
	{
		// Act
		await Service.RotateAsync(_command, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(RefreshTokenId, CancellationToken);

		// Assert
		refreshToken.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task RotateAsync_ShouldDeleteRefreshToken_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await Service.RotateAsync(command, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(RefreshTokenId, CancellationToken);

		// Assert
		refreshToken.ShouldBeNull();
	}

	[Theory]
	[RefreshTokenValueDifferentCaseData]
	public async Task RotateAsync_ShouldDeleteRefreshToken_WhenCommandAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithValue(transformer).Build();

		// Act
		await Service.RotateAsync(command, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(RefreshTokenId, CancellationToken);

		// Assert
		refreshToken.ShouldBeNull();
	}

	[Fact]
	public async Task RotateAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Service.RotateAsync(_command, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(response.Id, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, refreshToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task RotateAsync_ShouldReturnResponse_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.RotateAsync(command, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(response.Id, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, refreshToken);
	}

	[Theory]
	[RefreshTokenValueDifferentCaseData]
	public async Task RotateAsync_ShouldReturnResponse_WhenCommandAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithValue(transformer).Build();

		// Act
		var response = await Service.RotateAsync(command, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(response.Id, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, refreshToken);
	}

	[Fact]
	public async Task RotateAsync_ShouldAddRefreshToken_WhenCommandIsValid()
	{
		// Act
		var response = await Service.RotateAsync(_command, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(response.Id, CancellationToken);

		// Assert
		refreshToken.ShouldSatisfy(_command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task RotateAsync_ShouldAddRefreshToken_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.RotateAsync(command, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(response.Id, CancellationToken);

		// Assert
		refreshToken.ShouldSatisfy(command);
	}

	[Theory]
	[RefreshTokenValueDifferentCaseData]
	public async Task RotateAsync_ShouldAddRefreshToken_WhenCommandAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithValue(transformer).Build();

		// Act
		var response = await Service.RotateAsync(command, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(response.Id, CancellationToken);

		// Assert
		refreshToken.ShouldSatisfy(command);
	}
}
