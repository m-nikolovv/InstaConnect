namespace InstaConnect.Identity.Presentation.Tests.Integration.Features.RefreshTokens.Controllers;

public class DeleteCurrentRefreshTokenControllerIntegrationTests : BaseRefreshTokenPresentationIntegrationTest
{
	private readonly DeleteCurrentRefreshTokenApiRequestBuilderFactory _requestBuilderFactory;
	private readonly DeleteCurrentRefreshTokenApiRequestBuilder _requestBuilder;
	private readonly DeleteCurrentRefreshTokenApiRequest _request;

	public DeleteCurrentRefreshTokenControllerIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
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
	public async Task DeleteCurrentAsync_ShouldThrowValidationException_WhenIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[RefreshTokenValueNullWithMessageData]
	[RefreshTokenValueEmptyWithMessageData]
	[RefreshTokenValueTooShortWithMessageData]
	[RefreshTokenValueTooLongWithMessageData]
	public async Task DeleteCurrentAsync_ShouldThrowValidationException_WhenValueIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForValueAsync(
			request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task DeleteCurrentAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await Controller.ShouldThrowUserNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task DeleteCurrentAsync_ShouldThrowRefreshTokenNotFoundException_WhenRefreshTokenNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(RefreshToken, CancellationToken);

		// Assert
		await Controller.ShouldThrowRefreshTokenNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task DeleteCurrentAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.DeleteCurrentAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithNoContentStatusCode();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteCurrentAsync_ShouldReturnNoContentStatusCode_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Controller.DeleteCurrentAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithNoContentStatusCode();
	}

	[Theory]
	[RefreshTokenValueDifferentCaseData]
	public async Task DeleteCurrentAsync_ShouldReturnNoContentStatusCode_WhenRequestAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		var response = await Controller.DeleteCurrentAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithNoContentStatusCode();
	}

	[Fact]
	public async Task DeleteCurrentAsync_ShouldDeleteCurrentRefreshToken_WhenRequestIsValid()
	{
		// Act
		await Controller.DeleteCurrentAsync(_request, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(RefreshTokenId, CancellationToken);

		// Assert
		refreshToken.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteCurrentAsync_ShouldDeleteCurrentRefreshToken_WhenIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Controller.DeleteCurrentAsync(request, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(RefreshTokenId, CancellationToken);

		// Assert
		refreshToken.ShouldBeNull();
	}

	[Theory]
	[RefreshTokenValueDifferentCaseData]
	public async Task DeleteCurrentAsync_ShouldDeleteCurrentRefreshToken_WhenValueIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		await Controller.DeleteCurrentAsync(request, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(RefreshTokenId, CancellationToken);

		// Assert
		refreshToken.ShouldBeNull();
	}
}
