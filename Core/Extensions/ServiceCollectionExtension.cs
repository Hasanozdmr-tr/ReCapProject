using Core.Utilities.IOC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class ServiceCollectionExtension
    {      //bu extension class ı aslında bir polimorfizmdir. ServiceCollection a AddDependencyResolvers özelliği kazandırıyoruz.
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, //extent ettiğimiz tip 
            ICoreModule[] modules)
        {
            // IServiceCollection araya girmesini istediğimiz dependencyresolvers ları yani servis bağımlılıklarını eklediğimiz
            // koleksiyonun ta kendisidir.
            // normnalde bunları startup a yazıyorduk artık core a aldık.
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }
            return ServiceTool.Create(serviceCollection);
        }

    }
}
