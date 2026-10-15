using InstaConnect.Common.Domain.Tests.Features.Assertions;
using InstaConnect.Follows.Domain.Features.Follows.Helpers;
using InstaConnect.Follows.Domain.Tests.Features.Follows.Assertions;
using InstaConnect.Follows.Domain.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Domain.Tests.Unit.Features.Follows.Utilities;
using InstaConnect.Follows.Tests.Features.Follows.Assertions;

namespace InstaConnect.Follows.Domain.Tests.Unit.Features.Follows.Factories;

public class CreateFollowFactoryUnitTests : BaseFollowDomainCommandUnitTest
{
	private readonly FollowFactory _factory;

	public CreateFollowFactoryUnitTests()
	{
		_factory = new(DateTimeProvider);

		DateTimeProvider.SetupGetOffsetUtcNow(Follow);
	}

	[Fact]
	public void Create_ShouldCreateFollow_WhenRequestIsValid()
	{
		// Act
		var response = _factory.Create(FollowId.FollowerId, FollowId.FollowingId);

		// Assert
		response.ShouldSatisfy(Follow);
	}

	[Fact]
	public void Create_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenRequestIsValid()
	{
		// Act
		_factory.Create(FollowId.FollowerId, FollowId.FollowingId);

		// Assert
		DateTimeProvider.ShouldHaveReceivedOneGetOffsetUtcNow();
	}
}
