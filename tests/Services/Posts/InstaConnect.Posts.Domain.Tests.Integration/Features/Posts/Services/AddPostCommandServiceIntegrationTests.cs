using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;
using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Builders;
using InstaConnect.Posts.Domain.Tests.Integration.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Assertions;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Images;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.Posts.Services;

public class AddPostCommandServiceIntegrationTests : BasePostDomainCommandIntegrationTest
{
	private readonly AddPostCommandBuilderFactory _commandBuilderFactory;
	private readonly AddPostCommandBuilder _commandBuilder;
	private readonly AddPostCommand _command;

	public AddPostCommandServiceIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(User, NumberOfImages);
		_command = _commandBuilder.Build();
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNotFoundException_WhenUserIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await Service.ShouldThrowUserNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, post);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, post);
	}

	[Theory]
	[PostImagesEmptyData]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithImages(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, post);
	}

	[Fact]
	public async Task AddAsync_ShouldAddPost_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		post.ShouldSatisfy(_command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddPost_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		post.ShouldSatisfy(command);
	}

	[Theory]
	[PostImagesEmptyData]
	public async Task AddAsync_ShouldAddPost_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithImages(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		post.ShouldSatisfy(command);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishPostAddedEvent_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_command, post);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishPostAddedEvent_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, post);
	}

	[Theory]
	[PostImagesEmptyData]
	public async Task AddAsync_ShouldPublishPostAddedEvent_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithImages(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, post);
	}

	[Fact]
	public async Task AddAsync_ShouldAddPostImages_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		post.PostImages.ShouldSatisfy(_command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddPostImages_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		post.PostImages.ShouldSatisfy(command);
	}

	[Theory]
	[PostImagesEmptyData]
	public async Task AddAsync_ShouldAddPostImages_WhenCommandAndImagesAreValid(
		IFormFileCollectionTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithImages(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		post.PostImages.ShouldBeEmpty();
	}
}
