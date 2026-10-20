namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;

public interface IPostCommentsSortTermerFactory
	: ISortTermerFactory<PostCommentsSortTerm, IPostCommentsSortTermer, PostCommentResponse>;
