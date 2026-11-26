using InstaConnect.Common.Infrastructure.Features.Caches.Utilities;

using StackExchange.Redis;

namespace InstaConnect.Common.Infrastructure.Features.Caches.Extensions;

public static class DatabaseExtensions
{
	extension(IDatabase database)
	{
		public async Task AddChildTagsAsync(IEnumerable<string> parentTags, IEnumerable<string> tags, CancellationToken cancellationToken)
		{
			var childTags = tags.Select(p => new RedisValue(p)).ToArray();

			foreach (var parentTag in parentTags)
			{
				await database
					.SetAddAsync(CacheUtilities.GetDependencyKey(parentTag), childTags)
					.WaitAsync(cancellationToken);
			}
		}

		public async Task<ICollection<string>> GetDescendantTagsAsync(string tag, CancellationToken cancellationToken)
		{
			return await database.GetDescendantTagsAsync([tag], cancellationToken);
		}

		public async Task<ICollection<string>> GetDescendantTagsAsync(IEnumerable<string> tags, CancellationToken cancellationToken)
		{
			var descendantTags = tags.ToHashSet();
			var pendingTags = descendantTags;

			while (pendingTags.Any())
			{
				var childTags = await database
					.SetCombineAsync(SetOperation.Union, [.. pendingTags.Select(CacheUtilities.GetDependencyKey)])
					.WaitAsync(cancellationToken);

				pendingTags = [.. childTags.Select(p => p.ToString())];

				descendantTags.UnionWith(pendingTags);
			}

			return descendantTags;
		}
	}
}
