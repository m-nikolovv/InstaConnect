namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Builders;

public class GetUserByIdApiRequestBuilder
{
	private string _id;
	private string _currentId;

	public GetUserByIdApiRequestBuilder(User user, UserId currentId)
	{
		_id = user.Id.Id;
		_currentId = currentId.Id;
	}

	public GetUserByIdApiRequestBuilder WithId(UserId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public GetUserByIdApiRequestBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public GetUserByIdApiRequestBuilder WithCurrentId(UserId currentId, IStringTransformer? transformer = null)
	{
		_currentId = transformer.TryTransform(currentId.Id);

		return this;
	}

	public GetUserByIdApiRequestBuilder WithCurrentId(IStringTransformer transformer)
	{
		_currentId = transformer.Transform(_currentId);

		return this;
	}

	public GetUserByIdApiRequest Build()
	{
		return new(_id, _currentId);
	}
}
