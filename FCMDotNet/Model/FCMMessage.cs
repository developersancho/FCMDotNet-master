using System.Collections.Generic;
using System.Linq;

namespace FCMDotNet.Model
{
    /// <summary>
    /// Base for the Firebase payload
    /// See https://firebase.google.com/docs/cloud-messaging/http-server-ref#send-downstream
    /// </summary>
    public class FCMMessage
    {
        /// <summary>
        /// List of registration Ids to send to
        /// </summary>
        public IList<string> Registration_Ids { get; }

        /// <summary>
        /// The message recipient
        /// </summary>
        public string To { get; }
        /// <summary>
        /// The Notification Payload
        /// </summary>
        public FCMMessageNotification Notification { get; }

        protected internal FCMMessage()
        {

        }

        protected internal FCMMessage(string to, FCMMessageNotification notification)
        {
            To = to;
            Notification = notification;
        }

        protected internal FCMMessage(IList<string> registrationIds, FCMMessageNotification notification)
        {
            Registration_Ids = registrationIds;
            Notification = notification;
        }
    }
}