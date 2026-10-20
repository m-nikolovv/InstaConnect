using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Posts.Domain.Features.PostLikes.Exceptions;
using InstaConnect.Posts.Events.Features.PostLikes;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Helpers;

internal class PostLikeCommandService : IPostLikeCommandService
{
	private readonly IApplicationMapper _mapper;
	private readonly IPostLikeFactory _likeFactory;
	private readonly IEventPublisher _eventPublisher;
	private readonly IPostCommandRepository _repository;
	private readonly IUserCommandRepository _userRepository;
	private readonly IPostLikeCommandRepository _likeRepository;
	private readonly IPostIncludeBuilderFactory _includeBuilderFactory;
	private readonly IPostLikeIncludeBuilderFactory _likeIncludeBuilderFactory;

	public PostLikeCommandService(
		IApplicationMapper mapper,
		IPostLikeFactory likeFactory,
		IEventPublisher eventPublisher,
		IPostCommandRepository repository,
		IUserCommandRepository userRepository,
		IPostLikeCommandRepository likeRepository,
		IPostIncludeBuilderFactory includeBuilderFactory,
		IPostLikeIncludeBuilderFactory likeIncludeBuilderFactory)
	{
		_mapper = mapper;
		_likeFactory = likeFactory;
		_eventPublisher = eventPublisher;
		_repository = repository;
		_userRepository = userRepository;
		_likeRepository = likeRepository;
		_includeBuilderFactory = includeBuilderFactory;
		_likeIncludeBuilderFactory = likeIncludeBuilderFactory;
	}

	public async Task<PostLikeId> AddAsync(AddPostLikeCommand command, CancellationToken cancellationToken)
	{
		var user = await _userRepository.GetByIdAsync(command.UserId, cancellationToken);

		if (user == null)
		{
			throw new UserNotFoundException(command.UserId);
		}

		var include = _includeBuilderFactory.Create().WithUser().Build();
		var post = await _repository.GetByIdAsync(command.Id, include, cancellationToken);

		if (post == null)
		{
			throw new PostNotFoundException(command.Id);
		}

		var newPostLike = _likeFactory.Create(post.Id, user.Id).AddPost(post).AddUser(user);
		var postLike = await _likeRepository.GetByIdAsync(newPostLike.Id, cancellationToken);

		if (postLike != null)
		{
			throw new PostLikeAlreadyExistsException(newPostLike.Id);
		}

		await _likeRepository.AddAsync(newPostLike, cancellationToken);

		await _eventPublisher.PublishAsync(
			_mapper.Map<PostLikeAddedEventRequest>(newPostLike), cancellationToken);

		return newPostLike.Id;
	}

	public async Task DeleteAsync(DeletePostLikeCommand command, CancellationToken cancellationToken)
	{
		var postNotExists = !await _repository.ExistsByIdAsync(command.Id.Id, cancellationToken);

		if (postNotExists)
		{
			throw new PostNotFoundException(command.Id.Id);
		}

		var include = _includeBuilderFactory.Create().WithUser().Build();
		var likeInclude = _likeIncludeBuilderFactory.Create().WithUser().WithPost(include).Build();
		var postLike = await _likeRepository.GetByIdAsync(command.Id, likeInclude, cancellationToken);

		if (postLike == null)
		{
			throw new PostLikeNotFoundException(command.Id);
		}

		await _likeRepository.DeleteAsync(postLike, cancellationToken);

		await _eventPublisher.PublishAsync(
			_mapper.Map<PostLikeDeletedEventRequest>(postLike), cancellationToken);
	}
}
