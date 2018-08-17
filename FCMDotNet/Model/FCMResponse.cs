using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FCMDotNet.Model
{
    public class FCMResponse
    {
        public string MulticastId { get; set; }

        public List<FCMResponseResult> Results { get; set; }

    }
    public class FCMResponseResult
    {
        public string MessageId { get; set; }
        public string Error { get; set; }
        public string RegistrationId { get; set; }
    }
}
