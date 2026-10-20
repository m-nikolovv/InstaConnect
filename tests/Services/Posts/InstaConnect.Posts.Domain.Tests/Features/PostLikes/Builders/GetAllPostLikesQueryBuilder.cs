namespace InstaConnect.Posts.Domain.Tests.Features.PostLikes.Builders;

public class GetAllPostLikesQueryBuilder
{
	private string _id;
	private string _userName;
	private string _currentUserId;
	private int _page;
	private int _pageSize;
	private CommonSortOrder _sortOrder;
	private PostLikesSortTerm _sortTerm;

	public GetAllPostLikesQueryBuilder(PostLike postLike)
	{
		_id = postLike.Id.Id.Id;
		_userName = DataFaker.GetPrefixString(postLike.User!.Name.Value);
		_currentUserId = postLike.Id.UserId.Id;
		_page = PostLikeDataFaker.GetPage();
		_pageSize = PostLikeDataFaker.GetPageSize();
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = PostLikeDataFaker.GetSortTerm();
	}

	public GetAllPostLikesQueryBuilder WithId(PostId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public GetAllPostLikesQueryBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public GetAllPostLikesQueryBuilder WithUserName(IStringTransformer transformer)
	{
		_userName = transformer.Transform(_userName);

		return this;
	}

	public GetAllPostLikesQueryBuilder WithCurrentUserId(UserId userId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(userId.Id);

		return this;
	}

	public GetAllPostLikesQueryBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetAllPostLikesQueryBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public GetAllPostLikesQueryBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public GetAllPostLikesQueryBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public GetAllPostLikesQueryBuilder WithSortTerm(IEnumTransformer<PostLikesSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public GetAllPostLikesQuery Build()
	{
		return new(
			new(
				new(_id),
				new(_userName)),
			new(_sortOrder, _sortTerm),
			new(_page, _pageSize),
			new(
				new(_currentUserId)));
	}
}
