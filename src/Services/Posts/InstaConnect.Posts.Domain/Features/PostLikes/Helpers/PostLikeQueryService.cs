using InstaConnect.Posts.Domain.Features.PostLikes.Exceptions;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Helpers;

internal class PostLikeQueryService : IPostLikeQueryService
{
	private readonly IPostQueryRepository _repository;
	private readonly IUserQueryRepository _userRepository;
	private readonly IPostLikeQueryRepository _likeRepository;
	private readonly IPostLikeCollectionResponseFactory _likeCollectionResponseFactory;

	public PostLikeQueryService(
		IPostQueryRepository repository,
		IUserQueryRepository userRepository,
		IPostLikeQueryRepository likeRepository,
		IPostLikeCollectionResponseFactory likeCollectionResponseFactory)
	{
		_repository = repository;
		_userRepository = userRepository;
		_likeRepository = likeRepository;
		_likeCollectionResponseFactory = likeCollectionResponseFactory;
	}

	public async Task<PostLikeCollectionResponse> GetAllAsync(GetAllPostLikesQuery query, CancellationToken cancellationToken)
	{
		var post = await _repository.GetByIdAsync(query.Filter.Id, query.CurrentUser, cancellationToken);

		if (post == null)
		{
			throw new PostNotFoundException(query.Filter.Id);
		}

		var postLikes = await _likeRepository.GetAllAsync(
			query.Filter,
			query.Sorting,
			query.Pagination,
			query.CurrentUser,
			cancellationToken);

		var totalCount = await _likeRepository.GetTotalCountAsync(query.Filter, cancellationToken);

		return _likeCollectionResponseFactory.Create(post, postLikes, totalCount, query.Pagination);
	}

	public async Task<PostLikeCollectionResponse> GetAllForUserAsync(GetAllPostLikesForUserQuery query, CancellationToken cancellationToken)
	{
		var user = await _userRepository.GetByIdAsync(query.Filter.UserId, query.CurrentUser, cancellationToken);

		if (user == null)
		{
			throw new UserNotFoundException(query.Filter.UserId);
		}

		var postLikes = await _likeRepository.GetAllForUserAsync(
			query.Filter,
			query.Sorting,
			query.Pagination,
			query.CurrentUser,
			cancellationToken);

		var totalCount = await _likeRepository.GetTotalCountForUserAsync(query.Filter, cancellationToken);

		return _likeCollectionResponseFactory.CreateForUser(user, postLikes, totalCount, query.Pagination);
	}

	public async Task<PostLikeResponse> GetByIdAsync(GetPostLikeByIdQuery query, CancellationToken cancellationToken)
	{
		var postNotExists = !await _repository.ExistsByIdAsync(query.Id.Id, cancellationToken);

		if (postNotExists)
		{
			throw new PostNotFoundException(query.Id.Id);
		}

		var postLike = await _likeRepository.GetByIdAsync(
			query.Id,
			query.CurrentUser,
			cancellationToken);

		if (postLike == null)
		{
			throw new PostLikeNotFoundException(query.Id);
		}

		return postLike;
	}
}
