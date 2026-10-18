using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;
using InstaConnect.Posts.Domain.Features.PostComments.Helpers;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Builders;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Domain.Tests.Unit.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.Images;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostComments.Services;

public class AddPostCommentCommandServiceUnitTests : BasePostCommentDomainCommandUnitTest
{
	private readonly AddPostCommentCommandBuilderFactory _commandBuilderFactory;
	private readonly AddPostCommentCommandBuilder _commandBuilder;
	private readonly AddPostCommentCommand _command;

	private readonly PostInclude _include;

	private readonly PostCommentCommandService _service;

	public AddPostCommentCommandServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(Post, User, PostComment.PostCommentImages.Count);
		_command = _commandBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithUser().Build();

		_service = new(Mapper, ImageHandler, EventPublisher, Repository, DateTimeProvider, Factory, UserRepository, CommentSummarizer, CommentImageFactory, CommentRepository, IncludeBuilderFactory, CommentImageRepository, CommentIncludeBuilderFactory);

		UserRepository.SetupGetByIdAsync(_command, User, CancellationToken);
		Repository.SetupGetByIdAsync(_command, _include, Post, CancellationToken);
		Factory.SetupCreate(_command, PostComment);
		CommentImageFactory.SetupCreateRange(_command, PostComment);
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
	public async Task AddAsync_ShouldThrowPostNotFoundException_WhenIdIsInvalid()
	{
		// Arrange
		Repository.RemoveGetByIdAsync(_command, _include, Post, CancellationToken);

		// Assert
		await _service.ShouldThrowPostNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _service.AddAsync(_command, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, PostComment);
	}

	[Theory]
	[PostCommentImagesEmptyData]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithImages(transformer).Build();

		// Act
		var response = await _service.AddAsync(command, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, PostComment);
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
	[PostCommentImagesEmptyData]
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
	public async Task AddAsync_ShouldCallTheRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetByIdAsync(_command, _include, CancellationToken);
	}

	[Theory]
	[PostCommentImagesEmptyData]
	public async Task AddAsync_ShouldCallTheRepositoryGetByIdAsync_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithImages(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetByIdAsync(command, _include, CancellationToken);
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
	[PostCommentImagesEmptyData]
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
	public async Task AddAsync_ShouldCallTheCommentRepositoryAddAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await CommentRepository.ShouldHaveReceivedOneAddAsync(_command, CancellationToken);
	}

	[Theory]
	[PostCommentImagesEmptyData]
	public async Task AddAsync_ShouldCallTheCommentRepositoryAddAsync_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithImages(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		await CommentRepository.ShouldHaveReceivedOneAddAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheCommentSummarizerSummarizeAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await CommentSummarizer.ShouldHaveReceivedOneSummarizeAsync(_command, CancellationToken);
	}

	[Theory]
	[PostCommentImagesEmptyData]
	public async Task AddAsync_ShouldCallTheCommentSummarizerSummarizeAsync_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithImages(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		await CommentSummarizer.ShouldHaveReceivedOneSummarizeAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheEventPublisherPublishAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishAsync(_command, PostComment, CancellationToken);
	}

	[Theory]
	[PostCommentImagesEmptyData]
	public async Task AddAsync_ShouldCallTheEventPublisherPublishAsync_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithImages(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishAsync(command, PostComment, CancellationToken);
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
	[PostCommentImagesEmptyData]
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
	public async Task AddAsync_ShouldCallTheCommentImageFactoryCreateRange_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		CommentImageFactory.ShouldHaveReceivedOneCreateRange(_command, PostComment);
	}

	[Theory]
	[PostCommentImagesEmptyData]
	public async Task AddAsync_ShouldNotCallTheCommentImageFactoryCreateRange_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithImages(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		CommentImageFactory.ShouldHaveReceivedZeroCreateRange(command, PostComment);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheCommentImageRepositoryAddRangeAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await CommentImageRepository.ShouldHaveReceivedOneAddRangeAsync(_command, CancellationToken);
	}

	[Theory]
	[PostCommentImagesEmptyData]
	public async Task AddAsync_ShouldNotCallTheCommentImageRepositoryAddRangeAsync_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithImages(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		await CommentImageRepository.ShouldHaveReceivedZeroAddRangeAsync(command, CancellationToken);
	}
}
