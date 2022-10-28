using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Portal.Domain.ValueObjects;

namespace Portal.WebApi.Utilities
{
    //public class ValueObjectModelBinderProvider : IModelBinderProvider
    //{
    //    public IModelBinder? GetBinder(ModelBinderProviderContext context)
    //    {
    //        if(context == null)
    //        {
    //            throw new ArgumentNullException(nameof(context));
    //        }
    //        else
    //        {
    //            return new BinderTypeModelBinder(typeof(ValueObjectModelBinder));
    //        }
    //        throw new NotImplementedException();
    //    }
    //}

    //public class ValueObjectModelBinder : IModelBinder
    //{
    //    public Task BindModelAsync(ModelBindingContext bindingContext)
    //    {
    //        if(bindingContext is null)
    //        {
    //            throw new ArgumentNullException(nameof(bindingContext));
    //        }
    //        if(bindingContext.ModelType.GetInterfaces().Contains(typeof(ISingleValueObject)))
    //        {
    //            var genericInterface = bindingContext.ModelType.GetInterfaces().Where(x => x.Name.Contains(nameof(ISingleValueObject)) && x.IsGenericType).First();
    //            var request = bindingContext.HttpContext.Request;
    //            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.FieldName).First();

    //            object value;
    //            try
    //            {
    //                value = Activator.CreateInstance(genericInterface.GenericTypeArguments[0], valueProviderResult);
    //            }
    //            catch
    //            {
    //                value = valueProviderResult;
    //            }
    //            bindingContext.Model = Activator.CreateInstance(bindingContext.ModelType, value);
    //            bindingContext.Result = ModelBindingResult.Success(bindingContext.Model);
    //        }
    //        return Task.CompletedTask;
    //    }
    //}
}
