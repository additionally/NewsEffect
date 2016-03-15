using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsEffectDatabaseConn;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace NewsEffectRun
{
    public class Program
    {
        
       // private static readonly ILog logger = LogManager.GetLogger("program.cs");
        //private List<string> _locales;

        //public List<string> locales
        //{
        //    get { return _locales; }
        //    set
        //    {
        //        _locales = datarep.readloc(); ;
        //        //OnPropertyChanged("locales");
        //    }
        //}

        static void Main(string[] args)
        {
           DatabaseRepository datarep = new DatabaseRepository();

           List<string> places = datarep.readloc();
           foreach (var p in places)
           {
               Console.WriteLine();
           }
            
            Console.Read();


        }
    }
}
