using MongoDB.Bson;

namespace InstaConnect.Common.Infrastructure.Features.Databases.Helpers;

internal class DateTimeOffsetIndexKeysDefinition<TEntity> : IndexKeysDefinition<TEntity>
{
	private const string DateTimeElementName = "DateTime";

	private readonly int _direction;
	private readonly Expression<Func<TEntity, DateTimeOffset>> _field;

	public DateTimeOffsetIndexKeysDefinition(
		int direction,
		Expression<Func<TEntity, DateTimeOffset>> field)
	{
		_direction = direction;
		_field = field;
	}

	public override BsonDocument Render(RenderArgs<TEntity> args)
	{
		var fieldName = new ExpressionFieldDefinition<TEntity, DateTimeOffset>(_field).Render(args).FieldName;

		return new BsonDocument($"{fieldName}.{DateTimeElementName}", _direction);
	}
}
