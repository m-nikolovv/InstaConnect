namespace InstaConnect.Common.Tests.Features.DataAttributes.Base;

public interface IMessageTransformer<TValue>
{
	public string Transform<T>(Expression<Func<T, TValue>> propertyExpression, TValue value);
}
