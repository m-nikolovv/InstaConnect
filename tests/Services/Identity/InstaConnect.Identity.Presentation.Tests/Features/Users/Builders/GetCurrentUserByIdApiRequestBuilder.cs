namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Builders;

public class GetCurrentUserByIdApiRequestBuilder
{
	private string _currentId;

	public GetCurrentUserByIdApiRequestBuilder(User user, UserId currentId)
	{
		_currentId = currentId.Id;
	}

	public GetCurrentUserByIdApiRequestBuilder WithCurrentId(UserId currentId, IStringTransformer? transformer = null)
	{
		_currentId = transformer.TryTransform(currentId.Id);

		return this;
	}

	public GetCurrentUserByIdApiRequestBuilder WithCurrentId(IStringTransformer transformer)
	{
		_currentId = transformer.Transform(_currentId);

		return this;
	}

	public GetCurrentUserByIdApiRequest Build()
	{
		return new(_currentId);
	}
}
