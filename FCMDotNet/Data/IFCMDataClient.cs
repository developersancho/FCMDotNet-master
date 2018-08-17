using FCMDotNet.Model.ModelData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCMDotNet.Data
{
    public interface IFCMDataClient
    {
        Task<FCMDataResponse> PostDataMessageAsync(FCMDataMessage message);
    }
}
