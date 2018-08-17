using System;
using System.Collections.Generic;
using FCMDotNet.Model;

namespace FCMDotNet
{
    /// <summary>
    /// Builds FCM paylods
    /// </summary>
    public class FCMMessageBuilder
    {
        private string _to;
        private string _title;
        private string _body;
        private IList<string> _regIds;

        public FCMMessageBuilder SetTopic(string topic)
        {
            if (!string.IsNullOrEmpty(topic))
            {
                _to = "/topics/" + topic;
            }
            return this;
        }

        public FCMMessageBuilder SetRegistrationToken(string registrationToken)
        {
            _to = registrationToken;
            return this;
        }

        public FCMMessageBuilder SetTitle(string title)
        {
            _title = title;
            return this;
        }

        public FCMMessageBuilder SetMessage(string message)
        {
            _body = message;
            return this;
        }


        public FCMMessageBuilder SetRegistrationIds(IList<string> regIds)
        {
            if (regIds?.Count < 1 || regIds?.Count > 1000)
            {
                throw new ArgumentException("Registration Ids must be between 1 and 1000");
            }
            _regIds = regIds;
            return this;
        }

        public FCMMessage Build()
        {
            if (!(!string.IsNullOrEmpty(_to) || _regIds?.Count > 0))
            {
                throw new ArgumentException("You must supply a topic, registration token, or registration ids");
            }

            // For now only a body is a requirement, but for iOS silent pushes this will not be necessary
            if (string.IsNullOrEmpty(_body))
            {
                throw new ArgumentException("You must supply a message");
            }

            if (_regIds?.Count > 0)
            {
                return new FCMMessage(_regIds, new FCMMessageNotification(_title, _body));
            }
            else
            {
                return new FCMMessage(_to, new FCMMessageNotification(_title, _body));
            }
        }

    }
}