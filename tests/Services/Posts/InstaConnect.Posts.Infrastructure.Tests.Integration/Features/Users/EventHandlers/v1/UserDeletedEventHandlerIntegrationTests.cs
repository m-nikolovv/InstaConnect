using InstaConnect.Common.Infrastructure.Tests.Features.Utilities;
using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Posts.Infrastructure.Features.Users.EventHandlers;
using InstaConnect.Posts.Infrastructure.Tests.Features.Users.Builders;
using InstaConnect.Posts.Infrastructure.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.Users.EventHandlers.v1;

public class UserDeletedEventHandlerIntegrationTests : BaseUserInfrastructureEventHandlerIntegrationTest
{
	private readonly UserDeletedEventRequestBuilderFactory _requestBuilderFactory;
	private readonly UserDeletedEventRequestBuilder _requestBuilder;
	private readonly UserDeletedEventRequest _request;

	private readonly UserDeletedEventHandler _handler;

	public UserDeletedEventHandlerIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();

		_handler = ServiceScope.GetUserDeletedEventHandler();
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
	public async Task Consume_ShouldThrowValidationException_WhenIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Assert
		await _handler.ShouldThrowInvalidValidationExceptionForIdAsync(request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task Consume_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await _handler.ShouldThrowUserNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task Consume_ShouldDeleteUser_WhenRequestIsValid()
	{
		// Act
		await _handler.Consume(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task Consume_ShouldDeleteUser_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await _handler.Consume(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}

	[Fact]
	public async Task Consume_ShouldDeleteUserPosts_WhenRequestIsValid()
	{
		// Act
		await _handler.Consume(_request, CancellationToken);
		var userPosts = await ServiceScope.GetByIdRangeAsync(UserPostIds, CancellationToken);

		// Assert
		userPosts.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task Consume_ShouldDeleteUserPosts_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await _handler.Consume(request, CancellationToken);
		var userPosts = await ServiceScope.GetByIdRangeAsync(UserPostIds, CancellationToken);

		// Assert
		userPosts.ShouldBeEmpty();
	}

	[Fact]
	public async Task Consume_ShouldDeleteUserPostLikes_WhenRequestIsValid()
	{
		// Act
		await _handler.Consume(_request, CancellationToken);
		var userPostLikes = await ServiceScope.GetByIdRangeAsync(UserPostLikeIds, CancellationToken);

		// Assert
		userPostLikes.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task Consume_ShouldDeleteUserPostLikes_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await _handler.Consume(request, CancellationToken);
		var userPostLikes = await ServiceScope.GetByIdRangeAsync(UserPostLikeIds, CancellationToken);

		// Assert
		userPostLikes.ShouldBeEmpty();
	}

	[Fact]
	public async Task Consume_ShouldDeleteUserPostComments_WhenRequestIsValid()
	{
		// Act
		await _handler.Consume(_request, CancellationToken);
		var userPostComments = await ServiceScope.GetByIdRangeAsync(UserPostCommentIds, CancellationToken);

		// Assert
		userPostComments.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task Consume_ShouldDeleteUserPostComments_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await _handler.Consume(request, CancellationToken);
		var userPostComments = await ServiceScope.GetByIdRangeAsync(UserPostCommentIds, CancellationToken);

		// Assert
		userPostComments.ShouldBeEmpty();
	}

	[Fact]
	public async Task Consume_ShouldDeleteUserPostCommentLikes_WhenRequestIsValid()
	{
		// Act
		await _handler.Consume(_request, CancellationToken);
		var userPostCommentLikes = await ServiceScope.GetByIdRangeAsync(UserPostCommentLikeIds, CancellationToken);

		// Assert
		userPostCommentLikes.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task Consume_ShouldDeleteUserPostCommentLikes_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await _handler.Consume(request, CancellationToken);
		var userPostCommentLikes = await ServiceScope.GetByIdRangeAsync(UserPostCommentLikeIds, CancellationToken);

		// Assert
		userPostCommentLikes.ShouldBeEmpty();
	}

	[Fact]
	public async Task Consume_ShouldDeleteUserPostsPostImages_WhenRequestIsValid()
	{
		// Act
		await _handler.Consume(_request, CancellationToken);
		var userPostsPostImages = await ServiceScope.GetByIdRangeAsync(UserPostsPostImageIds, CancellationToken);

		// Assert
		userPostsPostImages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task Consume_ShouldDeleteUserPostsPostImages_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await _handler.Consume(request, CancellationToken);
		var userPostsPostImages = await ServiceScope.GetByIdRangeAsync(UserPostsPostImageIds, CancellationToken);

		// Assert
		userPostsPostImages.ShouldBeEmpty();
	}

	[Fact]
	public async Task Consume_ShouldDeleteUserPostsPostLikes_WhenRequestIsValid()
	{
		// Act
		await _handler.Consume(_request, CancellationToken);
		var userPostsPostLikes = await ServiceScope.GetByIdRangeAsync(UserPostsPostLikeIds, CancellationToken);

		// Assert
		userPostsPostLikes.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task Consume_ShouldDeleteUserPostsPostLikes_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await _handler.Consume(request, CancellationToken);
		var userPostsPostLikes = await ServiceScope.GetByIdRangeAsync(UserPostsPostLikeIds, CancellationToken);

		// Assert
		userPostsPostLikes.ShouldBeEmpty();
	}

	[Fact]
	public async Task Consume_ShouldDeleteUserPostsPostComments_WhenRequestIsValid()
	{
		// Act
		await _handler.Consume(_request, CancellationToken);
		var userPostsPostComments = await ServiceScope.GetByIdRangeAsync(UserPostsPostCommentIds, CancellationToken);

		// Assert
		userPostsPostComments.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task Consume_ShouldDeleteUserPostsPostComments_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await _handler.Consume(request, CancellationToken);
		var userPostsPostComments = await ServiceScope.GetByIdRangeAsync(UserPostsPostCommentIds, CancellationToken);

		// Assert
		userPostsPostComments.ShouldBeEmpty();
	}

	[Fact]
	public async Task Consume_ShouldDeleteUserPostsPostCommentsPostCommentImages_WhenRequestIsValid()
	{
		// Act
		await _handler.Consume(_request, CancellationToken);
		var userPostsPostCommentsPostCommentImages = await ServiceScope.GetByIdRangeAsync(UserPostsPostCommentsPostCommentImageIds, CancellationToken);

		// Assert
		userPostsPostCommentsPostCommentImages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task Consume_ShouldDeleteUserPostsPostCommentsPostCommentImages_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await _handler.Consume(request, CancellationToken);
		var userPostsPostCommentsPostCommentImages = await ServiceScope.GetByIdRangeAsync(UserPostsPostCommentsPostCommentImageIds, CancellationToken);

		// Assert
		userPostsPostCommentsPostCommentImages.ShouldBeEmpty();
	}

	[Fact]
	public async Task Consume_ShouldDeleteUserPostsPostCommentsPostCommentLikes_WhenRequestIsValid()
	{
		// Act
		await _handler.Consume(_request, CancellationToken);
		var userPostsPostCommentsPostCommentLikes = await ServiceScope.GetByIdRangeAsync(UserPostsPostCommentsPostCommentLikeIds, CancellationToken);

		// Assert
		userPostsPostCommentsPostCommentLikes.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task Consume_ShouldDeleteUserPostsPostCommentsPostCommentLikes_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await _handler.Consume(request, CancellationToken);
		var userPostsPostCommentsPostCommentLikes = await ServiceScope.GetByIdRangeAsync(UserPostsPostCommentsPostCommentLikeIds, CancellationToken);

		// Assert
		userPostsPostCommentsPostCommentLikes.ShouldBeEmpty();
	}

	[Fact]
	public async Task Consume_ShouldDeleteUserPostCommentsPostCommentImages_WhenRequestIsValid()
	{
		// Act
		await _handler.Consume(_request, CancellationToken);
		var userPostCommentsPostCommentImages = await ServiceScope.GetByIdRangeAsync(UserPostCommentsPostCommentImageIds, CancellationToken);

		// Assert
		userPostCommentsPostCommentImages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task Consume_ShouldDeleteUserPostCommentsPostCommentImages_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await _handler.Consume(request, CancellationToken);
		var userPostCommentsPostCommentImages = await ServiceScope.GetByIdRangeAsync(UserPostCommentsPostCommentImageIds, CancellationToken);

		// Assert
		userPostCommentsPostCommentImages.ShouldBeEmpty();
	}

	[Fact]
	public async Task Consume_ShouldDeleteUserPostCommentsPostCommentLikes_WhenRequestIsValid()
	{
		// Act
		await _handler.Consume(_request, CancellationToken);
		var userPostCommentsPostCommentLikes = await ServiceScope.GetByIdRangeAsync(UserPostCommentsPostCommentLikeIds, CancellationToken);

		// Assert
		userPostCommentsPostCommentLikes.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task Consume_ShouldDeleteUserPostCommentsPostCommentLikes_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await _handler.Consume(request, CancellationToken);
		var userPostCommentsPostCommentLikes = await ServiceScope.GetByIdRangeAsync(UserPostCommentsPostCommentLikeIds, CancellationToken);

		// Assert
		userPostCommentsPostCommentLikes.ShouldBeEmpty();
	}

}
