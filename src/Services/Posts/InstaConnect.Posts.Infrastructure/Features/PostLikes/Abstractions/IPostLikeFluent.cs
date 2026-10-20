namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;

public interface IPostLikeFluent : IMongoDbFluent<PostLike>
{
	public IPostLikeFluent Match(PostLikesFilterQuery filter);
	public IPostLikeFluent Match(PostLikesForUserFilterQuery filter);
	public IPostLikeFluent Match(PostLikeId filter);
	public IPostLikeResponseFluent ProjectToFullResponse(CurrentUserQuery currentUser);
	public IPostLikeResponseFluent ProjectToResponseWithoutUser(CurrentUserQuery currentUser);
	public IPostLikeResponseFluent ProjectToResponseWithoutPost(CurrentUserQuery currentUser);
	public IPostLikeFluent ApplyIncludes(PostLikeInclude include);
}
