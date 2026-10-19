using InstaConnect.Posts.Domain.Features.PostComments.Helpers;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Builders;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Domain.Tests.Unit.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostComments.Services;

public class UpdatePostCommentCommandServiceUnitTests : BasePostCommentDomainCommandUnitTest
{
	private readonly UpdatePostCommentCommandBuilderFactory _commandBuilderFactory;
	private readonly UpdatePostCommentCommandBuilder _commandBuilder;
	private readonly UpdatePostCommentCommand _command;

	private readonly PostInclude _include;
	private readonly PostCommentInclude _commentInclude;

	private readonly PostCommentCommandService _service;

	public UpdatePostCommentCommandServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(PostComment);
		_command = _commandBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithUser().Build();
		_commentInclude = CommentIncludeBuilderFactory.Create().WithUser().WithPost(_include).WithPostCommentImages().Build();

		_service = new(Mapper, ImageHandler, EventPublisher, Repository, DateTimeProvider, Factory, UserRepository, CommentSummarizer, CommentImageFactory, CommentRepository, IncludeBuilderFactory, CommentImageRepository, CommentIncludeBuilderFactory);

		Repository.SetupExistsByIdAsync(_command, CancellationToken);
		CommentRepository.SetupGetByIdAsync(_command, _commentInclude, PostComment, CancellationToken);
		DateTimeProvider.SetupGetOffsetUtcNow(_command, PostComment);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowPostNotFoundException_WhenPostNotFound()
	{
		// Arrange
		Repository.RemoveExistsByIdAsync(_command, CancellationToken);

		// Assert
		await _service.ShouldThrowPostNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowPostCommentNotFoundException_WhenPostCommentNotFound()
	{
		// Arrange
		CommentRepository.RemoveGetByIdAsync(_command, _commentInclude, PostComment, CancellationToken);

		// Assert
		await _service.ShouldThrowPostCommentNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowPostCommentForbiddenException_WhenPostCommentForbidden()
	{
		// Arrange
		var user = UserBuilderFactory.Create().Build();
		var command = _commandBuilder.WithUserId(user.Id).Build();

		// Assert
		await _service.ShouldThrowPostCommentForbiddenExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, PostComment);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheRepositoryExistsByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneExistsByIdAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheCommentRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await CommentRepository.ShouldHaveReceivedOneGetByIdAsync(_command, _commentInclude, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		DateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow(_command);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheCommentRepositoryUpdateAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await CommentRepository.ShouldHaveReceivedOneUpdateAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheCommentSummarizerSummarizeAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await CommentSummarizer.ShouldHaveReceivedOneSummarizeAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheEventPublisherPublishAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishAsync(_command, PostComment, CancellationToken);
	}
}
