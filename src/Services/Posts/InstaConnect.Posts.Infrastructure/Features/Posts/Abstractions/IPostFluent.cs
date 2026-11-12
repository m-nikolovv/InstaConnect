namespace InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

public interface IPostFluent : IMongoDbFluent<Post, PostId>
{
	public IPostFluent Match(PostsFilterQuery filter);
	public IPostFluent Match(PostsForUserFilterQuery filter);
	public IPostFluent Match(PostId filter);
	public IPostFluent Match(IEnumerable<PostId> filter);
	public IPostFluent ApplySorting(PostsSortingQuery query);
	public IPostFluent ApplySorting(PostsForUserSortingQuery query);
	public IPostFluent ApplyPagination(PostsPaginationQuery query);
	public IPostResponseFluent ProjectToFullResponse(CurrentUserQuery currentUser);
	public IPostResponseFluent ProjectToResponseWithoutUser(CurrentUserQuery currentUser);
	public IPostFluent ApplyIncludes(PostInclude include);
}
