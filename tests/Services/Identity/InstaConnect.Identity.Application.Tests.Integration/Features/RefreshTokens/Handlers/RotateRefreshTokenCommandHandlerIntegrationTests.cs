using InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Rotate;
using InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Builders;
using InstaConnect.Identity.Application.Tests.Integration.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Builders;
using InstaConnect.Identity.Tests.Features.RefreshTokens.DataAttributes.Value;

namespace InstaConnect.Identity.Application.Tests.Integration.Features.RefreshTokens.Handlers;

public class RotateRefreshTokenCommandHandlerIntegrationTests : BaseRefreshTokenApplicationCommandIntegrationTest
{
	private readonly RotateRefreshTokenCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly RotateRefreshTokenCommandRequestBuilder _requestBuilder;
	private readonly RotateRefreshTokenCommandRequest _request;

	public RotateRefreshTokenCommandHandlerIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(RefreshToken);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(RefreshToken, CancellationToken);
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForIdAsync(request, messageTransformer, CancellationToken);
	}

	[Theory]
	[RefreshTokenValueNullWithMessageData]
	[RefreshTokenValueEmptyWithMessageData]
	[RefreshTokenValueTooShortWithMessageData]
	[RefreshTokenValueTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenValueIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForValueAsync(request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await Sender.ShouldThrowUserNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowRefreshTokenNotFoundException_WhenRefreshTokenNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(RefreshToken, CancellationToken);

		// Assert
		await Sender.ShouldThrowRefreshTokenNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowRefreshTokenExpiredException_WhenRefreshTokenExpired()
	{
		// Arrange
		var updatedRefreshToken = RefreshTokenBuilder.WithAlreadyExpiresAtUtc().Build();
		await ServiceScope.UpdateAsync(updatedRefreshToken, CancellationToken);

		// Assert
		await Sender.ShouldThrowRefreshTokenExpiredExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldDeleteRefreshToken_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(RefreshTokenId, CancellationToken);

		// Assert
		refreshToken.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteRefreshToken_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(RefreshTokenId, CancellationToken);

		// Assert
		refreshToken.ShouldBeNull();
	}

	[Theory]
	[RefreshTokenValueDifferentCaseData]
	public async Task SendAsync_ShouldDeleteRefreshToken_WhenRequestAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(RefreshTokenId, CancellationToken);

		// Assert
		refreshToken.ShouldBeNull();
	}

	[Fact]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, refreshToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, refreshToken);
	}

	[Theory]
	[RefreshTokenValueDifferentCaseData]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, refreshToken);
	}

	[Fact]
	public async Task SendAsync_ShouldAddRefreshToken_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		refreshToken.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldAddRefreshToken_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		refreshToken.ShouldSatisfy(request);
	}

	[Theory]
	[RefreshTokenValueDifferentCaseData]
	public async Task SendAsync_ShouldAddRefreshToken_WhenRequestAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		refreshToken.ShouldSatisfy(request);
	}
}
