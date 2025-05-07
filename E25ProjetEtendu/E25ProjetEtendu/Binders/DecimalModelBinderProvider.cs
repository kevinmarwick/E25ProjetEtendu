using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace E25ProjetEtendu.Binders
{
    public class DecimalModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(decimal) || context.Metadata.ModelType == typeof(decimal?))
            {
                return new DecimalModelBinder();
            }
            return null;
        }
    }

}
