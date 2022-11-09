namespace SuperNewRoles.Mode.TaskPractice
{
    class TaskPracticeOption
    {
        private const int optionId = 1099;// 設定のId
        public static CustomOption TaskPracticeMode; //仕事人モード
        public static CustomOption IsEmergencyCall; //緊急招集が自動で行われるか
        public static CustomOption IsEmergencyCallIndividualSetting; //「[個別設定] 自動緊急招集が起きる時間」を有効にするか
        public static CustomOption SetTimingForEmergencyCall; //自動緊急招集が起きる時間 [中央値]
        public static CustomOption SetErrorMargunForEmergencyCall; //自動緊急招集が起きる時間の誤差 [絶対値]
        public static CustomOption IsLoseWhenFailFinishTask; //指定ターンまでにタスクを終わらせられなかった場合敗北するか
        public static CustomOption SetLimitsOfTurn; //強制敗北するターン数
        public static CustomOption IsSabotageTriggered; //サボタージュを自動的に発動させるか
        public static CustomOption IsSabotageIndividualSetting; //「[個別設定] サボタージュ」を有効にするか
        public static CustomOption IsAutoRipea; //サボタージュを自動で直すか
        public static CustomOption SetTimingForAutoRipea; //サボが自動で直る時間 [中央値]
        public static CustomOption SetErrorMargunForAutoRipea; //サボが自動で直る時間の誤差 [絶対値]
        public static CustomOption SetDoorClosingTime; //ターン開始からドアが閉まるまでの秒数
        public static CustomOption SetDoorClosingInterval; //ドアが閉まる間隔
        public static CustomOption SetTurnsThatelEctricalSabotage; //序盤:停電が入るターン数 (此処の設定ターン数までを「序盤」とする)
        public static CustomOption SetEctricalSabotageTriggeredTime; //序盤:ターン開始から停電が入るまでの秒数
        public static CustomOption SetOtherSabotageTriggeredTime; //中盤:ターン開始からサボ(コミュサボ or リアクター)が入るまでの秒数
        public static CustomOption SetTimingForSabotage; //サボが発動する間隔 [中央値]
        public static CustomOption SetErrorMargunForSabotage; //サボが発動する間隔の誤差 [絶対値]

        public static void Load()
        {
            TaskPracticeMode = CustomOption.Create(optionId + 0, true, CustomOptionType.Generic, "SettingTaskPracticeMode", false, ModeHandler.ModeSetting);
            IsEmergencyCall = CustomOption.Create(optionId + 1, false, CustomOptionType.Generic, "TPIsEmergencyCall", false, TaskPracticeMode);
            IsEmergencyCallIndividualSetting = CustomOption.Create(optionId + 2, false, CustomOptionType.Generic, "TPIsEmergencyCallIndividualSetting", false, IsEmergencyCall);
            SetTimingForEmergencyCall = CustomOption.Create(optionId + 3, false, CustomOptionType.Generic, "TPSetTimingForEmergencyCall", 25f, 0f, 120f, 1f, IsEmergencyCallIndividualSetting);
            SetErrorMargunForEmergencyCall = CustomOption.Create(optionId + 4, false, CustomOptionType.Generic, "TPSetErrorMargunForEmergencyCall", 15f, 0f, 30f, 0.5f, IsEmergencyCallIndividualSetting);
            IsLoseWhenFailFinishTask = CustomOption.Create(optionId + 5, false, CustomOptionType.Generic, "TPIsLoseWhenFailFinishTask", false, IsEmergencyCall);
            SetLimitsOfTurn = CustomOption.Create(optionId + 6, false, CustomOptionType.Generic, "TPSetLimitsOfTurn", 10f, 1f, 20f, 1f, IsLoseWhenFailFinishTask);
            IsSabotageTriggered = CustomOption.Create(optionId + 7, false, CustomOptionType.Generic, "TPIsSabotageTriggered", false, TaskPracticeMode);
            IsSabotageIndividualSetting = CustomOption.Create(optionId + 8, false, CustomOptionType.Generic, "TPIsSabotageIndividualSetting", false, IsSabotageTriggered);
            IsAutoRipea = CustomOption.Create(optionId + 9, false, CustomOptionType.Generic, "TPIsAutoRipea", true, IsSabotageIndividualSetting);
            SetTimingForAutoRipea = CustomOption.Create(optionId + 10, false, CustomOptionType.Generic, "TPSetTimingForAutoRipea", 20f, 0f, 60f, 1f, IsAutoRipea);
            SetErrorMargunForAutoRipea = CustomOption.Create(optionId + 11, false, CustomOptionType.Generic, "TPSetErrorMargunForAutoRipea", 10f, 0f, 20f, 1f, IsAutoRipea);
            SetDoorClosingTime = CustomOption.Create(optionId + 12, false, CustomOptionType.Generic, "TPSetDoorClosingTime", 3f, 0f, 10f, 1f, IsSabotageIndividualSetting);
            SetDoorClosingInterval = CustomOption.Create(optionId + 13, false, CustomOptionType.Generic, "TPSetDoorClosingInterval", 30f, 0f, 120f, 5f, IsSabotageIndividualSetting);
            SetTurnsThatelEctricalSabotage = CustomOption.Create(optionId + 14, false, CustomOptionType.Generic, "TPSetTurnsThatelEctricalSabotage", 3f, 0f, 10f, 1f, IsSabotageIndividualSetting);
            SetEctricalSabotageTriggeredTime = CustomOption.Create(optionId + 15, false, CustomOptionType.Generic, "TPSetEctricalSabotageTriggeredTime", 25f, 0f, 60f, 1f, IsSabotageIndividualSetting);
            SetOtherSabotageTriggeredTime = CustomOption.Create(optionId + 16, false, CustomOptionType.Generic, "TPSetOtherSabotageTriggeredTime", 15f, 0f, 60f, 1f, IsSabotageIndividualSetting);
            SetTimingForSabotage = CustomOption.Create(optionId + 17, false, CustomOptionType.Generic, "TPSetTimingForSabotage", 15f, 15f, 60f, 1f, IsSabotageIndividualSetting);
            SetErrorMargunForSabotage = CustomOption.Create(optionId + 18, false, CustomOptionType.Generic, "TPSetErrorMargunForSabotage", 10f, 0f, 30f, 1f, IsSabotageIndividualSetting);
        }
    }
}