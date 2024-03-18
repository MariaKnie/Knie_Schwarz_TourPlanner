using Knie_Schwarz_TourPlanner_project.Models;
using Knie_Schwarz_TourPlanner_project.Services;
using Knie_Schwarz_TourPlanner_project.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace TaskPlannerA.Tests.ViewModels
{
    public class ViewModelTests
    {
        //private EditorViewModel edtVM;
        private MainViewModel mainVM;
        private RouteManagementViewModel routeManagementVM;
        private LogViewModel logVM;

        [SetUp]
        public void Setup()
        {
            IServiceCollection services = new ServiceCollection();
            IServiceProvider _serviceProvider;
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<RouteManagementViewModel>();
            services.AddSingleton<LogViewModel>();

            services.AddSingleton<ViewModelLocator>();  //Locator
            services.AddSingleton<WindowMapper>();  //Mapper
            services.AddSingleton<IWindowManager, WindowManager>(); //Open, CLose Windows Alternative
            services.AddSingleton<IItemService, ItemService>();   //Collection
            _serviceProvider = services.BuildServiceProvider();
            ItemService itemService = new ItemService();
            WindowMapper windowMapper = new WindowMapper();
            WindowManager windowManager = new WindowManager(windowMapper);
            ViewModelLocator viewModelLocator = new ViewModelLocator(_serviceProvider);

            logVM = new LogViewModel(itemService);
            routeManagementVM = new RouteManagementViewModel(itemService);
            mainVM = new MainViewModel(itemService, windowManager, viewModelLocator, routeManagementVM, logVM);
        }

        [Test]
        public void TestRouteList_ShouldContainInitialList()
        {
            // Arrange --> in Setup
            // Act
            int expectedCount = 4;
            int actualCount = mainVM.routeManagementVM.RouteList.Count;
            // Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public void TestRouteList_AddRoute_ShouldUpdateList()
        {
            // Arrange
            int lastRouteCount = mainVM.routeManagementVM.RouteList.Count;
            int expectedRouteCount = lastRouteCount + 1;
            string expectedRouteName = "TestRoute";
            RouteModel routeModelToAdd = new RouteModel();
            // Act & Assert
            routeModelToAdd.RouteName = expectedRouteName;
            mainVM.routeManagementVM.RouteList.Add(routeModelToAdd);
            int actualRouteCount = mainVM.routeManagementVM.RouteList.Count;
            Assert.That(actualRouteCount, Is.EqualTo(expectedRouteCount));
            string actualRouteName = mainVM.routeManagementVM.RouteList[actualRouteCount - 1].RouteName;
            Assert.That(actualRouteName, Is.EqualTo(expectedRouteName));
        }

        [Test]
        public void TestRouteList_AddRouteLog_ShouldUpdateLogList()
        {
            // Arrange
            int lastLogCount = mainVM.routeManagementVM.RouteList[0].TourLogs.Count;
            int expectedLogCount = lastLogCount + 1;
            mainVM.ItemService.ActiveRoute = mainVM.routeManagementVM.RouteList[0];
            // Act & Assert
            mainVM.logVM.LoadLogAdd.Execute(this);
            mainVM.logVM.SaveLog.Execute(this);
            int actualLogCount = mainVM.routeManagementVM.RouteList[0].TourLogs.Count;
            Assert.That(actualLogCount, Is.EqualTo(expectedLogCount));
        }

        [Test]
        public void TestRouteList_EditRouteLog_ShouldUpdateLog()
        {
            // Arrange
            int lastLogDifficulty = mainVM.routeManagementVM.RouteList[0].TourLogs[0].Childfriendliness;
            int expectedLogDifficulty = lastLogDifficulty + 1;
            mainVM.ItemService.ActiveRoute = mainVM.routeManagementVM.RouteList[0];
            mainVM.ItemService.ActiveLogModel = mainVM.routeManagementVM.RouteList[0].TourLogs[0];
            // Act & Assert
            mainVM.logVM.LoadLogEdit.Execute(this);
            mainVM.logVM._Childfriendliness = mainVM.logVM._Childfriendliness + 1;
            mainVM.logVM.SaveLog.Execute(this);
            int actualLogDifficulty = mainVM.routeManagementVM.RouteList[0].TourLogs[0].Childfriendliness;
            Assert.That(actualLogDifficulty, Is.EqualTo(expectedLogDifficulty));
        }
    }
}