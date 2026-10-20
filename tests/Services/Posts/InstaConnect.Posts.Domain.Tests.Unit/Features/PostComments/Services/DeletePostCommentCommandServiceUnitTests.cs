namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostComments.Services;

public class DeletePostCommentCommandServiceUnitTests : BasePostCommentDomainCommandUnitTest
{
	private readonly DeletePostCommentCommandBuilderFactory _commandBuilderFactory;
	private readonly DeletePostCommentCommandBuilder _commandBuilder;
	private readonly DeletePostCommentCommand _command;

	private readonly PostInclude _include;
	private readonly PostCommentInclude _commentInclude;

	private readonly PostCommentCommandService _service;

	public DeletePostCommentCommandServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(PostComment);
		_command = _commandBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithUser().Build();
		_commentInclude = CommentIncludeBuilderFactory.Create().WithUser().WithPost(_include).WithPostCommentImages().Build();

		_service = new(Mapper, ImageHandler, EventPublisher, Repository, DateTimeProvider, Factory, UserRepository, CommentSummarizer, CommentImageFactory, CommentRepository, IncludeBuilderFactory, CommentImageRepository, CommentIncludeBuilderFactory);

		Repository.SetupExistsByIdAsync(_command, CancellationToken);
		CommentRepository.SetupGetByIdAsync(_command, _commentInclude, PostComment, CancellationToken);
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
		CommentRepository.RemoveGetByIdAsync(_command, _commentInclude, PostComment, CancellationToken);

		// Assert
		await _service.ShouldThrowPostCommentNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowPostCommentForbiddenException_WhenPostCommentForbidden()
	{
		// Arrange
		var user = UserBuilderFactory.Create().Build();
		var command = _commandBuilder.WithUserId(user.Id).Build();

		// Assert
		await _service.ShouldThrowPostCommentForbiddenExceptionAsync(command, CancellationToken);
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
	public async Task DeleteAsync_ShouldCallTheCommentRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await CommentRepository.ShouldHaveReceivedOneGetByIdAsync(_command, _commentInclude, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCommentRepositoryDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await CommentRepository.ShouldHaveReceivedOneDeleteAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheEventPublisherPublishAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishAsync(_command, PostComment, CancellationToken);
	}
}
