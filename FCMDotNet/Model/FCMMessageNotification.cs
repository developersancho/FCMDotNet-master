namespace FCMDotNet.Model
{
    /// <summary>
    /// The notification portion of the FCM payload
    /// See https://firebase.google.com/docs/cloud-messaging/concept-options#notifications
    /// and https://firebase.google.com/docs/cloud-messaging/http-server-ref#notification-payload-support
    /// </summary>
    public class FCMMessageNotification
    {
        /// <summary>
        /// The notification's title (not supported on all platforms)
        /// </summary>
        public string Title { get; }
        /// <summary>
        /// The notification's body
        /// </summary>
        public string Body { get; }

        protected internal FCMMessageNotification()
        {

        }

        protected internal FCMMessageNotification(string title, string body)
        {
            Title = title;
            Body = body;
        }
    }
}