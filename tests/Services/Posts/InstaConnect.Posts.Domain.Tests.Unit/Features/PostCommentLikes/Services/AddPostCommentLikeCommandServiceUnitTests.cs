namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostCommentLikes.Services;

public class AddPostCommentLikeCommandServiceUnitTests : BasePostCommentLikeDomainCommandUnitTest
{
	private readonly AddPostCommentLikeCommandBuilderFactory _commandBuilderFactory;
	private readonly AddPostCommentLikeCommandBuilder _commandBuilder;
	private readonly AddPostCommentLikeCommand _command;

	private readonly PostInclude _include;
	private readonly PostCommentInclude _commentInclude;

	private readonly PostCommentLikeCommandService _service;

	public AddPostCommentLikeCommandServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(PostComment, User);
		_command = _commandBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithUser().Build();
		_commentInclude = CommentIncludeBuilderFactory.Create().WithUser().WithPost(_include).Build();

		_service = new(Mapper, EventPublisher, Repository, UserRepository, Factory, CommentRepository, IncludeBuilderFactory, CommentLikeRepository, CommentIncludeBuilderFactory, CommentLikeIncludeBuilderFactory);

		UserRepository.SetupGetByIdAsync(_command, User, CancellationToken);
		Repository.SetupExistsByIdAsync(_command, CancellationToken);
		CommentRepository.SetupGetByIdAsync(_command, _commentInclude, PostComment, CancellationToken);
		Factory.SetupCreate(_command, PostCommentLike);
		CommentLikeRepository.RemoveGetByIdAsync(_command, PostCommentLike, CancellationToken);
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
		Repository.RemoveExistsByIdAsync(_command, CancellationToken);

		// Assert
		await _service.ShouldThrowPostNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowPostCommentNotFoundException_WhenPostCommentNotFound()
	{
		// Arrange
		CommentRepository.RemoveGetByIdAsync(_command, _commentInclude, PostComment, CancellationToken);

		// Assert
		await _service.ShouldThrowPostCommentNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowPostCommentLikeAlreadyExistsException_WhenPostCommentLikeAlreadyExists()
	{
		// Arrange
		CommentLikeRepository.SetupGetByIdAsync(_command, PostCommentLike, CancellationToken);

		// Assert
		await _service.ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _service.AddAsync(_command, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, PostCommentLike);
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
	public async Task AddAsync_ShouldCallTheRepositoryExistsByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneExistsByIdAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheCommentRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await CommentRepository.ShouldHaveReceivedOneGetByIdAsync(_command, _commentInclude, CancellationToken);
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
	public async Task AddAsync_ShouldCallTheCommentLikeRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await CommentLikeRepository.ShouldHaveReceivedOneGetByIdAsync(_command, PostCommentLike, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheCommentLikeRepositoryAddAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await CommentLikeRepository.ShouldHaveReceivedOneAddAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheEventPublisherPublishAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishAsync(_command, PostCommentLike, CancellationToken);
	}
}
