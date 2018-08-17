using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCMDotNet.Model;

namespace FCMDotNet
{
    public class FCMException : Exception
    {
        public FCMResponse Response { get; }

        public FCMException(FCMResponse response)
        {
            Response = response;
        }
    }
}
