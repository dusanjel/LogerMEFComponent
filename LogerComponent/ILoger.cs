using System.ComponentModel.Composition;

namespace Loger.Component
{
    [InheritedExport("ILoger", typeof(ILoger))]
    public interface ILoger
    {
        void Log(string message);
    }
}