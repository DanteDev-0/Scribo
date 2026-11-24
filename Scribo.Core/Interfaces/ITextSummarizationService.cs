

namespace Scribo.Core.Interfaces
{
    public interface ITextSummarizationService
    {
        Task<string> SummarizeLectureAsync(string rawTranscript, string courseName, string subject);
    }
}
