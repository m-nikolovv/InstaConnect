namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostCommentLikes.Services;

public class DeletePostCommentLikeCommandServiceUnitTests : BasePostCommentLikeDomainCommandUnitTest
{
	private readonly DeletePostCommentLikeCommandBuilderFactory _commandBuilderFactory;
	private readonly DeletePostCommentLikeCommandBuilder _commandBuilder;
	private readonly DeletePostCommentLikeCommand _command;

	private readonly PostInclude _include;
	private readonly PostCommentInclude _commentInclude;
	private readonly PostCommentLikeInclude _commentLikeInclude;

	private readonly PostCommentLikeCommandService _service;

	public DeletePostCommentLikeCommandServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(PostCommentLike);
		_command = _commandBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithUser().Build();
		_commentInclude = CommentIncludeBuilderFactory.Create().WithUser().WithPost(_include).Build();
		_commentLikeInclude = CommentLikeIncludeBuilderFactory.Create().WithUser().WithPostComment(_commentInclude).Build();

		_service = new(Mapper, EventPublisher, Repository, UserRepository, Factory, CommentRepository, IncludeBuilderFactory, CommentLikeRepository, CommentIncludeBuilderFactory, CommentLikeIncludeBuilderFactory);

		Repository.SetupExistsByIdAsync(_command, CancellationToken);
		CommentRepository.SetupExistsByIdAsync(_command, CancellationToken);
		CommentLikeRepository.SetupGetByIdAsync(_command, _commentLikeInclude, PostCommentLike, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowPostNotFoundException_WhenPostNotFound()
	{
		// Arrange
		Repository.RemoveExistsByIdAsync(_command, CancellationToken);

		// Assert
		await _service.ShouldThrowPostNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowPostCommentNotFoundException_WhenPostCommentNotFound()
	{
		// Arrange
		CommentRepository.RemoveExistsByIdAsync(_command, CancellationToken);

		// Assert
		await _service.ShouldThrowPostCommentNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowPostCommentLikeNotFoundException_WhenPostCommentLikeNotFound()
	{
		// Arrange
		CommentLikeRepository.RemoveGetByIdAsync(_command, _commentLikeInclude, PostCommentLike, CancellationToken);

		// Assert
		await _service.ShouldThrowPostCommentLikeNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheRepositoryExistsByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneExistsByIdAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCommentRepositoryExistsByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await CommentRepository.ShouldHaveReceivedOneExistsByIdAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCommentLikeRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await CommentLikeRepository.ShouldHaveReceivedOneGetByIdAsync(_command, _commentLikeInclude, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCommentLikeRepositoryDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await CommentLikeRepository.ShouldHaveReceivedOneDeleteAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheEventPublisherPublishAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishAsync(_command, PostCommentLike, CancellationToken);
	}
}
