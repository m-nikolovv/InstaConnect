namespace InstaConnect.Identity.Domain.Tests.Features.Users.Builders;

public class GetAllUsersQueryBuilder
{
	private string _name;
	private string _firstName;
	private string _lastName;
	private string _currentUserId;
	private int _page;
	private int _pageSize;
	private CommonSortOrder _sortOrder;
	private UsersSortTerm _sortTerm;

	public GetAllUsersQueryBuilder(User user)
	{
		_name = DataFaker.GetPrefixString(user.Name.Value);
		_firstName = DataFaker.GetPrefixString(user.FirstName);
		_lastName = DataFaker.GetPrefixString(user.LastName);
		_currentUserId = user.Id.Id;
		_page = UserDataFaker.GetPage();
		_pageSize = UserDataFaker.GetPageSize();
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = UserDataFaker.GetSortTerm();
	}

	public GetAllUsersQueryBuilder WithName(IStringTransformer transformer)
	{
		_name = transformer.Transform(_name);

		return this;
	}

	public GetAllUsersQueryBuilder WithFirstName(IStringTransformer transformer)
	{
		_firstName = transformer.Transform(_firstName);

		return this;
	}

	public GetAllUsersQueryBuilder WithLastName(IStringTransformer transformer)
	{
		_lastName = transformer.Transform(_lastName);

		return this;
	}

	public GetAllUsersQueryBuilder WithCurrentUserId(UserId currentUserId, IStringTransformer? transformer = null)
	{
		_currentUserId = transformer.TryTransform(currentUserId.Id);

		return this;
	}

	public GetAllUsersQueryBuilder WithCurrentUserId(IStringTransformer transformer)
	{
		_currentUserId = transformer.Transform(_currentUserId);

		return this;
	}

	public GetAllUsersQueryBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public GetAllUsersQueryBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public GetAllUsersQueryBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public GetAllUsersQueryBuilder WithSortTerm(IEnumTransformer<UsersSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public GetAllUsersQuery Build()
	{
		return new(
			new(_firstName, _lastName, new(_name)),
			new(_sortOrder, _sortTerm),
			new(_page, _pageSize),
			new(new(_currentUserId)));
	}
}
