using InstaConnect.Posts.Domain.Features.Users.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.Users.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.Users.Builders;
using InstaConnect.Posts.Domain.Tests.Integration.Features.Users.Utilities;
using InstaConnect.Posts.Tests.Features.PostCommentImages.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.Users.Services;

public class DeleteUserCommandServiceIntegrationTests : BaseUserDomainCommandIntegrationTest
{
	private readonly DeleteUserCommandBuilderFactory _commandBuilderFactory;
	private readonly DeleteUserCommandBuilder _commandBuilder;
	private readonly DeleteUserCommand _command;

	public DeleteUserCommandServiceIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(User);
		_command = _commandBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddRangeAsync(Posts, CancellationToken);
		await ServiceScope.AddRangeAsync(PostLikes, CancellationToken);
		await ServiceScope.AddRangeAsync(PostImages, CancellationToken);
		await ServiceScope.AddRangeAsync(PostComments, CancellationToken);
		await ServiceScope.AddRangeAsync(PostCommentImages, CancellationToken);
		await ServiceScope.AddRangeAsync(PostCommentLikes, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await UserService.ShouldThrowUserNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUser_WhenCommandIsValid()
	{
		// Act
		await UserService.DeleteAsync(_command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteUser_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await UserService.DeleteAsync(command, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserPosts_WhenCommandIsValid()
	{
		// Act
		await UserService.DeleteAsync(_command, CancellationToken);
		var userPosts = await ServiceScope.GetByIdRangeAsync(UserPostIds, CancellationToken);

		// Assert
		userPosts.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteUserPosts_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await UserService.DeleteAsync(command, CancellationToken);
		var userPosts = await ServiceScope.GetByIdRangeAsync(UserPostIds, CancellationToken);

		// Assert
		userPosts.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserPostLikes_WhenCommandIsValid()
	{
		// Act
		await UserService.DeleteAsync(_command, CancellationToken);
		var userPostLikes = await ServiceScope.GetByIdRangeAsync(UserPostLikeIds, CancellationToken);

		// Assert
		userPostLikes.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteUserPostLikes_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await UserService.DeleteAsync(command, CancellationToken);
		var userPostLikes = await ServiceScope.GetByIdRangeAsync(UserPostLikeIds, CancellationToken);

		// Assert
		userPostLikes.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserPostComments_WhenCommandIsValid()
	{
		// Act
		await UserService.DeleteAsync(_command, CancellationToken);
		var userPostComments = await ServiceScope.GetByIdRangeAsync(UserPostCommentIds, CancellationToken);

		// Assert
		userPostComments.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteUserPostComments_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await UserService.DeleteAsync(command, CancellationToken);
		var userPostComments = await ServiceScope.GetByIdRangeAsync(UserPostCommentIds, CancellationToken);

		// Assert
		userPostComments.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserPostCommentLikes_WhenCommandIsValid()
	{
		// Act
		await UserService.DeleteAsync(_command, CancellationToken);
		var userPostCommentLikes = await ServiceScope.GetByIdRangeAsync(UserPostCommentLikeIds, CancellationToken);

		// Assert
		userPostCommentLikes.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteUserPostCommentLikes_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await UserService.DeleteAsync(command, CancellationToken);
		var userPostCommentLikes = await ServiceScope.GetByIdRangeAsync(UserPostCommentLikeIds, CancellationToken);

		// Assert
		userPostCommentLikes.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserPostsPostImages_WhenCommandIsValid()
	{
		// Act
		await UserService.DeleteAsync(_command, CancellationToken);
		var userPostsPostImages = await ServiceScope.GetByIdRangeAsync(UserPostsPostImageIds, CancellationToken);

		// Assert
		userPostsPostImages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteUserPostsPostImages_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await UserService.DeleteAsync(command, CancellationToken);
		var userPostsPostImages = await ServiceScope.GetByIdRangeAsync(UserPostsPostImageIds, CancellationToken);

		// Assert
		userPostsPostImages.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserPostsPostLikes_WhenCommandIsValid()
	{
		// Act
		await UserService.DeleteAsync(_command, CancellationToken);
		var userPostsPostLikes = await ServiceScope.GetByIdRangeAsync(UserPostsPostLikeIds, CancellationToken);

		// Assert
		userPostsPostLikes.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteUserPostsPostLikes_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await UserService.DeleteAsync(command, CancellationToken);
		var userPostsPostLikes = await ServiceScope.GetByIdRangeAsync(UserPostsPostLikeIds, CancellationToken);

		// Assert
		userPostsPostLikes.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserPostsPostComments_WhenCommandIsValid()
	{
		// Act
		await UserService.DeleteAsync(_command, CancellationToken);
		var userPostsPostComments = await ServiceScope.GetByIdRangeAsync(UserPostsPostCommentIds, CancellationToken);

		// Assert
		userPostsPostComments.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteUserPostsPostComments_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await UserService.DeleteAsync(command, CancellationToken);
		var userPostsPostComments = await ServiceScope.GetByIdRangeAsync(UserPostsPostCommentIds, CancellationToken);

		// Assert
		userPostsPostComments.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserPostsPostCommentsPostCommentImages_WhenCommandIsValid()
	{
		// Act
		await UserService.DeleteAsync(_command, CancellationToken);
		var userPostsPostCommentsPostCommentImages = await ServiceScope.GetByIdRangeAsync(UserPostsPostCommentsPostCommentImageIds, CancellationToken);

		// Assert
		userPostsPostCommentsPostCommentImages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteUserPostsPostCommentsPostCommentImages_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await UserService.DeleteAsync(command, CancellationToken);
		var userPostsPostCommentsPostCommentImages = await ServiceScope.GetByIdRangeAsync(UserPostsPostCommentsPostCommentImageIds, CancellationToken);

		// Assert
		userPostsPostCommentsPostCommentImages.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserPostsPostCommentsPostCommentLikes_WhenCommandIsValid()
	{
		// Act
		await UserService.DeleteAsync(_command, CancellationToken);
		var userPostsPostCommentsPostCommentLikes = await ServiceScope.GetByIdRangeAsync(UserPostsPostCommentsPostCommentLikeIds, CancellationToken);

		// Assert
		userPostsPostCommentsPostCommentLikes.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteUserPostsPostCommentsPostCommentLikes_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await UserService.DeleteAsync(command, CancellationToken);
		var userPostsPostCommentsPostCommentLikes = await ServiceScope.GetByIdRangeAsync(UserPostsPostCommentsPostCommentLikeIds, CancellationToken);

		// Assert
		userPostsPostCommentsPostCommentLikes.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserPostCommentsPostCommentImages_WhenCommandIsValid()
	{
		// Act
		await UserService.DeleteAsync(_command, CancellationToken);
		var userPostCommentsPostCommentImages = await ServiceScope.GetByIdRangeAsync(UserPostCommentsPostCommentImageIds, CancellationToken);

		// Assert
		userPostCommentsPostCommentImages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteUserPostCommentsPostCommentImages_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await UserService.DeleteAsync(command, CancellationToken);
		var userPostCommentsPostCommentImages = await ServiceScope.GetByIdRangeAsync(UserPostCommentsPostCommentImageIds, CancellationToken);

		// Assert
		userPostCommentsPostCommentImages.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserPostCommentsPostCommentLikes_WhenCommandIsValid()
	{
		// Act
		await UserService.DeleteAsync(_command, CancellationToken);
		var userPostCommentsPostCommentLikes = await ServiceScope.GetByIdRangeAsync(UserPostCommentsPostCommentLikeIds, CancellationToken);

		// Assert
		userPostCommentsPostCommentLikes.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteUserPostCommentsPostCommentLikes_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await UserService.DeleteAsync(command, CancellationToken);
		var userPostCommentsPostCommentLikes = await ServiceScope.GetByIdRangeAsync(UserPostCommentsPostCommentLikeIds, CancellationToken);

		// Assert
		userPostCommentsPostCommentLikes.ShouldBeEmpty();
	}

}
