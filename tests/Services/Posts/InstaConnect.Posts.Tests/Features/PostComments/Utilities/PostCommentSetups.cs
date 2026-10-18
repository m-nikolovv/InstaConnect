using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Domain.Features.PostComments.Models.ValueObjects;
using InstaConnect.Posts.Tests.Features.PostCommentImages.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Tests.Features.PostComments.Utilities;

public static class PostCommentSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IPostCommentQueryRepository GetPostCommentQueryRepository()
		{
			return serviceProvider.GetRequiredService<IPostCommentQueryRepository>();
		}

		public IPostCommentCommandRepository GetPostCommentCommandRepository()
		{
			return serviceProvider.GetRequiredService<IPostCommentCommandRepository>();
		}

		public IPostCommentIncludeBuilderFactory GetPostCommentIncludeBuilderFactory()
		{
			return serviceProvider.GetRequiredService<IPostCommentIncludeBuilderFactory>();
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
	}
}
