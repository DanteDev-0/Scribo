using OpenAI;
using OpenAI.Chat;
using Scribo.Core.Interfaces;

namespace Scribo.Service
{
    public class GptSummarizationService(OpenAIClient openAIClient) : ITextSummarizationService
    {
        private readonly ChatClient _chatClient = openAIClient.GetChatClient("gpt-4o-mini");

        public async Task<string> SummarizeLectureAsync(string rawTranscript, string courseName, string subject)
        {
            List<ChatMessage> messages =
            [
                new SystemChatMessage(
                    "Sen üniversite ders kayıtlarını düzenli, sınav odaklı ve kavram kaybı olmadan yapılandırılmış Markdown ders notlarına dönüştüren bir asistansın."),
                new UserChatMessage(
                    $"Ders: {courseName}\nKonu: {subject}\n\nHam Ders Dökümü:\n{rawTranscript}")
            ];

            var completion = await _chatClient.CompleteChatAsync(messages);
            return completion.Value.Content.FirstOrDefault()?.Text ?? string.Empty;
        }
    }
}
