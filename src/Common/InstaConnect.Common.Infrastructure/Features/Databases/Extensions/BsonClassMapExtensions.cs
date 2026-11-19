using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace InstaConnect.Common.Infrastructure.Features.Databases.Extensions;

public static class BsonClassMapExtensions
{
	extension<TClass, TMember>(BsonClassMap<TClass> bsonClassMap)
	{
		public BsonMemberMap MapMemberWithoutSerialization(Expression<Func<TClass, TMember>> member)
		{
			return bsonClassMap.MapMember(member).SetShouldSerializeMethod(_ => false);
		}
	}

	extension<TClass>(BsonClassMap<TClass> bsonClassMap)
	{
		public BsonMemberMap MapDateTimeMember(Expression<Func<TClass, DateTimeOffset>> member)
		{
			return bsonClassMap.MapMember(member).SetSerializer(new DateTimeOffsetSerializer(BsonType.DateTime));
		}

		public void IgnoreExtraElements()
		{
			bsonClassMap.SetIgnoreExtraElements(true);
		}
	}
}
