using Castle.DynamicProxy;
using Core.CrosCuttingConcern.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    
        public class ValidationAspect : MethodInterception
        {
            private Type _validatorType;
            public ValidationAspect(Type validatorType)
            {
                if (!typeof(IValidator).IsAssignableFrom(validatorType))
                {
                    throw new System.Exception("Bu bir doğrulama sınıfı değil");
                }

                _validatorType = validatorType;
            }
            protected override void OnBefore(IInvocation invocation)
            {
                var validator = (IValidator)Activator.CreateInstance(_validatorType); 
                      //reflection kod çalışırken active edilen şey.
                var entityType = _validatorType.BaseType.GetGenericArguments()[0]; 
                 // ilgili metodun base type ını bul ve generic argumanınu bul. Yani Car ı bul diyor.
                var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
                foreach (var entity in entities)
                {
                    ValidationTool.Validate(validator, entity);
                }
            }
        }
    
}
