namespace InstaConnect.Identity.Application.Tests.Features.Users.Builders;

public class GetAllUsersQueryRequestBuilder
{
	private string _name;
	private string _firstName;
	private string _lastName;
	private string _currentId;
	private int _page;
	private int _pageSize;
	private CommonSortOrder _sortOrder;
	private UsersSortTerm _sortTerm;

	public GetAllUsersQueryRequestBuilder(User user)
	{
		_name = DataFaker.GetPrefixString(user.Name.Value);
		_firstName = DataFaker.GetPrefixString(user.FirstName);
		_lastName = DataFaker.GetPrefixString(user.LastName);
		_currentId = user.Id.Id;
		_page = UserDataFaker.GetPage();
		_pageSize = UserDataFaker.GetPageSize();
		_sortOrder = DataFaker.GetSortOrder();
		_sortTerm = UserDataFaker.GetSortTerm();
	}

	public GetAllUsersQueryRequestBuilder WithName(IStringTransformer transformer)
	{
		_name = transformer.Transform(_name);

		return this;
	}

	public GetAllUsersQueryRequestBuilder WithFirstName(IStringTransformer transformer)
	{
		_firstName = transformer.Transform(_firstName);

		return this;
	}

	public GetAllUsersQueryRequestBuilder WithLastName(IStringTransformer transformer)
	{
		_lastName = transformer.Transform(_lastName);

		return this;
	}

	public GetAllUsersQueryRequestBuilder WithCurrentId(UserId currentId, IStringTransformer? transformer = null)
	{
		_currentId = transformer.TryTransform(currentId.Id);

		return this;
	}

	public GetAllUsersQueryRequestBuilder WithCurrentId(IStringTransformer transformer)
	{
		_currentId = transformer.Transform(_currentId);

		return this;
	}

	public GetAllUsersQueryRequestBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public GetAllUsersQueryRequestBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public GetAllUsersQueryRequestBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public GetAllUsersQueryRequestBuilder WithSortTerm(IEnumTransformer<UsersSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public GetAllUsersQueryRequest Build()
	{
		return new(_firstName, _lastName, _name, _currentId, _sortOrder, _sortTerm, _page, _pageSize);
	}
}
