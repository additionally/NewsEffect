using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace NewsEffectRun
{
    public class Program
    {
        private static readonly ILog logger = LogManager.GetLogger("program.cs");

        static void Main(string[] args)
        {

        }
    }
}
