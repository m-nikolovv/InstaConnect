using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Common.Infrastructure.Tests.Features.Builders;
using InstaConnect.Posts.Tests.Features.Users.DataAttributes.Email;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.Users.Repositories;

public class GetUserByEmailCommandRepositoryIntegrationTests : BaseUserInfrastructureCommandIntegrationTest
{
	private readonly EmailBuilderFactory _emailBuilderFactory;
	private readonly EmailBuilder _emailBuilder;
	private readonly Email _email;

	private readonly UserInclude _include;

	public GetUserByEmailCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_emailBuilderFactory = new();
		_emailBuilder = _emailBuilderFactory.Create(User.Email);
		_email = _emailBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithPosts().WithPostLikes().Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
	}

	[Fact]
	public async Task GetByEmailAsync_ShouldReturnNull_WhenEmailIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		var response = await Repository.GetByEmailAsync(_email, _include, CancellationToken);

		// Assert
		response.ShouldBeNull();
	}

	[Fact]
	public async Task GetByEmailAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.GetByEmailAsync(_email, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(_email, User);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task GetByEmailAsync_ShouldReturnResponse_WhenCommandAndEmailAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var email = _emailBuilder.WithEmail(transformer).Build();

		// Act
		var response = await Repository.GetByEmailAsync(email, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(email, User);
	}
}
