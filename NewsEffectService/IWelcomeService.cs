using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace NewsEffectService
{
    [ServiceContract]
    public interface IWelcomeService
    {
        [OperationContract]
        string GetWelcome();
    }
}
