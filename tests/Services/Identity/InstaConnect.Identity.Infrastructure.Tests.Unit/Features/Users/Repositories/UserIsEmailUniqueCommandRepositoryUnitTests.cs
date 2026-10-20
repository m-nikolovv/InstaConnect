using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Common.Infrastructure.Tests.Features.Builders;

namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.Users.Repositories;

public class UserIsEmailUniqueCommandRepositoryUnitTests : BaseUserInfrastructureCommandUnitTest
{
	private readonly EmailBuilderFactory _emailBuilderFactory;
	private readonly EmailBuilder _emailBuilder;
	private readonly Email _email;

	private readonly UserCommandRepository _repository;

	public UserIsEmailUniqueCommandRepositoryUnitTests()
	{
		_emailBuilderFactory = new();
		_emailBuilder = _emailBuilderFactory.Create(User.Email);
		_email = _emailBuilder.Build();

		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(_email, Fluent);
		Fluent.SetupMatch(_email);
		Fluent.SetupAnyAsync(_email, User, CancellationToken);
	}

	[Fact]
	public async Task IsEmailUniqueAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _repository.IsEmailUniqueAsync(_email, CancellationToken);

		// Assert
		response.ShouldSatisfy(_email, User);
	}

	[Fact]
	public async Task IsEmailUniqueAsync_ShouldCallTheCollectionAggregateFluent_WhenCommandIsValid()
	{
		// Act
		await _repository.IsEmailUniqueAsync(_email, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(_email);
	}

	[Fact]
	public async Task IsEmailUniqueAsync_ShouldCallTheFluentMatch_WhenCommandIsValid()
	{
		// Act
		await _repository.IsEmailUniqueAsync(_email, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(_email);
	}

	[Fact]
	public async Task IsEmailUniqueAsync_ShouldCallTheFluentAnyAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.IsEmailUniqueAsync(_email, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneAnyAsync(_email, CancellationToken);
	}
}
