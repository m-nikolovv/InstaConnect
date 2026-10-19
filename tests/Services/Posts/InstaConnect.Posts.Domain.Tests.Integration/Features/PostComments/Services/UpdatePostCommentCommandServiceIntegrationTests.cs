using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Builders;
using InstaConnect.Posts.Domain.Tests.Integration.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.PostCommentImages.Utilities;
using InstaConnect.Posts.Tests.Features.PostComments.Assertions;
using InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.Id;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Id;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.PostComments.Services;

public class UpdatePostCommentCommandServiceIntegrationTests : BasePostCommentDomainCommandIntegrationTest
{
	private readonly UpdatePostCommentCommandBuilderFactory _commandBuilderFactory;
	private readonly UpdatePostCommentCommandBuilder _commandBuilder;
	private readonly UpdatePostCommentCommand _command;

	public UpdatePostCommentCommandServiceIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(PostComment);
		_command = _commandBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(PostComment, CancellationToken);
		await ServiceScope.AddRangeAsync(PostCommentImages, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowPostNotFoundException_WhenPostNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Post, CancellationToken);

		// Assert
		await Service.ShouldThrowPostNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowPostCommentNotFoundException_WhenPostCommentNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(PostComment, CancellationToken);

		// Assert
		await Service.ShouldThrowPostCommentNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowPostCommentForbiddenException_WhenPostCommentForbidden()
	{
		// Arrange
		var user = UserBuilderFactory.Create().Build();
		await ServiceScope.AddAsync(user, CancellationToken);
		var command = _commandBuilder.WithUserId(user.Id).Build();

		// Assert
		await Service.ShouldThrowPostCommentForbiddenExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Service.UpdateAsync(_command, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, postComment);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, postComment);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, postComment);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenCommandAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, postComment);
	}

	[Fact]
	public async Task UpdateAsync_ShouldUpdatePostComment_WhenCommandIsValid()
	{
		// Act
		var response = await Service.UpdateAsync(_command, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postComment.ShouldSatisfy(_command);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdatePostComment_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postComment.ShouldSatisfy(command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdatePostComment_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postComment.ShouldSatisfy(command);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdatePostComment_WhenCommandAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		postComment.ShouldSatisfy(command);
	}

	[Fact]
	public async Task UpdateAsync_ShouldPublishPostCommentUpdatedEvent_WhenCommandIsValid()
	{
		// Act
		var response = await Service.UpdateAsync(_command, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await CommentEventClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_command, postComment);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishPostCommentUpdatedEvent_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await CommentEventClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, postComment);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishPostCommentUpdatedEvent_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await CommentEventClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, postComment);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishPostCommentUpdatedEvent_WhenCommandAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var postComment = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await CommentEventClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, postComment);
	}
}
