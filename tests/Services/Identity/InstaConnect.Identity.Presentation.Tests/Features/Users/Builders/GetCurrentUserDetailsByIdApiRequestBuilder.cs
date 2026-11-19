namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Builders;

public class GetCurrentUserDetailsByIdApiRequestBuilder
{
	private string _currentId;

	public GetCurrentUserDetailsByIdApiRequestBuilder(User user, UserId currentId)
	{
		_currentId = currentId.Id;
	}

	public GetCurrentUserDetailsByIdApiRequestBuilder WithCurrentId(UserId currentId, IStringTransformer? transformer = null)
	{
		_currentId = transformer.TryTransform(currentId.Id);

		return this;
	}

	public GetCurrentUserDetailsByIdApiRequestBuilder WithCurrentId(IStringTransformer transformer)
	{
		_currentId = transformer.Transform(_currentId);

		return this;
	}

	public GetCurrentUserDetailsByIdApiRequest Build()
	{
		return new(_currentId);
	}
}
