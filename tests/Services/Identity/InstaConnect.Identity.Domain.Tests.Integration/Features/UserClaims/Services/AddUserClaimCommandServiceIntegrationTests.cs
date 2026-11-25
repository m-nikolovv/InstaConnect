using InstaConnect.Identity.Domain.Features.UserClaims.Models.Requests;
using InstaConnect.Identity.Domain.Tests.Features.UserClaims.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.UserClaims.Builders;
using InstaConnect.Identity.Domain.Tests.Integration.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.Assertions;

namespace InstaConnect.Identity.Domain.Tests.Integration.Features.UserClaims.Services;

public class AddUserClaimCommandServiceIntegrationTests : BaseUserClaimDomainCommandIntegrationTest
{
	private readonly AddUserClaimCommandBuilderFactory _commandBuilderFactory;
	private readonly AddUserClaimCommandBuilder _commandBuilder;
	private readonly AddUserClaimCommand _command;

	public AddUserClaimCommandServiceIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(User);
		_command = _commandBuilder.Build();
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await Service.ShouldThrowUserNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserClaimAlreadyExistsException_WhenUserClaimAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddAsync(UserClaim, CancellationToken);

		// Assert
		await Service.ShouldThrowUserClaimAlreadyExistsExceptionAsync(_command, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldThrowUserClaimAlreadyExistsException_WhenUserClaimAlreadyExistsAndIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(UserClaim, CancellationToken);
		var command = _commandBuilder.WithId(transformer).Build();

		// Assert
		await Service.ShouldThrowUserClaimAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var userClaim = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, userClaim);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var userClaim = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, userClaim);
	}

	[Fact]
	public async Task AddAsync_ShouldAddUserClaim_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var userClaim = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		userClaim.ShouldSatisfy(_command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddUserClaim_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var userClaim = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		userClaim.ShouldSatisfy(command);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishUserClaimAddedEvent_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var userClaim = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await ClaimEventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_command, userClaim);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishUserClaimAddedEvent_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var userClaim = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await ClaimEventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, userClaim);
	}
}
