using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Builders;
using InstaConnect.Posts.Domain.Tests.Integration.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.PostImages.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Assertions;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Id;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.Posts.Services;

public class UpdatePostCommandServiceIntegrationTests : BasePostDomainCommandIntegrationTest
{
	private readonly UpdatePostCommandBuilderFactory _commandBuilderFactory;
	private readonly UpdatePostCommandBuilder _commandBuilder;
	private readonly UpdatePostCommand _command;

	public UpdatePostCommandServiceIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(Post);
		_command = _commandBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(Post, CancellationToken);
		await ServiceScope.AddRangeAsync(PostImages, CancellationToken);
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
	public async Task UpdateAsync_ShouldThrowPostForbiddenException_WhenPostForbidden()
	{
		// Arrange
		var user = UserBuilderFactory.Create().Build();
		await ServiceScope.AddAsync(user, CancellationToken);
		var command = _commandBuilder.WithUserId(user.Id).Build();

		// Assert
		await Service.ShouldThrowPostForbiddenExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Service.UpdateAsync(_command, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, post);
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
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, post);
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
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, post);
	}

	[Fact]
	public async Task UpdateAsync_ShouldUpdatePost_WhenCommandIsValid()
	{
		// Act
		var response = await Service.UpdateAsync(_command, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		post.ShouldSatisfy(_command);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdatePost_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		post.ShouldSatisfy(command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdatePost_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		post.ShouldSatisfy(command);
	}

	[Fact]
	public async Task UpdateAsync_ShouldPublishPostUpdatedEvent_WhenCommandIsValid()
	{
		// Act
		var response = await Service.UpdateAsync(_command, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await EventClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_command, post);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishPostUpdatedEvent_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await EventClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, post);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishPostUpdatedEvent_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await EventClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, post);
	}
}
