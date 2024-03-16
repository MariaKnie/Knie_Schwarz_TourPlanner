using System.Configuration;
using System.Data;
using System.Windows;
using Knie_Schwarz_TourPlanner_project.Services;
using Knie_Schwarz_TourPlanner_project.ViewModels;
using Knie_Schwarz_TourPlanner_project.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Knie_Schwarz_TourPlanner_project
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceCollection services = new ServiceCollection();
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            //known windows
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<RouteManagementViewModel>();
            services.AddSingleton<LogViewModel>();

            
            services.AddSingleton<ViewModelLocator>();  //Locator
            services.AddSingleton<WindowMapper>();  //Mapper
            services.AddSingleton<IWindowManager, WindowManager>(); //Open, CLose Windows Alternative
            services.AddSingleton<IItemService, ItemService>();   //Collection
                                                       
            _serviceProvider = services.BuildServiceProvider();

        }
        //instead of StartupURL
        protected override void OnStartup(StartupEventArgs e)
        {
            var windowManager = _serviceProvider.GetRequiredService<IWindowManager>();
            windowManager.ShowWindow(viewModel: _serviceProvider.GetRequiredService<MainViewModel>());
            base.OnStartup(e);
        }
    }

}
