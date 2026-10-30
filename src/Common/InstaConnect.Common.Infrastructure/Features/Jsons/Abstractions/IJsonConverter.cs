namespace InstaConnect.Common.Infrastructure.Features.Jsons.Abstractions;

public interface IJsonConverter
{
	public T? Deserialize<T>(string? value);
	public string Serialize(object? obj);
}
