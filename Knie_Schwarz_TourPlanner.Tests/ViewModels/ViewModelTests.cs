using Knie_Schwarz_TourPlanner_project.ViewModels;

namespace TaskPlannerA.Tests.ViewModels
{
    public class ViewModelTests
    {
        //private EditorViewModel edtVM;
        private MainViewModel mainVM;

        [SetUp]
        public void Setup()
        {
            //edtVM = new EditorViewModel();
            mainVM = new MainViewModel(edtVM);
            mainVM = new MainViewModel;
        }

        [Test]
        public void TestTaskPlanner_ShouldContainInitialList()
        {
            // Arrange --> in Setup
            // Act
            int expectedCount = 4;
            int actualCount = mainVM.Tourlist.Count;
            // Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public void TestTaskPlanner_AddTask_ShouldUpdateList()
        {
            // Arrange
            int lastTaskCount = mainVM.Tasks.Count;
            int expectedTaskCount = lastTaskCount + 1;
            string expectedTaskName = "Test Task";
            // Act & Assert
            edtVM.NewTaskName = expectedTaskName;
            edtVM.AddTaskCommand.Execute(null);
            int actualTaskCount = mainVM.Tasks.Count;
            Assert.That(actualTaskCount, Is.EqualTo(expectedTaskCount));
            string actualTaskName = mainVM.Tasks[actualTaskCount - 1].Name;
            Assert.That(actualTaskName, Is.EqualTo(expectedTaskName));
        }
    }
}