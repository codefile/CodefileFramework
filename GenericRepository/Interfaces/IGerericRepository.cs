using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericRepository.Interfaces
{
    /// <summary>
    /// Interface de contrato para um repositório genérico.
    /// </summary>
    public interface IGerericRepository : IDisposable
    {
        T Insert<T>(T item, bool saveNow = true) where T : class, new();
        T Update<T>(T item, bool saveNow = true) where T : class, new();
        T Delete<T>(T item, bool saveNow = true) where T : class, new();
        int Save();
    }
}
