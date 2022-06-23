using CommunityToolkit.Maui.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace Maui.Plugins.PageResolver
{
    public static class PopupExtensions
    {
#nullable enable
        public static async Task<object?> ShowPopupAsync<T>(this Page page) where T : Popup
        {
            var resolvedPopup = Resolver.Resolve<T>();
            return await page.ShowPopupAsync(resolvedPopup);
        }
        public static async Task<object?> ShowPopupAsync<T>(this Page page, params object[] parameters) where T : Popup
        {
            var resolvedPopup = ActivatorUtilities.CreateInstance<T>(Resolver.GetServiceProvider(), parameters);
            return await page.ShowPopupAsync(resolvedPopup);
        }
#nullable disable
        public static void ShowPopup<T>(this Page page) where T : Popup
        {
            var resolvedPopup = Resolver.Resolve<T>();
            page.ShowPopup(resolvedPopup);
        }

        public static void ShowPopup<T>(this Page page, params object[] parameters) where T : Popup
        {
            var resolvedPopup = ActivatorUtilities.CreateInstance<T>(Resolver.GetServiceProvider(), parameters);
            page.ShowPopup(resolvedPopup);
        }
    }
}
