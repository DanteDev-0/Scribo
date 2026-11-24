using Microsoft.AspNetCore.Http;
using OpenAI;
using OpenAI.Audio;
using Scribo.Core.Interfaces;

namespace Scribo.Service
{
    public class WhisperTranscriptionService(OpenAIClient openAIClient) : IAudioTranscriptionService
    {
        private readonly AudioClient _audioClient = openAIClient.GetAudioClient("whisper-1");

        public async Task<string> TranscribeAudioAsync(IFormFile audioFile)
        {
            var options = new AudioTranscriptionOptions
            {
                Language = "tr"
            };


            using var stream = audioFile.OpenReadStream();

            var result = await _audioClient.TranscribeAudioAsync(stream, audioFile.FileName, options);
            return result.Value.Text;
        }
    }
}
