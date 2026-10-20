using InstaConnect.Posts.Domain.Features.PostComments.Exceptions;

namespace InstaConnect.Posts.Domain.Features.PostComments.Helpers;

internal class PostCommentQueryService : IPostCommentQueryService
{
	private readonly IPostQueryRepository _repository;
	private readonly IUserQueryRepository _userRepository;
	private readonly IPostCommentQueryRepository _commentRepository;
	private readonly IPostCommentCollectionResponseFactory _commentCollectionResponseFactory;

	public PostCommentQueryService(
		IPostQueryRepository repository,
		IUserQueryRepository userRepository,
		IPostCommentQueryRepository commentRepository,
		IPostCommentCollectionResponseFactory commentCollectionResponseFactory)
	{
		_repository = repository;
		_userRepository = userRepository;
		_commentRepository = commentRepository;
		_commentCollectionResponseFactory = commentCollectionResponseFactory;
	}

	public async Task<PostCommentCollectionResponse> GetAllAsync(GetAllPostCommentsQuery query, CancellationToken cancellationToken)
	{
		var post = await _repository.GetByIdAsync(query.Filter.Id, query.CurrentUser, cancellationToken);

		if (post == null)
		{
			throw new PostNotFoundException(query.Filter.Id);
		}

		var postComments = await _commentRepository.GetAllAsync(
			query.Filter,
			query.Sorting,
			query.Pagination,
			query.CurrentUser,
			cancellationToken);

		var totalCount = await _commentRepository.GetTotalCountAsync(query.Filter, cancellationToken);

		return _commentCollectionResponseFactory.Create(post, postComments, totalCount, query.Pagination);
	}

	public async Task<PostCommentCollectionResponse> GetAllForUserAsync(GetAllPostCommentsForUserQuery query, CancellationToken cancellationToken)
	{
		var user = await _userRepository.GetByIdAsync(query.Filter.UserId, query.CurrentUser, cancellationToken);

		if (user == null)
		{
			throw new UserNotFoundException(query.Filter.UserId);
		}

		var postComments = await _commentRepository.GetAllForUserAsync(
			query.Filter,
			query.Sorting,
			query.Pagination,
			query.CurrentUser,
			cancellationToken);

		var totalCount = await _commentRepository.GetTotalCountForUserAsync(query.Filter, cancellationToken);

		return _commentCollectionResponseFactory.CreateForUser(user, postComments, totalCount, query.Pagination);
	}

	public async Task<PostCommentResponse> GetByIdAsync(GetPostCommentByIdQuery query, CancellationToken cancellationToken)
	{
		var postNotExists = !await _repository.ExistsByIdAsync(query.Id.Id, cancellationToken);

		if (postNotExists)
		{
			throw new PostNotFoundException(query.Id.Id);
		}

		var postComment = await _commentRepository.GetByIdAsync(
			query.Id,
			query.CurrentUser,
			cancellationToken);

		if (postComment == null)
		{
			throw new PostCommentNotFoundException(query.Id);
		}

		return postComment;
	}
}
