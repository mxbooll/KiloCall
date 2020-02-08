using System.Collections.Generic;

namespace KiloCall.Core.Controller
{
    public interface IDataSaver
    {
        void Save<T>(List<T> item) where T : class;
        List<T> Load<T>() where T : class; 
    }
}
