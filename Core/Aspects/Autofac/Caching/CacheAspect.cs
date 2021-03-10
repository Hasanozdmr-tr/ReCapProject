using Castle.DynamicProxy;
using Core.CrossCuttingConcern.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;


namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
            // neden direk constructure içerisined veremiyoruz ? Çünkü aspectleri katmanları dikine kesiyor. 
            // CoreModule da tutuyoruz IOC sini.
        }

        public override void Intercept(IInvocation invocation)
        {
            //burası reflection. Key imizi üretmek için path ini belirliyorsun. Northwind.Business.IProductService.GetAll diyelim..
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();         // argument parametreler demek bunları listeye çevirir.
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})"; //string joinle virgül koyarak yan yana yazar. yoksa null basar.
            if (_cacheManager.IsAdd(key))           // IsAdd ile kontrol eder eğer cache de varsa returnvalue yani o değeri döndür neyi veritabanından çektiğimiz veriyi
                                                    // cachmanager da get ile o veriyi getirir. yoksa proceed et sürdür. 
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}