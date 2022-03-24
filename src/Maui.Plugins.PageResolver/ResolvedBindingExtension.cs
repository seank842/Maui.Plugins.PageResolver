using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System;

namespace Maui.Plugins.PageResolver;

//[ContentProperty(nameof(ViewModel))]
public class ResolvedBindingExtension : IMarkupExtension<object>
{
    public Type ViewModel { get; set; }

    public object ProvideValue(IServiceProvider serviceProvider)
    {
        var vm = ActivatorUtilities.CreateInstance(Resolver.GetServiceProvider(), ViewModel.GetType());
        return vm;
    }
}
