namespace InstaConnect.Common.Tests.Features.DataAttributes.DateTimeOffsets.Base;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class DateTimeOffsetWithMessageDataAttribute : DateTimeOffsetDataAttribute
{
	public IDateTimeOffsetMessageTransformer MessageTransformer { get; }

	protected DateTimeOffsetWithMessageDataAttribute(
		IDateTimeOffsetTransformer transformer, IDateTimeOffsetMessageTransformer messageTransformer)
		: base(transformer)
	{
		MessageTransformer = messageTransformer;
	}

	public override IEnumerable<object[]> GetData(MethodInfo testMethod)
	{
		yield return new object[] { Transformer, MessageTransformer };
	}
}
