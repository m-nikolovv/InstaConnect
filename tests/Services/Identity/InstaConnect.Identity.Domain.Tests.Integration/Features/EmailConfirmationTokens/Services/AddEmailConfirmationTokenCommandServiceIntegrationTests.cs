using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Builders;
using InstaConnect.Identity.Domain.Tests.Features.Users.Assertions;
using InstaConnect.Identity.Domain.Tests.Integration.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Name;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Integration.Features.EmailConfirmationTokens.Services;

public class AddEmailConfirmationTokenCommandServiceIntegrationTests : BaseEmailConfirmationTokenDomainCommandIntegrationTest
{
	private readonly AddEmailConfirmationTokenCommandBuilderFactory _commandBuilderFactory;
	private readonly AddEmailConfirmationTokenCommandBuilder _commandBuilder;
	private readonly AddEmailConfirmationTokenCommand _command;

	public AddEmailConfirmationTokenCommandServiceIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(User);
		_command = _commandBuilder.Build();
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNameNotFoundException_WhenUserNameNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await Service.ShouldThrowUserNameNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNameEmailAlreadyConfirmedException_WhenUserNameEmailAlreadyConfirmed()
	{
		// Arrange
		var updatedUser = UserBuilder.WithConfirmedEmail().Build();
		await ServiceScope.UpdateAsync(updatedUser, CancellationToken);

		// Assert
		await Service.ShouldThrowUserNameEmailAlreadyConfirmedExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var emailConfirmationToken = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, emailConfirmationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var emailConfirmationToken = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, emailConfirmationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldAddEmailConfirmationToken_WhenCommandIsValid()
	{
		// Act
		await Service.AddAsync(_command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldSatisfy(_command);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task AddAsync_ShouldAddEmailConfirmationToken_WhenCommandAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();

		// Act
		await Service.AddAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldSatisfy(command);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishEmailConfirmationTokenAddedEvent_WhenCommandIsValid()
	{
		// Act
		await Service.AddAsync(_command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedAddedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(_command, user.EmailConfirmationTokens);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task AddAsync_ShouldPublishEmailConfirmationTokenAddedEvent_WhenCommandAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();

		// Act
		await Service.AddAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedAddedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(command, user.EmailConfirmationTokens);
	}
}
