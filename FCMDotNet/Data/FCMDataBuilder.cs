using FCMDotNet.Model.ModelData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCMDotNet.Data
{
    public class FCMDataBuilder
    {
        private string _to;
        private FCMData _data;
        private IList<string> _regIds;

        public FCMDataBuilder SetRegistrationToken(string registrationToken)
        {
            _to = registrationToken;
            return this;
        }

        public FCMDataBuilder SetData(FCMData data)
        {
            _data = data;
            return this;
        }

        public FCMDataBuilder SetRegistrationIds(IList<string> regIds)
        {
            if (regIds?.Count < 1 || regIds?.Count > 1000)
            {
                throw new ArgumentException("Registration Ids must be between 1 and 1000");
            }
            _regIds = regIds;
            return this;
        }

        public FCMDataMessage Build()
        {
            if (!(!string.IsNullOrEmpty(_to) || _regIds?.Count > 0))
            {
                throw new ArgumentException("You must supply a topic, registration token, or registration ids");
            }

            // For now only a body is a requirement, but for iOS silent pushes this will not be necessary
            if (string.IsNullOrEmpty(_data.ToString()))
            {
                throw new ArgumentException("You must supply a message");
            }

            if (_regIds?.Count > 0)
            {
                return new FCMDataMessage(_regIds, _data);
            }
            else
            {
                return new FCMDataMessage(_to, _data);
            }
        }
    }
}
