namespace InstaConnect.Posts.Domain.Tests.Unit.Features.Posts.Services;

public class DeletePostCommandServiceUnitTests : BasePostDomainCommandUnitTest
{
	private readonly DeletePostCommandBuilderFactory _commandBuilderFactory;
	private readonly DeletePostCommandBuilder _commandBuilder;
	private readonly DeletePostCommand _command;

	private readonly PostInclude _include;

	private readonly PostCommandService _service;

	public DeletePostCommandServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(Post);
		_command = _commandBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithUser().WithPostImages().Build();

		_service = new(Factory, Mapper, Summarizer, ImageHandler, EventPublisher, ImageFactory, Repository, DateTimeProvider, UserRepository, ImageRepository, IncludeBuilderFactory);

		Repository.SetupGetByIdAsync(_command, _include, Post, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowPostNotFoundException_WhenPostNotFound()
	{
		// Arrange
		Repository.RemoveGetByIdAsync(_command, _include, Post, CancellationToken);

		// Assert
		await _service.ShouldThrowPostNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowPostForbiddenException_WhenPostForbidden()
	{
		// Arrange
		var user = UserBuilderFactory.Create().Build();
		var command = _commandBuilder.WithUserId(user.Id).Build();

		// Assert
		await _service.ShouldThrowPostForbiddenExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetByIdAsync(_command, _include, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheRepositoryDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneDeleteAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheEventPublisherPublishAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishAsync(_command, Post, CancellationToken);
	}
}
