namespace InstaConnect.Posts.Domain.Tests.Features.PostLikes.Builders;

public class GetAllPostLikesForUserQueryBuilder
{
	private string _userId;
	private string _currentUserId;
	private int _page;
	private int _pageSize;
	private CommonSortOrder _sortOrder;
	private PostLikesForUserSortTerm _sortTerm;

	public GetAllPostLikesForUserQueryBuilder(PostLike postLike)
	{
		_userId = postLike.Id.UserId.Id;
		_currentUserId = postLike.Id.UserId.Id;
		_page = PostLikeDataFaker.GetPage();
		_pageSize = PostLikeDataFaker.GetPageSize();
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = PostLikeDataFaker.GetForUserSortTerm();
	}

	public GetAllPostLikesForUserQueryBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_userId = transformer.TryTransform(userId.Id);

		return this;
	}

	public GetAllPostLikesForUserQueryBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public GetAllPostLikesForUserQueryBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetAllPostLikesForUserQueryBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetAllPostLikesForUserQueryBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public GetAllPostLikesForUserQueryBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public GetAllPostLikesForUserQueryBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public GetAllPostLikesForUserQueryBuilder WithSortTerm(IEnumTransformer<PostLikesForUserSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public GetAllPostLikesForUserQuery Build()
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
