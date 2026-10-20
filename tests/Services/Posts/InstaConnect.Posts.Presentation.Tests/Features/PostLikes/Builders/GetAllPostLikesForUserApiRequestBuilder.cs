namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Builders;

public class GetAllPostLikesForUserApiRequestBuilder
{
	private string _userId;
	private string _currentUserId;
	private int _page;
	private int _pageSize;
	private CommonSortOrder _sortOrder;
	private PostLikesForUserSortTerm _sortTerm;

	public GetAllPostLikesForUserApiRequestBuilder(PostLike postLike)
	{
		_userId = postLike.Id.UserId.Id;
		_currentUserId = postLike.Id.UserId.Id;
		_page = PostLikeDataFaker.GetPage();
		_pageSize = PostLikeDataFaker.GetPageSize();
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = PostLikeDataFaker.GetForUserSortTerm();
	}

	public GetAllPostLikesForUserApiRequestBuilder WithUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_userId = transformer.TryTransform(userId.Id);

		return this;
	}

	public GetAllPostLikesForUserApiRequestBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public GetAllPostLikesForUserApiRequestBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetAllPostLikesForUserApiRequestBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetAllPostLikesForUserApiRequestBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public GetAllPostLikesForUserApiRequestBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public GetAllPostLikesForUserApiRequestBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public GetAllPostLikesForUserApiRequestBuilder WithSortTerm(IEnumTransformer<PostLikesForUserSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public GetAllPostLikesForUserApiRequest Build()
	{
		return new(_userId, _currentUserId, _sortOrder, _sortTerm, _page, _pageSize);
	}
}
