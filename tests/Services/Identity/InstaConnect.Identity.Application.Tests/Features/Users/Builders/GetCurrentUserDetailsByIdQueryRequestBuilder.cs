namespace InstaConnect.Identity.Application.Tests.Features.Users.Builders;

public class GetCurrentUserDetailsByIdQueryRequestBuilder
{
	private string _currentId;

	public GetCurrentUserDetailsByIdQueryRequestBuilder(User user, UserId currentId)
	{
		_currentId = currentId.Id;
	}

	public GetCurrentUserDetailsByIdQueryRequestBuilder WithCurrentId(UserId currentId, IStringTransformer? transformer = null)
	{
		_currentId = transformer.TryTransform(currentId.Id);

		return this;
	}

	public GetCurrentUserDetailsByIdQueryRequestBuilder WithCurrentId(IStringTransformer transformer)
	{
		_currentId = transformer.Transform(_currentId);

		return this;
	}

	public GetCurrentUserDetailsByIdQueryRequest Build()
	{
		return new(_currentId);
	}
}
