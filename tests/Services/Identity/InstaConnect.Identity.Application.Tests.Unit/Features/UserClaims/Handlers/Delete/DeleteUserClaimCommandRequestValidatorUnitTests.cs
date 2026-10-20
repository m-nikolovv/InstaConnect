using InstaConnect.Common.Domain.Features.AccessTokens.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Base;
using InstaConnect.Identity.Application.Features.UserClaims.Commands.Delete;
using InstaConnect.Identity.Tests.Features.UserClaims.DataAttributes.Claim;

namespace InstaConnect.Identity.Application.Tests.Unit.Features.UserClaims.Handlers.Delete;

public class DeleteUserClaimCommandRequestValidatorUnitTests : BaseUserClaimApplicationCommandUnitTest
{
	private readonly DeleteUserClaimCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly DeleteUserClaimCommandRequestBuilder _requestBuilder;
	private readonly DeleteUserClaimCommandRequest _request;

	private readonly DeleteUserClaimCommandRequestValidator _requestValidator;

	public DeleteUserClaimCommandRequestValidatorUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(UserClaim);
		_request = _requestBuilder.Build();

		_requestValidator = new();
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForId(request, messageTransformer);
	}

	[Theory]
	[UserClaimClaimEmptyWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenClaimIsInvalid(
		IEnumTransformer<ApplicationClaims> transformer, IEnumMessageTransformer<ApplicationClaims> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithClaim(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForClaim(request, messageTransformer);
	}

	[Fact]
	public void TestValidate_ShouldNotHaveAnyValidationErrors_WhenRequestIsValid()
	{
		// Act
		var response = _requestValidator.TestValidate(_request);

		// Assert
		response.ShouldNotHaveAnyValidationErrorProperties();
	}
}
