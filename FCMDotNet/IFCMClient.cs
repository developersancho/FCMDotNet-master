using System.Threading.Tasks;
using FCMDotNet.Model;
using FCMDotNet.Model.ModelData;

namespace FCMDotNet
{
    public interface IFCMClient
    {
        /// <summary>
        /// Posts a message to Firebase
        /// </summary>
        /// <param name="message">Message to send. Use FCMMessageBuilder to construct it</param>
        /// <returns></returns>
        Task<FCMResponse> PostMessage(FCMMessage message);
    }
}