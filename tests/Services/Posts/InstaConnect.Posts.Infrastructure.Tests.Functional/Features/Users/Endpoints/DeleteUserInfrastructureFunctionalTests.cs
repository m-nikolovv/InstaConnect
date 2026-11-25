using InstaConnect.Common.Tests.Features.Assertions;
using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Identity.Events.Features.Users;
using InstaConnect.Posts.Infrastructure.Tests.Features.Users.Assertions;
using InstaConnect.Posts.Infrastructure.Tests.Features.Users.Builders;
using InstaConnect.Posts.Infrastructure.Tests.Functional.Features.Users.Utilities;
using InstaConnect.Posts.Tests.Features.Common.Utilities;
using InstaConnect.Posts.Tests.Features.PostCommentImages.Utilities;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.PostImages.Utilities;
using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Users.Assertions;
using InstaConnect.Posts.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Functional.Features.Users.Endpoints;

public class DeleteUserInfrastructureFunctionalTests : BaseUserInfrastructureCommandFunctionalTest
{
	private readonly UserDeletedEventRequestBuilderFactory _requestBuilderFactory;
	private readonly UserDeletedEventRequestBuilder _requestBuilder;
	private readonly UserDeletedEventRequest _request;

	public DeleteUserInfrastructureFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
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
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task PublishAsync_ShouldFaultUserDeletedEvent_WhenIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.FaultedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Fact]
	public async Task PublishAsync_ShouldFaultUserDeletedEvent_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		await EventPublisher.PublishAsync(_request, CancellationToken);
		var eventRequest = await UserEventClient.FaultedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request);
	}

	[Fact]
	public async Task PublishAsync_ShouldConsumeUserDeletedEvent_WhenRequestIsValid()
	{
		// Act
		await EventPublisher.PublishAsync(_request, CancellationToken);
		var eventRequest = await UserEventClient.FaultedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task PublishAsync_ShouldConsumeUserDeletedEvent_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var eventRequest = await UserEventClient.ConsumedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request);
	}

	[Fact]
	public async Task PublishAsync_ShouldDeleteUser_WhenRequestIsValid()
	{
		// Act
		await EventPublisher.PublishAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task PublishAsync_ShouldDeleteUser_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}

	[Fact]
	public async Task PublishAsync_ShouldDeleteUserPosts_WhenRequestIsValid()
	{
		// Act
		await EventPublisher.PublishAsync(_request, CancellationToken);
		var userPosts = await ServiceScope.GetByIdRangeAsync(UserPostIds, CancellationToken);

		// Assert
		userPosts.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task PublishAsync_ShouldDeleteUserPosts_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var userPosts = await ServiceScope.GetByIdRangeAsync(UserPostIds, CancellationToken);

		// Assert
		userPosts.ShouldBeEmpty();
	}

	[Fact]
	public async Task PublishAsync_ShouldDeleteUserPostLikes_WhenRequestIsValid()
	{
		// Act
		await EventPublisher.PublishAsync(_request, CancellationToken);
		var userPostLikes = await ServiceScope.GetByIdRangeAsync(UserPostLikeIds, CancellationToken);

		// Assert
		userPostLikes.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task PublishAsync_ShouldDeleteUserPostLikes_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var userPostLikes = await ServiceScope.GetByIdRangeAsync(UserPostLikeIds, CancellationToken);

		// Assert
		userPostLikes.ShouldBeEmpty();
	}

	[Fact]
	public async Task PublishAsync_ShouldDeleteUserPostComments_WhenRequestIsValid()
	{
		// Act
		await EventPublisher.PublishAsync(_request, CancellationToken);
		var userPostComments = await ServiceScope.GetByIdRangeAsync(UserPostCommentIds, CancellationToken);

		// Assert
		userPostComments.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task PublishAsync_ShouldDeleteUserPostComments_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var userPostComments = await ServiceScope.GetByIdRangeAsync(UserPostCommentIds, CancellationToken);

		// Assert
		userPostComments.ShouldBeEmpty();
	}

	[Fact]
	public async Task PublishAsync_ShouldDeleteUserPostCommentLikes_WhenRequestIsValid()
	{
		// Act
		await EventPublisher.PublishAsync(_request, CancellationToken);
		var userPostCommentLikes = await ServiceScope.GetByIdRangeAsync(UserPostCommentLikeIds, CancellationToken);

		// Assert
		userPostCommentLikes.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task PublishAsync_ShouldDeleteUserPostCommentLikes_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var userPostCommentLikes = await ServiceScope.GetByIdRangeAsync(UserPostCommentLikeIds, CancellationToken);

		// Assert
		userPostCommentLikes.ShouldBeEmpty();
	}

	[Fact]
	public async Task PublishAsync_ShouldDeleteUserPostsPostImages_WhenRequestIsValid()
	{
		// Act
		await EventPublisher.PublishAsync(_request, CancellationToken);
		var userPostsPostImages = await ServiceScope.GetByIdRangeAsync(UserPostsPostImageIds, CancellationToken);

		// Assert
		userPostsPostImages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task PublishAsync_ShouldDeleteUserPostsPostImages_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var userPostsPostImages = await ServiceScope.GetByIdRangeAsync(UserPostsPostImageIds, CancellationToken);

		// Assert
		userPostsPostImages.ShouldBeEmpty();
	}

	[Fact]
	public async Task PublishAsync_ShouldDeleteUserPostsPostLikes_WhenRequestIsValid()
	{
		// Act
		await EventPublisher.PublishAsync(_request, CancellationToken);
		var userPostsPostLikes = await ServiceScope.GetByIdRangeAsync(UserPostsPostLikeIds, CancellationToken);

		// Assert
		userPostsPostLikes.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task PublishAsync_ShouldDeleteUserPostsPostLikes_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var userPostsPostLikes = await ServiceScope.GetByIdRangeAsync(UserPostsPostLikeIds, CancellationToken);

		// Assert
		userPostsPostLikes.ShouldBeEmpty();
	}

	[Fact]
	public async Task PublishAsync_ShouldDeleteUserPostsPostComments_WhenRequestIsValid()
	{
		// Act
		await EventPublisher.PublishAsync(_request, CancellationToken);
		var userPostsPostComments = await ServiceScope.GetByIdRangeAsync(UserPostsPostCommentIds, CancellationToken);

		// Assert
		userPostsPostComments.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task PublishAsync_ShouldDeleteUserPostsPostComments_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var userPostsPostComments = await ServiceScope.GetByIdRangeAsync(UserPostsPostCommentIds, CancellationToken);

		// Assert
		userPostsPostComments.ShouldBeEmpty();
	}

	[Fact]
	public async Task PublishAsync_ShouldDeleteUserPostsPostCommentsPostCommentImages_WhenRequestIsValid()
	{
		// Act
		await EventPublisher.PublishAsync(_request, CancellationToken);
		var userPostsPostCommentsPostCommentImages = await ServiceScope.GetByIdRangeAsync(UserPostsPostCommentsPostCommentImageIds, CancellationToken);

		// Assert
		userPostsPostCommentsPostCommentImages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task PublishAsync_ShouldDeleteUserPostsPostCommentsPostCommentImages_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var userPostsPostCommentsPostCommentImages = await ServiceScope.GetByIdRangeAsync(UserPostsPostCommentsPostCommentImageIds, CancellationToken);

		// Assert
		userPostsPostCommentsPostCommentImages.ShouldBeEmpty();
	}

	[Fact]
	public async Task PublishAsync_ShouldDeleteUserPostsPostCommentsPostCommentLikes_WhenRequestIsValid()
	{
		// Act
		await EventPublisher.PublishAsync(_request, CancellationToken);
		var userPostsPostCommentsPostCommentLikes = await ServiceScope.GetByIdRangeAsync(UserPostsPostCommentsPostCommentLikeIds, CancellationToken);

		// Assert
		userPostsPostCommentsPostCommentLikes.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task PublishAsync_ShouldDeleteUserPostsPostCommentsPostCommentLikes_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var userPostsPostCommentsPostCommentLikes = await ServiceScope.GetByIdRangeAsync(UserPostsPostCommentsPostCommentLikeIds, CancellationToken);

		// Assert
		userPostsPostCommentsPostCommentLikes.ShouldBeEmpty();
	}

	[Fact]
	public async Task PublishAsync_ShouldDeleteUserPostCommentsPostCommentImages_WhenRequestIsValid()
	{
		// Act
		await EventPublisher.PublishAsync(_request, CancellationToken);
		var userPostCommentsPostCommentImages = await ServiceScope.GetByIdRangeAsync(UserPostCommentsPostCommentImageIds, CancellationToken);

		// Assert
		userPostCommentsPostCommentImages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task PublishAsync_ShouldDeleteUserPostCommentsPostCommentImages_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var userPostCommentsPostCommentImages = await ServiceScope.GetByIdRangeAsync(UserPostCommentsPostCommentImageIds, CancellationToken);

		// Assert
		userPostCommentsPostCommentImages.ShouldBeEmpty();
	}

	[Fact]
	public async Task PublishAsync_ShouldDeleteUserPostCommentsPostCommentLikes_WhenRequestIsValid()
	{
		// Act
		await EventPublisher.PublishAsync(_request, CancellationToken);
		var userPostCommentsPostCommentLikes = await ServiceScope.GetByIdRangeAsync(UserPostCommentsPostCommentLikeIds, CancellationToken);

		// Assert
		userPostCommentsPostCommentLikes.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task PublishAsync_ShouldDeleteUserPostCommentsPostCommentLikes_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await EventPublisher.PublishAsync(request, CancellationToken);
		var userPostCommentsPostCommentLikes = await ServiceScope.GetByIdRangeAsync(UserPostCommentsPostCommentLikeIds, CancellationToken);

		// Assert
		userPostCommentsPostCommentLikes.ShouldBeEmpty();
	}

}
