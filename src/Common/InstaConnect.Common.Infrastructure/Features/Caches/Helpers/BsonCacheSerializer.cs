using MongoDB.Bson;
using MongoDB.Bson.Serialization;

using ZiggyCreatures.Caching.Fusion.Serialization;

namespace InstaConnect.Common.Infrastructure.Features.Caches.Helpers;

internal class BsonCacheSerializer : IFusionCacheSerializer
{
	public byte[] Serialize<T>(T? obj)
	{
		return obj.ToBson();
	}

	public T? Deserialize<T>(byte[] data)
	{
		return BsonSerializer.Deserialize<T>(data);
	}

	public ValueTask<byte[]> SerializeAsync<T>(T? obj, CancellationToken token = default)
	{
		return ValueTask.FromResult(Serialize(obj));
	}

	public ValueTask<T?> DeserializeAsync<T>(byte[] data, CancellationToken token = default)
	{
		return ValueTask.FromResult(Deserialize<T>(data));
	}
}
