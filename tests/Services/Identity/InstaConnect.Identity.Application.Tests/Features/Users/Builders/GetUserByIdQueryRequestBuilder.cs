namespace InstaConnect.Identity.Application.Tests.Features.Users.Builders;

public class GetUserByIdQueryRequestBuilder
{
	private string _id;
	private string _currentId;

	public GetUserByIdQueryRequestBuilder(User user, UserId currentId)
	{
		_id = user.Id.Id;
		_currentId = currentId.Id;
	}

	public GetUserByIdQueryRequestBuilder WithId(UserId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public GetUserByIdQueryRequestBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public GetUserByIdQueryRequestBuilder WithCurrentId(UserId currentId, IStringTransformer? transformer = null)
	{
		_currentId = transformer.TryTransform(currentId.Id);

		return this;
	}

	public GetUserByIdQueryRequestBuilder WithCurrentId(IStringTransformer transformer)
	{
		_currentId = transformer.Transform(_currentId);

		return this;
	}

	public GetUserByIdQueryRequest Build()
	{
		return new(_id, _currentId);
	}
}
