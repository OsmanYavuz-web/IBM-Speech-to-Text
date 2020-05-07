/*
 *
 * Osman Yavuz
 * omnyvz.yazilim@gmail.com
 *
 */

using System;
using System.IO;
using IBM.Cloud.SDK.Core.Authentication.Iam;
using IBM.Cloud.SDK.Core.Http.Exceptions;
using IBM.Watson.SpeechToText.v1;
using Newtonsoft.Json.Linq;

namespace IBM.SpeechToText
{
    public class STTManager : ISTTService
    {
        private readonly SpeechToTextService _speechToTextService;

        public STTManager(string apiKey, string serviceUrl)
        {
            try
            {
                var authenticator = new IamAuthenticator(
                    apikey: apiKey
                );
                _speechToTextService = new SpeechToTextService(authenticator);
                _speechToTextService.SetServiceUrl(serviceUrl);
                SetModel();
            }
            catch //(Exception e)
            {
                //Console.WriteLine("Error: " + e.Message);
            }
        }

        public void SetModel(string modelId = "en-US_BroadbandModel")
        {
            _speechToTextService.GetModel(modelId: modelId);
        }


        public string Recognize(string audioPath)
        {
            try
            {
                var result = _speechToTextService.Recognize(
                    audio: File.ReadAllBytes(audioPath),
                    contentType: "audio/mp3"
                );

                var jsonJObject = JObject.Parse(result.Response);
                return (string)jsonJObject["results"][0]["alternatives"][0]["transcript"];
            }
            catch
            {
                return null;
            }
        }
    }
}
