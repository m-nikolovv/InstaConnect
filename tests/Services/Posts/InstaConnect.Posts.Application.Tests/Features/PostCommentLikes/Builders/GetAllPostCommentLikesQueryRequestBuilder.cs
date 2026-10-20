namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Builders;

public class GetAllPostCommentLikesQueryRequestBuilder
{
	private string _id;
	private string _commentId;
	private string _userName;
	private string _currentUserId;
	private int _page;
	private int _pageSize;
	private CommonSortOrder _sortOrder;
	private PostCommentLikesSortTerm _sortTerm;

	public GetAllPostCommentLikesQueryRequestBuilder(PostCommentLike postCommentLike)
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

	public GetAllPostCommentLikesQueryRequestBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public GetAllPostCommentLikesQueryRequestBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public GetAllPostCommentLikesQueryRequestBuilder WithCommentId(PostCommentId commentId, IStringTransformer? transformer = null)
	{
		_commentId = transformer.TryTransform(commentId.CommentId);

		return this;
	}

	public GetAllPostCommentLikesQueryRequestBuilder WithCommentId(IStringTransformer transformer)
	{
		_commentId = transformer.Transform(_commentId);

		return this;
	}

	public GetAllPostCommentLikesQueryRequestBuilder WithUserName(IStringTransformer transformer)
	{
		_userName = transformer.Transform(_userName);

		return this;
	}

	public GetAllPostCommentLikesQueryRequestBuilder WithCurrentUserId(User user, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(user.Id.Id);

		return this;
	}

	public GetAllPostCommentLikesQueryRequestBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetAllPostCommentLikesQueryRequestBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public GetAllPostCommentLikesQueryRequestBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public GetAllPostCommentLikesQueryRequestBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public GetAllPostCommentLikesQueryRequestBuilder WithSortTerm(IEnumTransformer<PostCommentLikesSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public GetAllPostCommentLikesQueryRequest Build()
	{
		return new(_id, _commentId, _userName, _currentUserId, _sortOrder, _sortTerm, _page, _pageSize);
	}
}
