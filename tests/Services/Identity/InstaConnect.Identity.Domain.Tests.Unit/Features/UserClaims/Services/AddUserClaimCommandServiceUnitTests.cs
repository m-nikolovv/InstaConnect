using InstaConnect.Identity.Domain.Features.UserClaims.Helpers;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Requests;
using InstaConnect.Identity.Domain.Tests.Features.UserClaims.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.UserClaims.Builders;
using InstaConnect.Identity.Domain.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Domain.Tests.Unit.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Unit.Features.UserClaims.Services;

public class AddUserClaimCommandServiceUnitTests : BaseUserClaimDomainCommandUnitTest
{
	private readonly AddUserClaimCommandBuilderFactory _commandBuilderFactory;
	private readonly AddUserClaimCommandBuilder _commandBuilder;
	private readonly AddUserClaimCommand _command;

	private readonly UserClaimCommandService _service;

	public AddUserClaimCommandServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(User);
		_command = _commandBuilder.Build();

		_service = new(Mapper, EventPublisher, Factory, Repository, ClaimRepository, IncludeBuilderFactory);

		Repository.SetupGetByIdAsync(_command, User, CancellationToken);
		Factory.SetupCreate(_command, UserClaim);
		ClaimRepository.RemoveGetByIdAsync(_command, UserClaim, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		Repository.RemoveGetByIdAsync(_command, User, CancellationToken);

		// Assert
		await _service.ShouldThrowUserNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserClaimAlreadyExistsException_WhenUserClaimAlreadyExists()
	{
		// Arrange
		ClaimRepository.SetupGetByIdAsync(_command, UserClaim, CancellationToken);

		// Assert
		await _service.ShouldThrowUserClaimAlreadyExistsExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _service.AddAsync(_command, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, UserClaim);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetByIdAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheFactoryCreate_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		Factory.ShouldHaveReceivedOneCreate(_command);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheClaimRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await ClaimRepository.ShouldHaveReceivedOneGetByIdAsync(_command, UserClaim, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheClaimRepositoryAddAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await ClaimRepository.ShouldHaveReceivedOneAddAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheEventPublisherPublishAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishAsync(_command, UserClaim, CancellationToken);
	}
}
