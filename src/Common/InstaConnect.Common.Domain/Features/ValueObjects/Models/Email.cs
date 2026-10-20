namespace InstaConnect.Common.Domain.Features.ValueObjects.Models;

public record Email(string Value) : IValueObject
{
	public bool Is(Email email)
	{
		return Value.EqualsOrdinalIgnoreCase(email.Value);
	}

	public bool IsNot(Email email)
	{
		return !Is(email);
	}

	public bool IsEmpty()
	{
		return Value.IsNullOrEmptyOrWhiteSpace();
	}
}
