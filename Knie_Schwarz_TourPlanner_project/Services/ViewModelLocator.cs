using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Knie_Schwarz_TourPlanner_project.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Knie_Schwarz_TourPlanner_project.Services
{
    public  class ViewModelLocator
    {
        private readonly IServiceProvider _provider;

        public ViewModelLocator(IServiceProvider provider)
        {
            _provider = provider;
        }

        public MainViewModel MainViewModel => _provider.GetRequiredService<MainViewModel>();
        public RouteManagementViewModel RouteManagementViewModel => _provider.GetRequiredService<RouteManagementViewModel>();
        public LogViewModel LogViewModel => _provider.GetRequiredService<LogViewModel>();
    }
}
