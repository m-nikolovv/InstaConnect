namespace InstaConnect.Chats.Tests.Features.Chats.Utilities;

public static class ChatGenerator
{
	extension(Chat baseChat)
	{
		public ICollection<Chat> GenerateAttached(IEnumerable<User> participantOnes, IEnumerable<User> participantTwos)
		{
			var chats = baseChat.Generate(participantOnes, participantTwos);

			foreach (var chat in chats.Where(c => c != baseChat))
			{
				chat.ParticipantOne!.AddChat(chat);
				chat.ParticipantTwo!.AddChat(chat);
			}

			return chats;
		}

		public ICollection<Chat> Generate(IEnumerable<User> participantOnes, IEnumerable<User> participantTwos)
		{
			return [.. participantOnes
			  .SelectMany(participantOne =>
				  participantTwos.Select(participantTwo =>
				  {
					  var chat = new Chat(
						  new(participantOne.Id, participantTwo.Id),
						  ChatDataFaker.GetCreatedAtUtc());

					  if(baseChat.Id == chat.Id)
					  {
						  return baseChat;
					  }

					  chat.AddParticipantOne(participantOne);
					  chat.AddParticipantTwo(participantTwo);

					  return chat;
				  }))];
		}
	}
}
