using LearnApp.PageModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearnApp.PageModels
{
    public class DashBoardPageModel : PageModelBase
    {
        private LecturesPageModel _lecturePM;
        public LecturesPageModel LecturesPageModel
        {
            get => _lecturePM;
            set => SetProperty(ref _lecturePM, value);
        }
        private TestsPageModel _testPM;
        public TestsPageModel TestsPageModel
        {
            get => _testPM;
            set => SetProperty(ref _testPM, value);
        }

        private TaskPageModel _taskPM;
        public TaskPageModel TaskPageModel
        {
            get => _taskPM;
            set => SetProperty(ref _taskPM, value);
        }
        private SettingsPageModel _settingsPM;
        public SettingsPageModel SettingsPageModel
        {
            get => _settingsPM;
            set => SetProperty(ref _settingsPM, value);
        }
        public DashBoardPageModel(LecturesPageModel lecturePM, TestsPageModel testPM,
            TaskPageModel taskPM, SettingsPageModel settingsPM)
        {
            LecturesPageModel = lecturePM;
            TestsPageModel = testPM;
            TaskPageModel = taskPM;
            SettingsPageModel = settingsPM;
        }
        public override Task InitializeAsync(object navigationDate)
        {
            return Task.WhenAny(base.InitializeAsync(navigationDate),
                LecturesPageModel.InitializeAsync(null),
                TestsPageModel.InitializeAsync(null),
                TaskPageModel.InitializeAsync(null),
                SettingsPageModel.InitializeAsync(null));
        }
    }
}
