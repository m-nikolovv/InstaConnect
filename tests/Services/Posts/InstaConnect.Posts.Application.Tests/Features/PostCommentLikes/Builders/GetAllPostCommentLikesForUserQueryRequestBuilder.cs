namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Builders;

public class GetAllPostCommentLikesForUserQueryRequestBuilder
{
	private string _userId;
	private string _currentUserId;
	private int _page;
	private int _pageSize;
	private CommonSortOrder _sortOrder;
	private PostCommentLikesForUserSortTerm _sortTerm;

	public GetAllPostCommentLikesForUserQueryRequestBuilder(PostCommentLike postCommentLike)
	{
		_userId = postCommentLike.Id.UserId.Id;
		_currentUserId = postCommentLike.Id.UserId.Id;
		_page = PostCommentLikeDataFaker.GetPage();
		_pageSize = PostCommentLikeDataFaker.GetPageSize();
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = PostCommentLikeDataFaker.GetForUserSortTerm();
	}

	public GetAllPostCommentLikesForUserQueryRequestBuilder WithUserId(UserId userId, IStringTransformer transformer)
	{
		_userId = transformer.Transform(userId.Id);

		return this;
	}

	public GetAllPostCommentLikesForUserQueryRequestBuilder WithUserId(IStringTransformer transformer)
	{
		_userId = transformer.Transform(_userId);

		return this;
	}

	public GetAllPostCommentLikesForUserQueryRequestBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetAllPostCommentLikesForUserQueryRequestBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetAllPostCommentLikesForUserQueryRequestBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public GetAllPostCommentLikesForUserQueryRequestBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public GetAllPostCommentLikesForUserQueryRequestBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public GetAllPostCommentLikesForUserQueryRequestBuilder WithSortTerm(IEnumTransformer<PostCommentLikesForUserSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public GetAllPostCommentLikesForUserQueryRequest Build()
	{
		return new(_userId, _currentUserId, _sortOrder, _sortTerm, _page, _pageSize);
	}
}
