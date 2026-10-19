using InstaConnect.Posts.Domain.Features.PostLikes.Helpers;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.PostLikes.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.PostLikes.Builders;
using InstaConnect.Posts.Domain.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Domain.Tests.Unit.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostLikes.Services;

public class AddPostLikeCommandServiceUnitTests : BasePostLikeDomainCommandUnitTest
{
	private readonly AddPostLikeCommandBuilderFactory _commandBuilderFactory;
	private readonly AddPostLikeCommandBuilder _commandBuilder;
	private readonly AddPostLikeCommand _command;

	private readonly PostInclude _include;

	private readonly PostLikeCommandService _service;

	public AddPostLikeCommandServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(Post, User);
		_command = _commandBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithUser().Build();

		_service = new(Mapper, Factory, EventPublisher, Repository, UserRepository, LikeRepository, IncludeBuilderFactory, LikeIncludeBuilderFactory);

		UserRepository.SetupGetByIdAsync(_command, User, CancellationToken);
		Repository.SetupGetByIdAsync(_command, _include, Post, CancellationToken);
		Factory.SetupCreate(_command, PostLike);
		LikeRepository.RemoveGetByIdAsync(_command, PostLike, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		UserRepository.RemoveGetByIdAsync(_command, User, CancellationToken);

		// Assert
		await _service.ShouldThrowUserNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowPostNotFoundException_WhenPostNotFound()
	{
		// Arrange
		Repository.RemoveGetByIdAsync(_command, _include, Post, CancellationToken);

		// Assert
		await _service.ShouldThrowPostNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowPostLikeAlreadyExistsException_WhenPostLikeAlreadyExists()
	{
		// Arrange
		LikeRepository.SetupGetByIdAsync(_command, PostLike, CancellationToken);

		// Assert
		await _service.ShouldThrowPostLikeAlreadyExistsExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _service.AddAsync(_command, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, PostLike);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheUserRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await UserRepository.ShouldHaveReceivedOneGetByIdAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetByIdAsync(_command, _include, CancellationToken);
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
	public async Task AddAsync_ShouldCallTheLikeRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await LikeRepository.ShouldHaveReceivedOneGetByIdAsync(_command, PostLike, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheLikeRepositoryAddAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await LikeRepository.ShouldHaveReceivedOneAddAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheEventPublisherPublishAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishAsync(_command, PostLike, CancellationToken);
	}
}
