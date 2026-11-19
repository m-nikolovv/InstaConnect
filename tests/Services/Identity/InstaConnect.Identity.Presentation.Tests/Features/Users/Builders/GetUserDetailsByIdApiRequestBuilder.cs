namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Builders;

public class GetUserDetailsByIdApiRequestBuilder
{
	private string _id;
	private string _currentId;

	public GetUserDetailsByIdApiRequestBuilder(User user, UserId currentId)
	{
		_id = user.Id.Id;
		_currentId = currentId.Id;
	}

	public GetUserDetailsByIdApiRequestBuilder WithId(UserId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public GetUserDetailsByIdApiRequestBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public GetUserDetailsByIdApiRequestBuilder WithCurrentId(UserId currentId, IStringTransformer? transformer = null)
	{
		_currentId = transformer.TryTransform(currentId.Id);

		return this;
	}

	public GetUserDetailsByIdApiRequestBuilder WithCurrentId(IStringTransformer transformer)
	{
		_currentId = transformer.Transform(_currentId);

		return this;
	}

	public GetUserDetailsByIdApiRequest Build()
	{
		return new(_id, _currentId);
	}
}
