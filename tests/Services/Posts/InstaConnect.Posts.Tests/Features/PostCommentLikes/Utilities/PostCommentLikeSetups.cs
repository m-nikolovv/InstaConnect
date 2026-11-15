using InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Repositories;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IPostCommentLikeQueryRepository GetPostCommentLikeQueryRepository()
		{
			return new PostCommentLikeQueryRepository(
				serviceProvider.GetPostCommentLikeCollection(),
				serviceProvider.GetPostIncludeBuilderFactory(),
				serviceProvider.GetPostCommentIncludeBuilderFactory(),
				serviceProvider.GetPostCommentLikeIncludeBuilderFactory());
		}

		public IPostCommentLikeCommandRepository GetPostCommentLikeCommandRepository()
		{
			return new PostCommentLikeCommandRepository(
				serviceProvider.GetPostCommentLikeCollection(),
				serviceProvider.GetPostCommentLikeIncludeBuilderFactory());
		}

		public IPostCommentLikeIncludeBuilderFactory GetPostCommentLikeIncludeBuilderFactory()
		{
			return serviceProvider.GetRequiredService<IPostCommentLikeIncludeBuilderFactory>();
		}

		public IPostCommentLikeCollection GetPostCommentLikeCollection()
		{
			return serviceProvider.GetRequiredService<IPostCommentLikeCollection>();
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

		public async Task<ICollection<PostCommentLike>> GetByIdRangeAsync(
			IEnumerable<PostCommentLikeId> ids,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetPostIncludeBuilderFactory().Create().WithUser().Build();
			var commentInclude = serviceScope.GetPostCommentIncludeBuilderFactory().Create().WithUser().WithPost(include).Build();
			var commentLikeInclude = serviceScope.GetPostCommentLikeIncludeBuilderFactory().Create().WithPostComment(commentInclude).WithUser().Build();

			return (await serviceScope.GetPostCommentLikeCommandRepository().GetByIdRangeAsync(ids, commentLikeInclude, cancellationToken)).SetUser().SetPostComment();
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

		public async Task DeleteRangeAsync(
			IEnumerable<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			foreach (var postCommentLike in postCommentLikes)
			{
				await serviceScope.DeleteAsync(postCommentLike, cancellationToken);
			}
		}
	}
}

