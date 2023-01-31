namespace SuperNewRoles.Mode.TaskPractice
{
    class TaskPracticeOption
    {
        private const int optionId = 1099;// 設定のId
        public static CustomOption TaskPracticeMode;
        public static void Load()
        {
            TaskPracticeMode = CustomOption.Create(optionId, true, CustomOptionType.Generic, "SettingTaskPracticeMode", false, ModeHandler.ModeSetting);
        }
    }
}