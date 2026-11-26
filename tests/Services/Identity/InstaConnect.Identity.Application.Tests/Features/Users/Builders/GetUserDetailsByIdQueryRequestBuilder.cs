namespace InstaConnect.Identity.Application.Tests.Features.Users.Builders;

public class GetUserDetailsByIdQueryRequestBuilder
{
	private string _id;
	private string _currentId;

	public GetUserDetailsByIdQueryRequestBuilder(User user, UserId currentId)
	{
		_id = user.Id.Id;
		_currentId = currentId.Id;
	}

	public GetUserDetailsByIdQueryRequestBuilder WithId(UserId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public GetUserDetailsByIdQueryRequestBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public GetUserDetailsByIdQueryRequestBuilder WithCurrentId(UserId currentId, IStringTransformer? transformer = null)
	{
		_currentId = transformer.TryTransform(currentId.Id);

		return this;
	}

	public GetUserDetailsByIdQueryRequestBuilder WithCurrentId(IStringTransformer transformer)
	{
		_currentId = transformer.Transform(_currentId);

		return this;
	}

	public GetUserDetailsByIdQueryRequest Build()
	{
		return new(_id, _currentId);
	}
}
