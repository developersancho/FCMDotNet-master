using FCMDotNet.Model.ModelData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCMDotNet.Data
{
    public class FCMDataException : Exception
    {
        public FCMDataResponse Response { get; }

        public FCMDataException(FCMDataResponse response)
        {
            Response = response;
        }
    }
}
