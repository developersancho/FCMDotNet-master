using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCMDotNet.Model.ModelData
{
    public class FCMDataMessage
    {
        public IList<string> Registration_Ids { get; }

        /// <summary>
        /// The message recipient
        /// </summary>
        public string To { get; }
        /// <summary>
        /// The Notification Payload
        /// </summary>
        public FCMData Data { get; }

        protected internal FCMDataMessage()
        {

        }

        protected internal FCMDataMessage(string to, FCMData data)
        {
            To = to;
            Data = data;
        }

        protected internal FCMDataMessage(IList<string> registrationIds, FCMData data)
        {
            Registration_Ids = registrationIds;
            Data = data;
        }
    }


    public class FCMData
    {
        public string image { get; set; }
        public bool is_background { get; set; }
        public FCMDataPayload payload { get; set; }
        public string title { get; set; }
        public string message { get; set; }
        public string timestamp { get; set; }

        public FCMData(string image, bool is_background, string title, string message, string timestamp, FCMDataPayload payload)
        {
            this.image = image;
            this.is_background = is_background;
            this.title = title;
            this.message = message;
            this.timestamp = timestamp;
            this.payload = payload;
        }
    }

    public class FCMDataPayload
    {
        public string score { get; set; }
        public string team { get; set; }

        public FCMDataPayload(string score, string team)
        {
            this.score = score;
            this.team = team;
        }
    }

    public class FCMDataResponseResult
    {
        public string message_id { get; set; }
    }

    public class FCMDataResponse
    {
        public long multicast_id { get; set; }
        public int success { get; set; }
        public int failure { get; set; }
        public int canonical_ids { get; set; }
        public List<FCMDataResponseResult> results { get; set; }
    }
}
