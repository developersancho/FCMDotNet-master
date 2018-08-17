using FCMDotNet;
using FCMDotNet.Data;
using FCMDotNet.Model.ModelData;

namespace FCMDotNetExample
{

    public class Example
    {
        static void Main(string[] args)
        {
            var fcmServerKey = "AAAAWu9dHLM:APA91bHSJufe7k8vG4zr0cxP4cttjX4_gLS9l87wX9NhhrDW2QqX-79SbMl9dVg4xPwvfKVTBBP1_fnZ9Ti7AumPAtocMlN9eXbIJMnlbRQgrKRjtX6RMSQ3kMYPFSE9WVjURk6IZ4-Oky88cMHdD4hdhoLnhOQBBg";



            var registrationToken = "fWFJllb9ky4:APA91bHox-jqVj8fWpsKYgIa7rWm5d7XKjlmUYsWlpxQOp57EgDLXrfBJG9cFQoQeVQ6CqmrkKhhzRRgQWc8kSIjnMTdZ7MHsb5MTCgRAJP74PqlPtxIHdN0Sv68LrxigF1KPCr51omJ3SdAzjYIciQUOQmm_Z8q_g";


            #region Send Notification
            //SendNotification(fcmServerKey, registrationToken);
            #endregion

            #region Send Data
            SendData(fcmServerKey, registrationToken);
            #endregion
        }

        private static void SendNotification(string fcmServerKey, string registrationToken)
        {
            var client = new FCMClient(fcmServerKey);
            var builder = new FCMMessageBuilder();
            var message = "HOLA";
            builder.SetMessage(message);
            builder.SetRegistrationToken(registrationToken);
            builder.SetTitle("AMİGO");

            var msg = builder.Build();
            client.PostMessage(msg).Wait();
        }

        private static void SendData(string fcmServerKey, string registrationToken)
        {
            var client = new FCMDataClient(fcmServerKey);
            var builder = new FCMDataBuilder();
            builder.SetRegistrationToken(registrationToken);
            builder.SetData(new FCMData("", false, "Data Title", "data message", "2018-08-17 2:11:08", new FCMDataPayload("10", "developer sancho team")));

            var msg = builder.Build();
            client.PostDataMessageAsync(msg).Wait();
        }
    }
}