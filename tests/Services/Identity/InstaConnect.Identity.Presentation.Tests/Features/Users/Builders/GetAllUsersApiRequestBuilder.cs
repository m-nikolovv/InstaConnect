using InstaConnect.Identity.Domain.Features.Users.Models.Requests;

namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Builders;

public class GetAllUsersApiRequestBuilder
{
	private string _name;
	private string _firstName;
	private string _lastName;
	private string _currentId;
	private int _page;
	private int _pageSize;
	private CommonSortOrder _sortOrder;
	private UsersSortTerm _sortTerm;

	public GetAllUsersApiRequestBuilder(User user)
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

	public GetAllUsersApiRequestBuilder WithName(IStringTransformer transformer)
	{
		_name = transformer.Transform(_name);

		return this;
	}

	public GetAllUsersApiRequestBuilder WithFirstName(IStringTransformer transformer)
	{
		_firstName = transformer.Transform(_firstName);

		return this;
	}

	public GetAllUsersApiRequestBuilder WithLastName(IStringTransformer transformer)
	{
		_lastName = transformer.Transform(_lastName);

		return this;
	}

	public GetAllUsersApiRequestBuilder WithCurrentId(UserId currentId, IStringTransformer? transformer = null)
	{
		_currentId = transformer.TryTransform(currentId.Id);

		return this;
	}

	public GetAllUsersApiRequestBuilder WithCurrentId(IStringTransformer transformer)
	{
		_currentId = transformer.Transform(_currentId);

		return this;
	}

	public GetAllUsersApiRequestBuilder WithPage(IIntTransformer transformer)
	{
		_page = transformer.Transform(_page);

		return this;
	}

	public GetAllUsersApiRequestBuilder WithPageSize(IIntTransformer transformer)
	{
		_pageSize = transformer.Transform(_pageSize);

		return this;
	}

	public GetAllUsersApiRequestBuilder WithSortOrder(IEnumTransformer<CommonSortOrder> transformer)
	{
		_sortOrder = transformer.Transform(_sortOrder);

		return this;
	}

	public GetAllUsersApiRequestBuilder WithSortTerm(IEnumTransformer<UsersSortTerm> transformer)
	{
		_sortTerm = transformer.Transform(_sortTerm);

		return this;
	}

	public GetAllUsersApiRequest Build()
	{
		return new(_currentId, _firstName, _lastName, _name, _sortOrder, _sortTerm, _page, _pageSize);
	}
}
