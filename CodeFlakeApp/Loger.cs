using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace CodeFlakeApp
{
    public class Loger : ILoger
    {
        [Import("ILoger", typeof(Object))]        
        dynamic ILoger.LogerProp { get; set; }
        private static ILoger loger;

        public Loger(ILoger _loger)
        {
            loger = _loger;
        }

        public static Action<string> Log = (message) => Loger.Compose().LogerProp.Log(message);

        private static ILoger Compose()
        {
            try
            {
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