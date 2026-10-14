using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Events.Features.Events.Abstractions;

namespace InstaConnect.Posts.Domain.Features.Posts.Helpers;

internal class PostCommandService : IPostCommandService
{
	private readonly IPostFactory _factory;
	private readonly IApplicationMapper _mapper;
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
		await _repository.AddAsync(newPost, cancellationToken);

		await _eventPublisher.PublishAsync(
			_mapper.Map<PostAddedEventRequest>(newPost), cancellationToken);

		if (command.Images.Any())
		{
			var images = await _imageHandler.UploadRangeAsync(command.Images, cancellationToken);
			var newPostImages = _imageFactory.CreateRange(newPost.Id, images);
			await _imageRepository.AddRangeAsync(newPostImages, cancellationToken);
		}

		return newPost.Id;
	}

	public async Task<PostId> UpdateAsync(UpdatePostCommand command, CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithUser().Build();
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
		await _repository.UpdateAsync(post, cancellationToken);

		await _eventPublisher.PublishAsync(
			_mapper.Map<PostUpdatedEventRequest>(post), cancellationToken);

		return post.Id;
	}

	public async Task DeleteAsync(DeletePostCommand command, CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithUser().Build();
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
