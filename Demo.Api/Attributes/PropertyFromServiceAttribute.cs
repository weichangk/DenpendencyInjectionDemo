using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Demo.Api.Attributes
{
    // 属性注入特性
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class PropertyFromServiceAttribute : Attribute, IBindingSourceMetadata
    {
        public BindingSource BindingSource => BindingSource.Services;
    }

}
