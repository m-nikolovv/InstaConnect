namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Builders;

public class GetAllPostCommentsQueryRequestBuilder
{
	private string _id;
	private string _userName;
	private string _currentUserId;
	private int _page;
	private int _pageSize;
	private CommonSortOrder _sortOrder;
	private PostCommentsSortTerm _sortTerm;

	public GetAllPostCommentsQueryRequestBuilder(PostComment postComment)
	{
		_id = postComment.Id.Id.Id;
		_userName = DataFaker.GetPrefixString(postComment.User!.Name.Value);
		_currentUserId = postComment.UserId.Id;
		_page = PostCommentDataFaker.GetPage();
		_pageSize = PostCommentDataFaker.GetPageSize();
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = PostCommentDataFaker.GetSortTerm();
	}

	public GetAllPostCommentsQueryRequestBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public GetAllPostCommentsQueryRequestBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public GetAllPostCommentsQueryRequestBuilder WithUserName(IStringTransformer transformer)
	{
		_userName = transformer.Transform(_userName);

		return this;
	}

	public GetAllPostCommentsQueryRequestBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetAllPostCommentsQueryRequestBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetAllPostCommentsQueryRequestBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public GetAllPostCommentsQueryRequestBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public GetAllPostCommentsQueryRequestBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public GetAllPostCommentsQueryRequestBuilder WithSortTerm(IEnumTransformer<PostCommentsSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public GetAllPostCommentsQueryRequest Build()
	{
		return new(_id, _userName, _currentUserId, _sortOrder, _sortTerm, _page, _pageSize);
	}
}
