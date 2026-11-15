using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Repositories;

namespace InstaConnect.Posts.Tests.Features.PostComments.Utilities;

public static class PostCommentSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IPostCommentQueryRepository GetPostCommentQueryRepository()
		{
			return new PostCommentQueryRepository(
				serviceProvider.GetPostCommentCollection(),
				serviceProvider.GetPostIncludeBuilderFactory(),
				serviceProvider.GetPostCommentIncludeBuilderFactory());
		}

		public IPostCommentCommandRepository GetPostCommentCommandRepository()
		{
			return new PostCommentCommandRepository(
				serviceProvider.GetPostCommentCollection(),
				serviceProvider.GetPostCommentIncludeBuilderFactory());
		}

		public IPostCommentIncludeBuilderFactory GetPostCommentIncludeBuilderFactory()
		{
			return serviceProvider.GetRequiredService<IPostCommentIncludeBuilderFactory>();
		}

		public IPostCommentCollection GetPostCommentCollection()
		{
			return serviceProvider.GetRequiredService<IPostCommentCollection>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IPostCommentQueryRepository GetPostCommentQueryRepository()
		{
			return serviceScope.ServiceProvider.GetPostCommentQueryRepository();
		}

		public IPostCommentCommandRepository GetPostCommentCommandRepository()
		{
			return serviceScope.ServiceProvider.GetPostCommentCommandRepository();
		}

		public IPostCommentIncludeBuilderFactory GetPostCommentIncludeBuilderFactory()
		{
			return serviceScope.ServiceProvider.GetPostCommentIncludeBuilderFactory();
		}

		public async Task<PostComment?> GetByIdAsync(
			PostCommentId id,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetPostIncludeBuilderFactory().Create().WithUser().Build();
			var commentInclude = serviceScope.GetPostCommentIncludeBuilderFactory().Create().WithUser().WithPost(include).WithPostCommentImages().Build();

			return (await serviceScope.GetPostCommentCommandRepository().GetByIdAsync(id, commentInclude, cancellationToken)).SetUser().SetPost().SetPostCommentImages();
		}

		public async Task<ICollection<PostComment>> GetByIdRangeAsync(
			IEnumerable<PostCommentId> ids,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetPostIncludeBuilderFactory().Create().WithUser().Build();
			var commentInclude = serviceScope.GetPostCommentIncludeBuilderFactory().Create().WithUser().WithPost(include).WithPostCommentImages().Build();

			return (await serviceScope.GetPostCommentCommandRepository().GetByIdRangeAsync(ids, commentInclude, cancellationToken)).SetUser().SetPost();
		}

		public async Task AddAsync(
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetPostCommentCommandRepository().AddAsync(postComment, cancellationToken);
		}

		public async Task AddRangeAsync(
			IEnumerable<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetPostCommentCommandRepository().AddRangeAsync(postComments, cancellationToken);
		}

		public async Task DeleteAsync(
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetPostCommentCommandRepository().DeleteAsync(postComment, cancellationToken);
		}

		public async Task DeleteRangeAsync(
			IEnumerable<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			foreach (var postComment in postComments)
			{
				await serviceScope.DeleteAsync(postComment, cancellationToken);
			}
		}
	}
}
