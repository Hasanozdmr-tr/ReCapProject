using Core.Utilities.Interceptors;
using Core.Utilities.IOC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;
using Business.Constant;

namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        //SecuredOperation jwt için
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;  // jwt ile gönderdiğin her bir istek httpcontext oluşturur. her seferinde bir tread oluşur.
       
        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');  //gönderdiğin nesneleri virgül ile ayırıyor 2 ye.
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            //SecureOperation bir aspecttir. Aspectler web api, Business, katmanları gibi değil. Bağlantısı yok bu zincirle. 
            //ServiceTool Serviceprovider ile servis mimarimize ulaşıyor. Onları da burayaenjekte edebilmek için
          // enjekte edebilmek için httpContextAccesssor u IProductDal ile değiştirip bağlayabilir.
        }
        // onbefore önünde çalış invocation metodu yani add metodunun diyo.
        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))   //claim leri içerisinde role leri gez varsa bitir return et.yoksa hata ver. 
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
