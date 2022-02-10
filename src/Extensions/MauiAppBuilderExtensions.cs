using System.Reflection;
using MauiShellMvvmHelper.Attributes;
using MauiShellMvvmHelper.Exceptions;

namespace MauiShellMvvmHelper.Extensions;

    public static class MauiAppBuilderExtensions
    {
        /// <summary>
        /// Registers view and binds viewModel based on ViewModel attribute
        /// </summary>
        /// <typeparam name="TView">View type</typeparam>
        /// <param name="mauiAppBuilder">MauiAppBuilder</param>
        /// <param name="serviceLifetime">Service lifetime</param>
        /// <returns>MauiAppBuilder</returns>
        /// <exception cref="MissingViewModelAttributeException">Missing ViewModel attribute</exception>
        public static MauiAppBuilder RegisterView<TView>
          (this MauiAppBuilder mauiAppBuilder,ServiceLifetime serviceLifetime = ServiceLifetime.Transient) where TView : BindableObject, new()
        {
            
            var viewModelAttriute = typeof(TView).GetCustomAttributes().FirstOrDefault(x => x is ViewModelAttribute) as ViewModelAttribute ??
                throw new MissingViewModelAttributeException(typeof(TView));

            mauiAppBuilder.Services.Add(new ServiceDescriptor(viewModelAttriute.ViewModelType,viewModelAttriute.ViewModelType, serviceLifetime));
            mauiAppBuilder.Services.Add(new ServiceDescriptor(typeof(TView), serviceProvider => {
                return new TView
                {
                    BindingContext = serviceProvider.GetRequiredService(viewModelAttriute.ViewModelType)
                };
            }, serviceLifetime));
            return mauiAppBuilder;
        }

        /// <summary>
        /// Registers view and binds viewModel
        /// </summary>
        /// <typeparam name="TView">View type</typeparam>
        /// <typeparam name="KViewModel">View model type</typeparam>
        /// <param name="mauiAppBuilder">MauiAppBuilder</param>
        /// <param name="serviceLifetime">Service lifetime</param>
        /// <returns>MauiAppBuilder</returns>
        public static MauiAppBuilder RegisterView<TView, KViewModel>
            (this MauiAppBuilder mauiAppBuilder, ServiceLifetime serviceLifetime = ServiceLifetime.Transient) where TView : BindableObject, new()
        {
            mauiAppBuilder.Services.Add(new ServiceDescriptor(typeof(KViewModel),typeof(KViewModel), serviceLifetime));
            mauiAppBuilder.Services.Add(new ServiceDescriptor(typeof(TView),serviceProvider => {
                return new TView
                {
                    BindingContext = serviceProvider.GetRequiredService<KViewModel>()
                };
            }, serviceLifetime));
            return mauiAppBuilder;
        }
    }
