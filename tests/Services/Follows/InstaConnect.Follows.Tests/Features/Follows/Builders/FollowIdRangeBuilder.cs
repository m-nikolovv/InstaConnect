using InstaConnect.Follows.Domain.Features.Follows.Models.ValueObjects;

namespace InstaConnect.Follows.Tests.Features.Follows.Builders;

public class FollowIdRangeBuilder
{
	private readonly ICollection<FollowIdBuilder> _idBuilders;

	public FollowIdRangeBuilder(ICollection<FollowIdBuilder> idBuilders)
	{
		_idBuilders = idBuilders;
	}

	public FollowIdRangeBuilder WithFollowerId(IStringTransformer transformer)
	{
		foreach (var idBuilder in _idBuilders)
		{
			idBuilder.WithFollowerId(transformer);
		}

		return this;
	}

	public FollowIdRangeBuilder WithFollowingId(IStringTransformer transformer)
	{
		foreach (var idBuilder in _idBuilders)
		{
			idBuilder.WithFollowingId(transformer);
		}

		return this;
	}

	public ICollection<FollowId> Build()
	{
		return [.. _idBuilders.Select(idBuilder => idBuilder.Build())];
	}
}
