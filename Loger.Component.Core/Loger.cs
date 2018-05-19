using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loger.Component.Core
{
    [Export("ILoger ", typeof(object))]
    public class Loger : ILoger
    {        
        public void Log(string message)
        {
            Console.WriteLine(message);
            Console.ReadLine();            
        }
    }
}
