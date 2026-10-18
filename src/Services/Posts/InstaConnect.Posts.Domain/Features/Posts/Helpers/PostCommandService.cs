using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Posts.Domain.Features.PostImages.Extensions;

namespace InstaConnect.Posts.Domain.Features.Posts.Helpers;

internal class PostCommandService : IPostCommandService
{
	private readonly IPostFactory _factory;
	private readonly IApplicationMapper _mapper;
	private readonly IPostSummarizer _summarizer;
	private readonly IImageHandler _imageHandler;
	private readonly IEventPublisher _eventPublisher;
	private readonly IPostImageFactory _imageFactory;
	private readonly IPostCommandRepository _repository;
	private readonly IDateTimeProvider _dateTimeProvider;
	private readonly IUserCommandRepository _userRepository;
	private readonly IPostImageCommandRepository _imageRepository;
	private readonly IPostIncludeBuilderFactory _includeBuilderFactory;

	public PostCommandService(
		IPostFactory factory,
		IApplicationMapper mapper,
		IPostSummarizer summarizer,
		IImageHandler imageHandler,
		IEventPublisher eventPublisher,
		IPostImageFactory imageFactory,
		IPostCommandRepository repository,
		IDateTimeProvider dateTimeProvider,
		IUserCommandRepository userRepository,
		IPostImageCommandRepository imageRepository,
		IPostIncludeBuilderFactory includeBuilderFactory)
	{
		_factory = factory;
		_mapper = mapper;
		_summarizer = summarizer;
		_imageHandler = imageHandler;
		_eventPublisher = eventPublisher;
		_imageFactory = imageFactory;
		_repository = repository;
		_dateTimeProvider = dateTimeProvider;
		_userRepository = userRepository;
		_imageRepository = imageRepository;
		_includeBuilderFactory = includeBuilderFactory;
	}

	public async Task<PostId> AddAsync(AddPostCommand command, CancellationToken cancellationToken)
	{
		var user = await _userRepository.GetByIdAsync(command.UserId, cancellationToken);

		if (user == null)
		{
			throw new UserNotFoundException(command.UserId);
		}

		var newPost = _factory.Create(user.Id, command.Title, command.Content).AddUser(user);

		if (command.Images.Any())
		{
			var images = await _imageHandler.UploadRangeAsync(command.Images, cancellationToken);
			var newPostImages = _imageFactory.CreateRange(newPost.Id, images).AddPost(newPost);
			await _imageRepository.AddRangeAsync(newPostImages, cancellationToken);

			newPost.AddPostImages(newPostImages);
		}

		var summary = await _summarizer.SummarizeAsync(newPost, cancellationToken);
		newPost.UpdateSummary(summary);

		await _repository.AddAsync(newPost, cancellationToken);

		await _eventPublisher.PublishAsync(
			_mapper.Map<PostAddedEventRequest>(newPost), cancellationToken);

		return newPost.Id;
	}

	public async Task<PostId> UpdateAsync(UpdatePostCommand command, CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithUser().WithPostImages().Build();
		var post = await _repository.GetByIdAsync(command.Id, include, cancellationToken);

		if (post == null)
		{
			throw new PostNotFoundException(command.Id);
		}

		if (post.IsNotOwnedByUser(command.UserId))
		{
			throw new PostForbiddenException(command.Id, command.UserId);
		}

		post.Update(command.Title, command.Content, _dateTimeProvider.GetOffsetUtcNow());

		var summary = await _summarizer.SummarizeAsync(post, cancellationToken);
		post.UpdateSummary(summary);

		await _repository.UpdateAsync(post, cancellationToken);

		await _eventPublisher.PublishAsync(
			_mapper.Map<PostUpdatedEventRequest>(post), cancellationToken);

		return post.Id;
	}

	public async Task DeleteAsync(DeletePostCommand command, CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithUser().WithPostImages().Build();
		var post = await _repository.GetByIdAsync(command.Id, include, cancellationToken);

		if (post == null)
		{
			throw new PostNotFoundException(command.Id);
		}

		if (post.IsNotOwnedByUser(command.UserId))
		{
			throw new PostForbiddenException(command.Id, command.UserId);
		}

		await _repository.DeleteAsync(post, cancellationToken);

		await _eventPublisher.PublishAsync(
			_mapper.Map<PostDeletedEventRequest>(post), cancellationToken);
	}
}
