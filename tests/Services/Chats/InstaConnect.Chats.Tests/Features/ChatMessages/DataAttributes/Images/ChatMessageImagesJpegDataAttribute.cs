using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Jpeg;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Images;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatMessageImagesJpegDataAttribute : JpegFormFileCollectionDataAttribute
{
}
