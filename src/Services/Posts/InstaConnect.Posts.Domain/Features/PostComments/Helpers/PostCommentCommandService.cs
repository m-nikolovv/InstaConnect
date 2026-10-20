using InstaConnect.Common.Domain.Features.Images.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Posts.Domain.Features.PostCommentImages.Abstractions;
using InstaConnect.Posts.Domain.Features.PostCommentImages.Extensions;
using InstaConnect.Posts.Domain.Features.PostComments.Exceptions;
using InstaConnect.Posts.Events.Features.PostComments;

namespace InstaConnect.Posts.Domain.Features.PostComments.Helpers;

internal class PostCommentCommandService : IPostCommentCommandService
{
	private readonly IApplicationMapper _mapper;
	private readonly IImageHandler _imageHandler;
	private readonly IEventPublisher _eventPublisher;
	private readonly IPostCommandRepository _repository;
	private readonly IDateTimeProvider _dateTimeProvider;
	private readonly IPostCommentFactory _commentFactory;
	private readonly IUserCommandRepository _userRepository;
	private readonly IPostCommentSummarizer _commentSummarizer;
	private readonly IPostCommentImageFactory _commentImageFactory;
	private readonly IPostCommentCommandRepository _commentRepository;
	private readonly IPostIncludeBuilderFactory _includeBuilderFactory;
	private readonly IPostCommentImageCommandRepository _commentImageRepository;
	private readonly IPostCommentIncludeBuilderFactory _commentIncludeBuilderFactory;

	public PostCommentCommandService(
		IApplicationMapper mapper,
		IImageHandler imageHandler,
		IEventPublisher eventPublisher,
		IPostCommandRepository repository,
		IDateTimeProvider dateTimeProvider,
		IPostCommentFactory commentFactory,
		IUserCommandRepository userRepository,
		IPostCommentSummarizer commentSummarizer,
		IPostCommentImageFactory commentImageFactory,
		IPostCommentCommandRepository commentRepository,
		IPostIncludeBuilderFactory includeBuilderFactory,
		IPostCommentImageCommandRepository commentImageRepository,
		IPostCommentIncludeBuilderFactory commentIncludeBuilderFactory)
	{
		_mapper = mapper;
		_imageHandler = imageHandler;
		_eventPublisher = eventPublisher;
		_repository = repository;
		_dateTimeProvider = dateTimeProvider;
		_commentFactory = commentFactory;
		_userRepository = userRepository;
		_commentSummarizer = commentSummarizer;
		_commentImageFactory = commentImageFactory;
		_commentRepository = commentRepository;
		_includeBuilderFactory = includeBuilderFactory;
		_commentImageRepository = commentImageRepository;
		_commentIncludeBuilderFactory = commentIncludeBuilderFactory;
	}

	public async Task<PostCommentId> AddAsync(AddPostCommentCommand command, CancellationToken cancellationToken)
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

		var newPostComment = _commentFactory.Create(post.Id, user.Id, command.Content).AddPost(post).AddUser(user);

		if (command.Images.Any())
		{
			var images = await _imageHandler.UploadRangeAsync(command.Images, cancellationToken);
			var newPostCommentImages = _commentImageFactory.CreateRange(newPostComment.Id, images).AddPostComment(newPostComment);
			await _commentImageRepository.AddRangeAsync(newPostCommentImages, cancellationToken);

			newPostComment.AddPostCommentImages(newPostCommentImages);
		}

		var summary = await _commentSummarizer.SummarizeAsync(newPostComment, cancellationToken);
		newPostComment.UpdateSummary(summary);

		await _commentRepository.AddAsync(newPostComment, cancellationToken);

		await _eventPublisher.PublishAsync(
			_mapper.Map<PostCommentAddedEventRequest>(newPostComment), cancellationToken);

		return newPostComment.Id;
	}

	public async Task<PostCommentId> UpdateAsync(UpdatePostCommentCommand command, CancellationToken cancellationToken)
	{
		var postNotExists = !await _repository.ExistsByIdAsync(command.Id.Id, cancellationToken);

		if (postNotExists)
		{
			throw new PostNotFoundException(command.Id.Id);
		}

		var include = _includeBuilderFactory.Create().WithUser().Build();
		var commentInclude = _commentIncludeBuilderFactory.Create().WithUser().WithPost(include).WithPostCommentImages().Build();
		var postComment = await _commentRepository.GetByIdAsync(command.Id, commentInclude, cancellationToken);

		if (postComment == null)
		{
			throw new PostCommentNotFoundException(command.Id);
		}

		if (postComment.IsNotOwnedByUser(command.UserId))
		{
			throw new PostCommentForbiddenException(command.Id, command.UserId);
		}

		postComment.Update(command.Content, _dateTimeProvider.GetOffsetUtcNow());

		var summary = await _commentSummarizer.SummarizeAsync(postComment, cancellationToken);
		postComment.UpdateSummary(summary);

		await _commentRepository.UpdateAsync(postComment, cancellationToken);

		await _eventPublisher.PublishAsync(
			_mapper.Map<PostCommentUpdatedEventRequest>(postComment), cancellationToken);

		return postComment.Id;
	}

	public async Task DeleteAsync(DeletePostCommentCommand command, CancellationToken cancellationToken)
	{
		var postNotExists = !await _repository.ExistsByIdAsync(command.Id.Id, cancellationToken);

		if (postNotExists)
		{
			throw new PostNotFoundException(command.Id.Id);
		}

		var include = _includeBuilderFactory.Create().WithUser().Build();
		var commentInclude = _commentIncludeBuilderFactory.Create().WithUser().WithPost(include).WithPostCommentImages().Build();
		var postComment = await _commentRepository.GetByIdAsync(command.Id, commentInclude, cancellationToken);

		if (postComment == null)
		{
			throw new PostCommentNotFoundException(command.Id);
		}

		if (postComment.IsNotOwnedByUser(command.UserId))
		{
			throw new PostCommentForbiddenException(command.Id, command.UserId);
		}

		await _commentRepository.DeleteAsync(postComment, cancellationToken);

		await _eventPublisher.PublishAsync(
			_mapper.Map<PostCommentDeletedEventRequest>(postComment), cancellationToken);
	}
}
