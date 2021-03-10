using Core.Utilities.IOC;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Text.RegularExpressions;

namespace Core.CrossCuttingConcern.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        // Burada Adapter Pattern yapmış olduk. Microsoftun teknolojisi olsa bile biz onu kendimize uyarladık. Neden ?
         // Çünkü bugün memorycache ile çalışıyoruz yarın başka bir cache yöntemiyle çalışabiliriz. oyüzden direk kodu gömmedik. 
         //IMemoryCache tipinde bize ne gönderirlerse öyle çalışırız.

        IMemoryCache _memoryCache; //bunu injecte edebilmek için Addcache çalıştırdık coremodule da..

        public MemoryCacheManager()
        {
            _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
        }

        public void Add(string key, object value, int duration)
        {
            //Set ile cache e değer ekliyorsun.
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public bool IsAdd(string key)
        {
            return _memoryCache.TryGetValue(key, out _);  //out ile hem input olarak verirsin hem de o değeri döndürürsün. 
                                                          // burada _ ile sadece bool değerini döndür out değerini istemiyoruz diyoruz.
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {                     // Get property memory cache in bellekte entriescollection ını bul demek. 
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;
            // definition ı da _memorycache olanları bul.
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();
            // sonra her bir cache elemanlaarını gez.
            foreach (var cacheItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();
            // benim özelliklerime uygun olan varsa keystoremove a at.
            // Sonra da alttaki foreach te sil.
            foreach (var key in keysToRemove)
            {
                _memoryCache.Remove(key);
            }
        }
    }
}
