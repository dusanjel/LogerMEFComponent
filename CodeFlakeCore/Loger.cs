using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Composition;
using System.Composition.Hosting;
using System.Runtime.Loader;

namespace CodeFlakeApp
{
    public class Loger : ILoger
    {
        [Import("ILoger")]        
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
                var directory = @"C:\Loger\Loger.Component.Core\bin\Debug\netcoreapp2.0";
                var assemblies = System.IO.Directory.GetFiles(directory, "*.dll")
                                .Select(AssemblyLoadContext.Default.LoadFromAssemblyPath);
                var configuration = new ContainerConfiguration().WithAssemblies(assemblies);
                var container = configuration.CreateContainer();
                container.SatisfyImports(loger);
                return loger;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}