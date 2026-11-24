using Microsoft.AspNetCore.Http;

namespace Scribo.Core.Interfaces
{
    public interface IAudioTranscriptionService
    {
        Task<string> TranscribeAudioAsync(IFormFile audioFile);
    }
}
