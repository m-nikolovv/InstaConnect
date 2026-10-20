namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Builders;

public class GetAllPostCommentLikesApiRequestBuilder
{
	private string _id;
	private string _commentId;
	private string _userName;
	private string _currentUserId;
	private int _page;
	private int _pageSize;
	private CommonSortOrder _sortOrder;
	private PostCommentLikesSortTerm _sortTerm;

	public GetAllPostCommentLikesApiRequestBuilder(PostCommentLike postCommentLike)
	{
		_id = postCommentLike.Id.CommentId.Id.Id;
		_commentId = postCommentLike.Id.CommentId.CommentId;
		_userName = DataFaker.GetPrefixString(postCommentLike.User!.Name.Value);
		_currentUserId = postCommentLike.Id.UserId.Id;
		_page = PostCommentLikeDataFaker.GetPage();
		_pageSize = PostCommentLikeDataFaker.GetPageSize();
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = PostCommentLikeDataFaker.GetSortTerm();
	}

	public GetAllPostCommentLikesApiRequestBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public GetAllPostCommentLikesApiRequestBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public GetAllPostCommentLikesApiRequestBuilder WithCommentId(PostCommentId commentId, IStringTransformer? transformer = null)
	{
		_commentId = transformer.TryTransform(commentId.CommentId);

		return this;
	}

	public GetAllPostCommentLikesApiRequestBuilder WithCommentId(IStringTransformer transformer)
	{
		_commentId = transformer.Transform(_commentId);

		return this;
	}

	public GetAllPostCommentLikesApiRequestBuilder WithUserName(IStringTransformer transformer)
	{
		_userName = transformer.Transform(_userName);

		return this;
	}

	public GetAllPostCommentLikesApiRequestBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetAllPostCommentLikesApiRequestBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetAllPostCommentLikesApiRequestBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public GetAllPostCommentLikesApiRequestBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public GetAllPostCommentLikesApiRequestBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public GetAllPostCommentLikesApiRequestBuilder WithSortTerm(IEnumTransformer<PostCommentLikesSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public GetAllPostCommentLikesApiRequest Build()
	{
		return new(_id, _commentId, _currentUserId, _userName, _sortOrder, _sortTerm, _page, _pageSize);
	}
}
