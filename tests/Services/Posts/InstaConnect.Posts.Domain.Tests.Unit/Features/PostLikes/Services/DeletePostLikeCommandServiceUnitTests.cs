using InstaConnect.Posts.Domain.Features.PostLikes.Helpers;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.PostLikes.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.PostLikes.Builders;
using InstaConnect.Posts.Domain.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Domain.Tests.Unit.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostLikes.Services;

public class DeletePostLikeCommandServiceUnitTests : BasePostLikeDomainCommandUnitTest
{
	private readonly DeletePostLikeCommandBuilderFactory _commandBuilderFactory;
	private readonly DeletePostLikeCommandBuilder _commandBuilder;
	private readonly DeletePostLikeCommand _command;

	private readonly PostInclude _include;
	private readonly PostLikeInclude _likeInclude;

	private readonly PostLikeCommandService _service;

	public DeletePostLikeCommandServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(PostLike);
		_command = _commandBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithUser().Build();
		_likeInclude = LikeIncludeBuilderFactory.Create().WithUser().WithPost(_include).Build();

		_service = new(Mapper, Factory, EventPublisher, Repository, UserRepository, LikeRepository, IncludeBuilderFactory, LikeIncludeBuilderFactory);

		Repository.SetupExistsByIdAsync(_command, CancellationToken);
		LikeRepository.SetupGetByIdAsync(_command, _likeInclude, PostLike, CancellationToken);
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
	public async Task DeleteAsync_ShouldThrowPostLikeNotFoundException_WhenPostLikeNotFound()
	{
		// Arrange
		LikeRepository.RemoveGetByIdAsync(_command, _likeInclude, PostLike, CancellationToken);

		// Assert
		await _service.ShouldThrowPostLikeNotFoundExceptionAsync(_command, CancellationToken);
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
	public async Task DeleteAsync_ShouldCallTheLikeRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await LikeRepository.ShouldHaveReceivedOneGetByIdAsync(_command, _likeInclude, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheLikeRepositoryDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await LikeRepository.ShouldHaveReceivedOneDeleteAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheEventPublisherPublishAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await EventPublisher.ShouldHaveReceivedOnePublishAsync(_command, PostLike, CancellationToken);
	}
}
