using InstaConnect.Common.Domain.Features.ValueObjects.Abstractions;

namespace InstaConnect.Common.Domain.Features.ValueObjects.Models;

public record Url(string Value) : IValueObject;
