using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FCMDotNet.Model.ModelData;
using RestSharp;

namespace FCMDotNet.Data
{
    public class FCMDataClient : IFCMDataClient
    {
        private readonly RestClient _restClient;
        private readonly NewtonsoftJSONSerializer _jsonSerializer;

        public FCMDataClient(string fcmServerKey)
        {
            if (string.IsNullOrEmpty(fcmServerKey))
            {
                throw new ArgumentException($"{nameof(fcmServerKey)} cannot be null or empty");
            }
            _restClient = new RestClient("https://fcm.googleapis.com/");
            _restClient.AddDefaultHeader("Authorization", "key=" + fcmServerKey);

            _jsonSerializer = new NewtonsoftJSONSerializer();
        }

        public async Task<FCMDataResponse> PostDataMessageAsync(FCMDataMessage message)
        {
            var request = new RestRequest("fcm/send", Method.POST) { JsonSerializer = _jsonSerializer };
            request.AddJsonBody(message);

            var response = await _restClient.ExecuteTaskAsync<FCMDataResponse>(request);

            var statusCode = response.StatusCode;
            var responseData = response.Data;
            if (statusCode == HttpStatusCode.OK)
            {
                return responseData;
            }
            else
            {
                throw new FCMDataException(responseData);
            }
        }
    }
}
