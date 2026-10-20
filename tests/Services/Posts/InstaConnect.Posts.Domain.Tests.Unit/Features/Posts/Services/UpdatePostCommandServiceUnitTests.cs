namespace InstaConnect.Posts.Domain.Tests.Unit.Features.Posts.Services;

public class UpdatePostCommandServiceUnitTests : BasePostDomainCommandUnitTest
{
	private readonly UpdatePostCommandBuilderFactory _commandBuilderFactory;
	private readonly UpdatePostCommandBuilder _commandBuilder;
	private readonly UpdatePostCommand _command;

	private readonly PostInclude _include;

	private readonly PostCommandService _service;

	public UpdatePostCommandServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(Post);
		_command = _commandBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithUser().WithPostImages().Build();

		_service = new(Factory, Mapper, Summarizer, ImageHandler, EventPublisher, ImageFactory, Repository, DateTimeProvider, UserRepository, ImageRepository, IncludeBuilderFactory);

		Repository.SetupGetByIdAsync(_command, _include, Post, CancellationToken);
		DateTimeProvider.SetupGetOffsetUtcNow(_command, Post);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowPostNotFoundException_WhenPostNotFound()
	{
		// Arrange
		Repository.RemoveGetByIdAsync(_command, _include, Post, CancellationToken);

		// Assert
		await _service.ShouldThrowPostNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowPostForbiddenException_WhenPostForbidden()
	{
		// Arrange
		var user = UserBuilderFactory.Create().Build();
		var command = _commandBuilder.WithUserId(user.Id).Build();

		// Assert
		await _service.ShouldThrowPostForbiddenExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, Post);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneGetByIdAsync(_command, _include, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheRepositoryUpdateAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldHaveReceivedOneUpdateAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheSummarizerSummarizeAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await Summarizer.ShouldHaveReceivedOneSummarizeAsync(_command, CancellationToken);
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
	public async Task UpdateAsync_ShouldCallTheEventPublisherPublishAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishAsync(_command, Post, CancellationToken);
	}
}
