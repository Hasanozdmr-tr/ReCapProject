using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcern.Caching
{
    public interface ICacheManager //Hangi cache tekniğini kullanırsan kullan bundan implemente etmen gerek.
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object value, int duration);
        bool IsAdd(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern); //bir pattern oluşturup o kural ile birden fazla nesne de silinebilir.
    }
}
