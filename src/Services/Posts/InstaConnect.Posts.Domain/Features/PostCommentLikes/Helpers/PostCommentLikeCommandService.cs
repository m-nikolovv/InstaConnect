using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Exceptions;
using InstaConnect.Posts.Domain.Features.PostComments.Exceptions;
using InstaConnect.Posts.Events.Features.PostCommentLikes;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Helpers;

internal class PostCommentLikeCommandService : IPostCommentLikeCommandService
{
	private readonly IApplicationMapper _mapper;
	private readonly IEventPublisher _eventPublisher;
	private readonly IPostCommandRepository _repository;
	private readonly IUserCommandRepository _userRepository;
	private readonly IPostCommentLikeFactory _commentLikeFactory;
	private readonly IPostCommentCommandRepository _commentRepository;
	private readonly IPostIncludeBuilderFactory _includeBuilderFactory;
	private readonly IPostCommentLikeCommandRepository _commentLikeRepository;
	private readonly IPostCommentIncludeBuilderFactory _commentIncludeBuilderFactory;
	private readonly IPostCommentLikeIncludeBuilderFactory _commentLikeIncludeBuilderFactory;

	public PostCommentLikeCommandService(
		IApplicationMapper mapper,
		IEventPublisher eventPublisher,
		IPostCommandRepository repository,
		IUserCommandRepository userRepository,
		IPostCommentLikeFactory commentLikeFactory,
		IPostCommentCommandRepository commentRepository,
		IPostIncludeBuilderFactory includeBuilderFactory,
		IPostCommentLikeCommandRepository commentLikeRepository,
		IPostCommentIncludeBuilderFactory commentIncludeBuilderFactory,
		IPostCommentLikeIncludeBuilderFactory commentLikeIncludeBuilderFactory)
	{
		_mapper = mapper;
		_eventPublisher = eventPublisher;
		_repository = repository;
		_userRepository = userRepository;
		_commentLikeFactory = commentLikeFactory;
		_commentRepository = commentRepository;
		_includeBuilderFactory = includeBuilderFactory;
		_commentLikeRepository = commentLikeRepository;
		_commentIncludeBuilderFactory = commentIncludeBuilderFactory;
		_commentLikeIncludeBuilderFactory = commentLikeIncludeBuilderFactory;
	}

	public async Task<PostCommentLikeId> AddAsync(AddPostCommentLikeCommand command, CancellationToken cancellationToken)
	{
		var user = await _userRepository.GetByIdAsync(command.UserId, cancellationToken);

		if (user == null)
		{
			throw new UserNotFoundException(command.UserId);
		}

		var postNotExists = !await _repository.ExistsByIdAsync(command.CommentId.Id, cancellationToken);

		if (postNotExists)
		{
			throw new PostNotFoundException(command.CommentId.Id);
		}

		var include = _includeBuilderFactory.Create().WithUser().Build();
		var commentInclude = _commentIncludeBuilderFactory.Create().WithUser().WithPost(include).Build();
		var postComment = await _commentRepository.GetByIdAsync(command.CommentId, commentInclude, cancellationToken);

		if (postComment == null)
		{
			throw new PostCommentNotFoundException(command.CommentId);
		}

		var newPostCommentLike = _commentLikeFactory.Create(postComment.Id, user.Id).AddUser(user).AddPostComment(postComment);
		var postCommentLike = await _commentLikeRepository.GetByIdAsync(
			newPostCommentLike.Id,
			cancellationToken);

		if (postCommentLike != null)
		{
			throw new PostCommentLikeAlreadyExistsException(newPostCommentLike.Id);
		}

		await _commentLikeRepository.AddAsync(newPostCommentLike, cancellationToken);

		await _eventPublisher.PublishAsync(
			_mapper.Map<PostCommentLikeAddedEventRequest>(newPostCommentLike), cancellationToken);

		return newPostCommentLike.Id;
	}

	public async Task DeleteAsync(DeletePostCommentLikeCommand command, CancellationToken cancellationToken)
	{
		var postNotExists = !await _repository.ExistsByIdAsync(command.Id.CommentId.Id, cancellationToken);

		if (postNotExists)
		{
			throw new PostNotFoundException(command.Id.CommentId.Id);
		}

		var postCommentNotExists = !await _commentRepository.ExistsByIdAsync(command.Id.CommentId, cancellationToken);

		if (postCommentNotExists)
		{
			throw new PostCommentNotFoundException(command.Id.CommentId);
		}

		var include = _includeBuilderFactory.Create().WithUser().Build();
		var commentInclude = _commentIncludeBuilderFactory.Create().WithUser().WithPost(include).Build();
		var commentLikeInclude = _commentLikeIncludeBuilderFactory.Create().WithUser().WithPostComment(commentInclude).Build();
		var postCommentLike = await _commentLikeRepository.GetByIdAsync(
			command.Id,
			commentLikeInclude,
			cancellationToken);

		if (postCommentLike == null)
		{
			throw new PostCommentLikeNotFoundException(command.Id);
		}

		await _commentLikeRepository.DeleteAsync(postCommentLike, cancellationToken);

		await _eventPublisher.PublishAsync(
			_mapper.Map<PostCommentLikeDeletedEventRequest>(postCommentLike), cancellationToken);
	}
}
