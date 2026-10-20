using InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IPostCommentLikeQueryRepository GetPostCommentLikeQueryRepository()
		{
			return serviceProvider.GetRequiredService<IPostCommentLikeQueryRepository>();
		}

		public IPostCommentLikeCommandRepository GetPostCommentLikeCommandRepository()
		{
			return serviceProvider.GetRequiredService<IPostCommentLikeCommandRepository>();
		}

		public IPostCommentLikeIncludeBuilderFactory GetPostCommentLikeIncludeBuilderFactory()
		{
			return serviceProvider.GetRequiredService<IPostCommentLikeIncludeBuilderFactory>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IPostCommentLikeQueryRepository GetPostCommentLikeQueryRepository()
		{
			return serviceScope.ServiceProvider.GetPostCommentLikeQueryRepository();
		}

		public IPostCommentLikeCommandRepository GetPostCommentLikeCommandRepository()
		{
			return serviceScope.ServiceProvider.GetPostCommentLikeCommandRepository();
		}

		public IPostCommentLikeIncludeBuilderFactory GetPostCommentLikeIncludeBuilderFactory()
		{
			return serviceScope.ServiceProvider.GetPostCommentLikeIncludeBuilderFactory();
		}

		public async Task<PostCommentLike?> GetByIdAsync(
			PostCommentLikeId id,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetPostIncludeBuilderFactory().Create().WithUser().Build();
			var commentInclude = serviceScope.GetPostCommentIncludeBuilderFactory().Create().WithUser().WithPost(include).Build();
			var commentLikeInclude = serviceScope.GetPostCommentLikeIncludeBuilderFactory().Create().WithPostComment(commentInclude).WithUser().Build();

			return (await serviceScope.GetPostCommentLikeCommandRepository().GetByIdAsync(id, commentLikeInclude, cancellationToken)).SetUser().SetPostComment();
		}

		public async Task AddAsync(
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetPostCommentLikeCommandRepository().AddAsync(postCommentLike, cancellationToken);
		}

		public async Task AddRangeAsync(
			IEnumerable<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetPostCommentLikeCommandRepository().AddRangeAsync(postCommentLikes, cancellationToken);
		}

		public async Task DeleteAsync(
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetPostCommentLikeCommandRepository().DeleteAsync(postCommentLike, cancellationToken);
		}
	}
}

