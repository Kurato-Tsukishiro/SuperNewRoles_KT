namespace SuperNewRoles.Mode.TaskPractice
{
    class TaskPracticeOption
    {
        public static CustomOption TaskPracticeMode;
        public static void Load()
        {
            TaskPracticeMode = CustomOption.Create(1099, true, CustomOptionType.Generic, "SettingBattleRoyalMode", false, ModeHandler.ModeSetting);
        }
    }
}