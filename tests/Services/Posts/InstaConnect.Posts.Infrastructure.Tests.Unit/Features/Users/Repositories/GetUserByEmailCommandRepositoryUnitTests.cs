using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Common.Infrastructure.Tests.Features.Builders;
using InstaConnect.Posts.Domain.Features.Users.Models.Requests;
using InstaConnect.Posts.Infrastructure.Features.Users.Helpers.Repositories;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.Users.Repositories;

public class GetUserByEmailCommandRepositoryUnitTests : BaseUserInfrastructureCommandUnitTest
{
	private readonly EmailBuilderFactory _emailBuilderFactory;
	private readonly EmailBuilder _emailBuilder;
	private readonly Email _email;

	private readonly UserInclude _include;

	private readonly UserCommandRepository _repository;

	public GetUserByEmailCommandRepositoryUnitTests()
	{
		_emailBuilderFactory = new();
		_emailBuilder = _emailBuilderFactory.Create(User.Email);
		_email = _emailBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithPosts().WithPostLikes().Build();

		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(_email, Fluent);
		Fluent.SetupApplyIncludes(_email, _include);
		Fluent.SetupMatch(_email);
		Fluent.SetupFirstOrDefaultAsync(_email, User, CancellationToken);
	}

	[Fact]
	public async Task GetByEmailAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _repository.GetByEmailAsync(_email, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(_email, User);
	}

	[Fact]
	public async Task GetByEmailAsync_ShouldCallTheCollectionAggregateFluent_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByEmailAsync(_email, _include, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(_email);
	}

	[Fact]
	public async Task GetByEmailAsync_ShouldCallTheFluentApplyIncludes_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByEmailAsync(_email, _include, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneApplyIncludes(_email, _include);
	}

	[Fact]
	public async Task GetByEmailAsync_ShouldCallTheFluentMatch_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByEmailAsync(_email, _include, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(_email);
	}

	[Fact]
	public async Task GetByEmailAsync_ShouldCallTheFluentFirstOrDefaultAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.GetByEmailAsync(_email, _include, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(_email, CancellationToken);
	}
}
