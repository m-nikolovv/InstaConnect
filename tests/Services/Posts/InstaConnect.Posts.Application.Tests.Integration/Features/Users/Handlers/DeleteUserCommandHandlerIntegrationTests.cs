using InstaConnect.Posts.Application.Features.Users.Commands.Delete;
using InstaConnect.Posts.Application.Tests.Features.Users.Builders;
using InstaConnect.Posts.Application.Tests.Integration.Features.Users.Utilities;
using InstaConnect.Posts.Tests.Features.PostCommentImages.Utilities;

namespace InstaConnect.Posts.Application.Tests.Integration.Features.Users.Handlers;

public class DeleteUserCommandHandlerIntegrationTests : BaseUserApplicationCommandIntegrationTest
{
	private readonly DeleteUserCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly DeleteUserCommandRequestBuilder _requestBuilder;
	private readonly DeleteUserCommandRequest _request;

	public DeleteUserCommandHandlerIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();
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

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForIdAsync(request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await Sender.ShouldThrowUserNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldDeleteUser_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteUser_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}

	[Fact]
	public async Task SendAsync_ShouldDeleteUserPosts_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var userPosts = await ServiceScope.GetByIdRangeAsync(UserPostIds, CancellationToken);

		// Assert
		userPosts.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteUserPosts_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var userPosts = await ServiceScope.GetByIdRangeAsync(UserPostIds, CancellationToken);

		// Assert
		userPosts.ShouldBeEmpty();
	}

	[Fact]
	public async Task SendAsync_ShouldDeleteUserPostLikes_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var userPostLikes = await ServiceScope.GetByIdRangeAsync(UserPostLikeIds, CancellationToken);

		// Assert
		userPostLikes.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteUserPostLikes_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var userPostLikes = await ServiceScope.GetByIdRangeAsync(UserPostLikeIds, CancellationToken);

		// Assert
		userPostLikes.ShouldBeEmpty();
	}

	[Fact]
	public async Task SendAsync_ShouldDeleteUserPostComments_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var userPostComments = await ServiceScope.GetByIdRangeAsync(UserPostCommentIds, CancellationToken);

		// Assert
		userPostComments.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteUserPostComments_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var userPostComments = await ServiceScope.GetByIdRangeAsync(UserPostCommentIds, CancellationToken);

		// Assert
		userPostComments.ShouldBeEmpty();
	}

	[Fact]
	public async Task SendAsync_ShouldDeleteUserPostCommentLikes_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var userPostCommentLikes = await ServiceScope.GetByIdRangeAsync(UserPostCommentLikeIds, CancellationToken);

		// Assert
		userPostCommentLikes.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteUserPostCommentLikes_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var userPostCommentLikes = await ServiceScope.GetByIdRangeAsync(UserPostCommentLikeIds, CancellationToken);

		// Assert
		userPostCommentLikes.ShouldBeEmpty();
	}

	[Fact]
	public async Task SendAsync_ShouldDeleteUserPostsPostImages_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var userPostsPostImages = await ServiceScope.GetByIdRangeAsync(UserPostsPostImageIds, CancellationToken);

		// Assert
		userPostsPostImages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteUserPostsPostImages_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var userPostsPostImages = await ServiceScope.GetByIdRangeAsync(UserPostsPostImageIds, CancellationToken);

		// Assert
		userPostsPostImages.ShouldBeEmpty();
	}

	[Fact]
	public async Task SendAsync_ShouldDeleteUserPostsPostLikes_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var userPostsPostLikes = await ServiceScope.GetByIdRangeAsync(UserPostsPostLikeIds, CancellationToken);

		// Assert
		userPostsPostLikes.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteUserPostsPostLikes_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var userPostsPostLikes = await ServiceScope.GetByIdRangeAsync(UserPostsPostLikeIds, CancellationToken);

		// Assert
		userPostsPostLikes.ShouldBeEmpty();
	}

	[Fact]
	public async Task SendAsync_ShouldDeleteUserPostsPostComments_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var userPostsPostComments = await ServiceScope.GetByIdRangeAsync(UserPostsPostCommentIds, CancellationToken);

		// Assert
		userPostsPostComments.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteUserPostsPostComments_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var userPostsPostComments = await ServiceScope.GetByIdRangeAsync(UserPostsPostCommentIds, CancellationToken);

		// Assert
		userPostsPostComments.ShouldBeEmpty();
	}

	[Fact]
	public async Task SendAsync_ShouldDeleteUserPostsPostCommentsPostCommentImages_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var userPostsPostCommentsPostCommentImages = await ServiceScope.GetByIdRangeAsync(UserPostsPostCommentsPostCommentImageIds, CancellationToken);

		// Assert
		userPostsPostCommentsPostCommentImages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteUserPostsPostCommentsPostCommentImages_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var userPostsPostCommentsPostCommentImages = await ServiceScope.GetByIdRangeAsync(UserPostsPostCommentsPostCommentImageIds, CancellationToken);

		// Assert
		userPostsPostCommentsPostCommentImages.ShouldBeEmpty();
	}

	[Fact]
	public async Task SendAsync_ShouldDeleteUserPostsPostCommentsPostCommentLikes_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var userPostsPostCommentsPostCommentLikes = await ServiceScope.GetByIdRangeAsync(UserPostsPostCommentsPostCommentLikeIds, CancellationToken);

		// Assert
		userPostsPostCommentsPostCommentLikes.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteUserPostsPostCommentsPostCommentLikes_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var userPostsPostCommentsPostCommentLikes = await ServiceScope.GetByIdRangeAsync(UserPostsPostCommentsPostCommentLikeIds, CancellationToken);

		// Assert
		userPostsPostCommentsPostCommentLikes.ShouldBeEmpty();
	}

	[Fact]
	public async Task SendAsync_ShouldDeleteUserPostCommentsPostCommentImages_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var userPostCommentsPostCommentImages = await ServiceScope.GetByIdRangeAsync(UserPostCommentsPostCommentImageIds, CancellationToken);

		// Assert
		userPostCommentsPostCommentImages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteUserPostCommentsPostCommentImages_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var userPostCommentsPostCommentImages = await ServiceScope.GetByIdRangeAsync(UserPostCommentsPostCommentImageIds, CancellationToken);

		// Assert
		userPostCommentsPostCommentImages.ShouldBeEmpty();
	}

	[Fact]
	public async Task SendAsync_ShouldDeleteUserPostCommentsPostCommentLikes_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var userPostCommentsPostCommentLikes = await ServiceScope.GetByIdRangeAsync(UserPostCommentsPostCommentLikeIds, CancellationToken);

		// Assert
		userPostCommentsPostCommentLikes.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteUserPostCommentsPostCommentLikes_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var userPostCommentsPostCommentLikes = await ServiceScope.GetByIdRangeAsync(UserPostCommentsPostCommentLikeIds, CancellationToken);

		// Assert
		userPostCommentsPostCommentLikes.ShouldBeEmpty();
	}

}
