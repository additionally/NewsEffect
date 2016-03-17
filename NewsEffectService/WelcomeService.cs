using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsEffectService
{
    public class WelcomeService : IWelcomeService
    {
        string IWelcomeService.GetWelcome() 
        {
            string wilko = "You are using Effect";
            return wilko; 
        }
    }
}
