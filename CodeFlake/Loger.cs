using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace CodeFlakeApp
{
    public class Loger
    {
        [Import("ILoger", typeof(Object))]        
        dynamic ILoger { get; set; }
        
        public static Action<string> Log = (message) => Loger.Compose().ILoger.Log(message);

        private static Loger Compose()
        {
            try
            {
                var loger = new Loger();
                var catalog = new DirectoryCatalog(@"C:\Loger\LogerComponent\bin\Debug");
                var container = new CompositionContainer(catalog);
                container.ComposeParts(loger);
                return loger;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}