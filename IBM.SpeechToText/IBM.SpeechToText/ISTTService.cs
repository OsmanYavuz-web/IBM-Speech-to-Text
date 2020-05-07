/*
 *
 * Osman Yavuz
 * omnyvz.yazilim@gmail.com
 *
 */
namespace IBM.SpeechToText
{
    public interface ISTTService
    {
        void SetModel(string modelId = "en-US_BroadbandModel");
        string Recognize(string audioPath);
    }
}
