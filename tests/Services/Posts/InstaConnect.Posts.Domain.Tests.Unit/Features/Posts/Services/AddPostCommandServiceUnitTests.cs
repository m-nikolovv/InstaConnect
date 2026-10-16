using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;
using InstaConnect.Posts.Domain.Features.Posts.Helpers;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Builders;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Tests.Unit.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Images;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.Posts.Services;

public class AddPostCommandServiceUnitTests : BasePostDomainCommandUnitTest
{
	private readonly AddPostCommandBuilderFactory _commandBuilderFactory;
	private readonly AddPostCommandBuilder _commandBuilder;
	private readonly AddPostCommand _command;

	private readonly PostCommandService _service;

	public AddPostCommandServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(User, Post.PostImages.Count);
		_command = _commandBuilder.Build();

		_service = new(Factory, Mapper, ImageHandler, EventPublisher, ImageFactory, Repository, DateTimeProvider, UserRepository, ImageRepository, IncludeBuilderFactory);

		UserRepository.SetupGetByIdAsync(_command, User, CancellationToken);
		Factory.SetupCreate(_command, Post);
		ImageFactory.SetupCreateRange(_command, Post);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNotFoundException_WhenUserIdIsInvalid()
	{
		// Arrange
		UserRepository.RemoveGetByIdAsync(_command, User, CancellationToken);

		// Assert
		await _service.ShouldThrowUserNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _service.AddAsync(_command, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, Post);
	}

	[Theory]
	[PostImagesEmptyData]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithImages(transformer).Build();

		// Act
		var response = await _service.AddAsync(command, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, Post);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheUserRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await UserRepository.ShouldHaveReceivedOneGetByIdAsync(_command, CancellationToken);
	}

	[Theory]
	[PostImagesEmptyData]
	public async Task AddAsync_ShouldCallTheUserRepositoryGetByIdAsync_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithImages(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		await UserRepository.ShouldHaveReceivedOneGetByIdAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheRepositoryAddAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneAddAsync(_command, CancellationToken);
	}

	[Theory]
	[PostImagesEmptyData]
	public async Task AddAsync_ShouldCallTheRepositoryAddAsync_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithImages(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneAddAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheFactoryCreate_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		Factory.ShouldHaveReceivedOneCreate(_command);
	}

	[Theory]
	[PostImagesEmptyData]
	public async Task AddAsync_ShouldCallTheFactoryCreate_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithImages(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		Factory.ShouldHaveReceivedOneCreate(command);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheEventPublisherPublishAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishAsync(_command, Post, CancellationToken);
	}

	[Theory]
	[PostImagesEmptyData]
	public async Task AddAsync_ShouldCallTheEventPublisherPublishAsync_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithImages(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishAsync(command, Post, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheImageHandlerUploadRangeAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await ImageHandler.ShouldHaveReceivedOneUploadRangeAsync(_command, CancellationToken);
	}

	[Theory]
	[PostImagesEmptyData]
	public async Task AddAsync_ShouldNotCallTheImageHandlerUploadRangeAsync_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithImages(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		await ImageHandler.ShouldHaveReceivedZeroUploadRangeAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheImageFactoryCreateRange_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		ImageFactory.ShouldHaveReceivedOneCreateRange(_command, Post);
	}

	[Theory]
	[PostImagesEmptyData]
	public async Task AddAsync_ShouldNotCallTheImageFactoryCreateRange_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithImages(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		ImageFactory.ShouldHaveReceivedZeroCreateRange(command, Post);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheImageRepositoryAddRangeAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await ImageRepository.ShouldHaveReceivedOneAddRangeAsync(_command, CancellationToken);
	}

	[Theory]
	[PostImagesEmptyData]
	public async Task AddAsync_ShouldNotCallTheImageRepositoryAddRangeAsync_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithImages(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		await ImageRepository.ShouldHaveReceivedZeroAddRangeAsync(command, CancellationToken);
	}
}
