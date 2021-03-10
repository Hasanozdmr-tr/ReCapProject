using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using Core.CrossCuttingConcern.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IOC;
using Microsoft.Extensions.DependencyInjection;


namespace Core.Aspects.Autofac.Caching
{
    //Cache i temizler. Ne zaman ?? Bir update, Bir ekleme olduğu zaman eski cache in temizlenmesi gerekir.
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }
        // peki neden onsuccess ? invocation yani add metodu tamamlandıktan sonra çalışır. Çünkü tamamlanmadan hat alırsa cache i silmesin.
        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
