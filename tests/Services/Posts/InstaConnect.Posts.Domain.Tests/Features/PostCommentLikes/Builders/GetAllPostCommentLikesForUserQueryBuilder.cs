namespace InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Builders;

public class GetAllPostCommentLikesForUserQueryBuilder
{
	private string _userId;
	private string _currentUserId;
	private int _page;
	private int _pageSize;
	private CommonSortOrder _sortOrder;
	private PostCommentLikesForUserSortTerm _sortTerm;

	public GetAllPostCommentLikesForUserQueryBuilder(PostCommentLike postCommentLike)
	{
		_userId = postCommentLike.Id.UserId.Id;
		_currentUserId = postCommentLike.Id.UserId.Id;
		_page = PostCommentLikeDataFaker.GetPage();
		_pageSize = PostCommentLikeDataFaker.GetPageSize();
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = PostCommentLikeDataFaker.GetForUserSortTerm();
	}

	public GetAllPostCommentLikesForUserQueryBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_userId = transformer.TryTransform(userId.Id);

		return this;
	}

	public GetAllPostCommentLikesForUserQueryBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public GetAllPostCommentLikesForUserQueryBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetAllPostCommentLikesForUserQueryBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetAllPostCommentLikesForUserQueryBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public GetAllPostCommentLikesForUserQueryBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public GetAllPostCommentLikesForUserQueryBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public GetAllPostCommentLikesForUserQueryBuilder WithSortTerm(IEnumTransformer<PostCommentLikesForUserSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public GetAllPostCommentLikesForUserQuery Build()
	{
		return new(
			new(
				new(_userId)),
			new(_sortOrder, _sortTerm),
			new(_page, _pageSize),
			new(
				new(_currentUserId)));
	}
}
