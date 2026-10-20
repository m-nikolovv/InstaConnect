namespace InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

public interface IPostFluent : IMongoDbFluent<Post>
{
	public IPostFluent Match(PostsFilterQuery filter);
	public IPostFluent Match(PostsForUserFilterQuery filter);
	public IPostFluent Match(PostId filter);
	public IPostResponseFluent ProjectToFullResponse(CurrentUserQuery currentUser);
	public IPostResponseFluent ProjectToResponseWithoutUser(CurrentUserQuery currentUser);
	public IPostFluent ApplyIncludes(PostInclude include);
}
